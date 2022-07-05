using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using MarketoWatchStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ShoppingCartController(MarketoDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<ShoppingCartVM> shoppingcartVMs = new List<ShoppingCartVM>();

            AppUser appUser = await _userManager.GetUserAsync(User);

            if (appUser is null)
            {
                string cookieCart = HttpContext.Request.Cookies["cart"];

                if (string.IsNullOrWhiteSpace(cookieCart))
                {
                    shoppingcartVMs = new List<ShoppingCartVM>();
                }
                else
                {
                    shoppingcartVMs = JsonConvert.DeserializeObject<List<ShoppingCartVM>>(cookieCart);

                    foreach (ShoppingCartVM shoppingcartVM in shoppingcartVMs)
                    {
                        Product dbProduct = await _context.Products
                            .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                            .FirstOrDefaultAsync(p => p.Id == shoppingcartVM.ProductId);

                        shoppingcartVM.MainImage = dbProduct.MainImage;
                        shoppingcartVM.Title = dbProduct.Title;
                        shoppingcartVM.Price = (dbProduct.DiscountPrice != null && dbProduct.DiscountPrice > 0) ? (double)dbProduct.DiscountPrice : dbProduct.Price;
                        //shoppingcartVM.ColourId = dbProduct.ProductColours.Where(p => p.ProductId == dbProduct.Id).ToList();
                    }
                }
            }
            else
            {
                List<ShoppingCart> existShoppingCart = await _context.ShoppingCarts
                    .Include(b => b.Product).ThenInclude(b => b.ProductColours).ThenInclude(b => b.Colour)
                    .Where(b => b.AppUserId == appUser.Id)
                    .ToListAsync();

                if (existShoppingCart != null && existShoppingCart.Count() > 0)
                {

                }
            }

            return View(shoppingcartVMs);
        }

        public async Task<IActionResult> AddToCart(int? id, int? colourid, int count = 1)
        {
            if (id is null || colourid is null) return RedirectToAction("error400", "home");

            if (!await _context.Colours.AnyAsync(c => c.Id == colourid && !c.IsDeleted)) return RedirectToAction("error404", "home");

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product is null) return RedirectToAction("error404", "home");

            ProductColour productColour = _context.ProductColours
                .Include(p => p.Colour)
                .FirstOrDefault(p => p.ProductId == product.Id && p.ColourId == colourid);

            if (productColour is null) return RedirectToAction("error404", "home");

            AppUser appUser = await _userManager.GetUserAsync(User);

            if (appUser != null)
            {
                List<ShoppingCart> existShoppingCart = await _context.ShoppingCarts
                    .Where(b => b.AppUserId == appUser.Id)
                    .ToListAsync();

                if (existShoppingCart.Any(c => c.ProductId == product.Id))
                {
                    existShoppingCart.FirstOrDefault(c => c.ProductId == product.Id).Count += count;
                }
                else
                {
                    ShoppingCart shoppingCart = new ShoppingCart
                    {
                        AppUserId = appUser.Id,
                        ProductId = product.Id,
                        Count = count,
                        CreatedAt = DateTime.UtcNow.AddHours(4)
                    };

                    await _context.ShoppingCarts.AddAsync(shoppingCart);
                }

                await _context.SaveChangesAsync();
            }

            string cookieCart = HttpContext.Request.Cookies["cart"];

            List<ShoppingCartVM> shoppingCartVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieCart))
            {
                shoppingCartVMs = JsonConvert.DeserializeObject<List<ShoppingCartVM>>(cookieCart);

                if (shoppingCartVMs.Any(b => b.ProductId == id))
                {
                    shoppingCartVMs.Find(b => b.ProductId == id).Count += count;
                }
                else
                {
                    shoppingCartVMs.Add(new ShoppingCartVM
                    {
                        ProductId = (int)id,
                        ColourId = (int)colourid,
                        Count = count
                    });
                }
            }
            else
            {
                shoppingCartVMs = new List<ShoppingCartVM>();

                shoppingCartVMs.Add(new ShoppingCartVM
                {
                    ProductId = (int)id,
                    Count = count
                });
            }

            cookieCart = JsonConvert.SerializeObject(shoppingCartVMs);
            HttpContext.Response.Cookies.Append("cart", cookieCart);

            foreach (ShoppingCartVM shoppingCartVM in shoppingCartVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == shoppingCartVM.ProductId);

                shoppingCartVM.Title = dbProduct.Title;
                shoppingCartVM.MainImage = dbProduct.MainImage;
                shoppingCartVM.Price = (dbProduct.DiscountPrice != null && dbProduct.DiscountPrice > 0) ? (double)dbProduct.DiscountPrice : dbProduct.Price;
            }

            return PartialView("_MiniCartPartial", shoppingCartVMs);
        }

        public async Task<IActionResult> RemoveItem(int? id)
        {
            if (id is null) return RedirectToAction("error400", "home");

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return RedirectToAction("error404", "home");

            AppUser appUser = await _userManager.GetUserAsync(User);

            string cookieCart = HttpContext.Request.Cookies["cart"];

            List<ShoppingCartVM> shoppingCartVMs = null;

            if (appUser != null)
            {
                ShoppingCart cartItem = await _context.ShoppingCarts
                    .FirstOrDefaultAsync(b => b.AppUserId == appUser.Id && b.ProductId == product.Id);

                if (cartItem is null) return RedirectToAction("error404", "home");

                _context.ShoppingCarts.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            if (!string.IsNullOrWhiteSpace(cookieCart))
            {
                shoppingCartVMs = JsonConvert.DeserializeObject<List<ShoppingCartVM>>(cookieCart);

                ShoppingCartVM shoppingCartVM = shoppingCartVMs.FirstOrDefault(b => b.ProductId == id);

                if (shoppingCartVM is null) return RedirectToAction("error404", "home");

                shoppingCartVMs.Remove(shoppingCartVM);
            }
            else
            {
                return RedirectToAction("error400", "home");
            }

            cookieCart = JsonConvert.SerializeObject(shoppingCartVMs);
            HttpContext.Response.Cookies.Append("cart", cookieCart);

            foreach (ShoppingCartVM shoppingCartVM in shoppingCartVMs)
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == shoppingCartVM.ProductId);

                shoppingCartVM.Title = dbProduct.Title;
                shoppingCartVM.MainImage = dbProduct.MainImage;
                shoppingCartVM.Price = (dbProduct.DiscountPrice != null && dbProduct.DiscountPrice > 0) ? (double)dbProduct.DiscountPrice : dbProduct.Price;
            }

            return PartialView("_CartTablePartial", shoppingCartVMs);
        }

        public async Task<IActionResult> ClearAllItems()
        {
            AppUser appUser = await _userManager.GetUserAsync(User);

            if (appUser != null)
            {
                List<ShoppingCart> existShoppingCart = await _context.ShoppingCarts
                    .Where(b => b.AppUserId == appUser.Id)
                    .ToListAsync();

                if (existShoppingCart.Count > 0)
                {
                    _context.ShoppingCarts.RemoveRange(existShoppingCart);
                    await _context.SaveChangesAsync();
                }
            }

            string cookieCart = HttpContext.Request.Cookies["cart"];

            if (!string.IsNullOrWhiteSpace(cookieCart))
            {
                HttpContext.Response.Cookies.Delete("cart");
            }
            else
            {
                return RedirectToAction("error400", "home");
            }

            return RedirectToAction("index", "shoppingcart");
        }

        public async Task<IActionResult> Checkout()
        {
            AppUser appUser = await _userManager.GetUserAsync(User);

            if (appUser is null)
            {
                return RedirectToAction("login", "account");
            }

            return View();
        }
    }
}
