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
            List<ShoppingCartVM> shoppingCartVMs = new List<ShoppingCartVM>();

            AppUser appUser = await _userManager.GetUserAsync(User);

            if (appUser is null)
            {
                string cookieCart = HttpContext.Request.Cookies["cart"];

                if (!string.IsNullOrWhiteSpace(cookieCart) && cookieCart != "")
                {
                    shoppingCartVMs = JsonConvert.DeserializeObject<List<ShoppingCartVM>>(cookieCart);

                    foreach (ShoppingCartVM shoppingcartVM in shoppingCartVMs)
                    {
                        Product dbProduct = await _context.Products
                            .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                            .FirstOrDefaultAsync(p => p.Id == shoppingcartVM.ProductId);

                        shoppingcartVM.ProductId = dbProduct.Id;
                        shoppingcartVM.MainImage = dbProduct.MainImage;
                        shoppingcartVM.Title = dbProduct.Title;
                        shoppingcartVM.Price = (dbProduct.DiscountPrice != null && dbProduct.DiscountPrice > 0) ? (double)dbProduct.DiscountPrice : dbProduct.Price;
                        shoppingcartVM.StockCount = dbProduct.Count;
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
                    foreach (ShoppingCart shoppingCart in existShoppingCart)
                    {
                        ShoppingCartVM shoppingCartVM = new ShoppingCartVM
                        {
                            ProductId = shoppingCart.Product.Id,
                            Title = shoppingCart.Product.Title,
                            MainImage = shoppingCart.Product.MainImage,
                            Price = (shoppingCart.Product.DiscountPrice != null && shoppingCart.Product.DiscountPrice > 0) ? (double)shoppingCart.Product.DiscountPrice : shoppingCart.Product.Price,
                            Count = shoppingCart.Count,
                            StockCount = shoppingCart.Product.Count
                        };
                        shoppingCartVMs.Add(shoppingCartVM);
                    }
                }
            }

            return View(shoppingCartVMs);
        }

        public async Task<IActionResult> AddToCart(int? id, int? colourid, int count = 1)
        {
            if (id is null || colourid is null) return RedirectToAction("error400", "home");

            if (!await _context.Colours.AnyAsync(p => p.Id == colourid && !p.IsDeleted)) return RedirectToAction("error404", "home");

            //ProductColour productColour = await _context.ProductColours

            Product product = await _context.Products
                .Include(x => x.ProductColours).ThenInclude(x => x.Colour)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product is null) return RedirectToAction("error404", "home");

            List<ShoppingCartVM> shoppingCartVMs = new List<ShoppingCartVM>();

            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                ShoppingCart existShoppingCart = await _context.ShoppingCarts
                    .Include(sc => sc.Product).ThenInclude(x => x.ProductColours).ThenInclude(x => x.Colour)
                    .FirstOrDefaultAsync(b => b.AppUserId == appUser.Id && b.ProductId == id);

                if (existShoppingCart != null)
                {
                    existShoppingCart.Count += count;
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
                List<ShoppingCart> shoppingCarts = await _context.ShoppingCarts
                    .Include(x => x.Product).ThenInclude(x => x.ProductColours).ThenInclude(x => x.Colour)
                    .ToListAsync();
                foreach (ShoppingCart item in shoppingCarts)
                {
                    ShoppingCartVM shopping = new ShoppingCartVM
                    {
                        MainImage = item.Product.MainImage,
                        Count = item.Count,
                        Price = (item.Product.DiscountPrice != null && item.Product.DiscountPrice > 0) ? (double)item.Product.DiscountPrice : item.Product.Price,
                        StockCount = item.Product.Count,
                        Title = item.Product.Title
                    };
                    shoppingCartVMs.Add(shopping);
                }
            }
            else
            {
                string cookieCart = HttpContext.Request.Cookies["cart"];

                if (!string.IsNullOrWhiteSpace(cookieCart) && cookieCart != "")
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
            }

            return PartialView("_MiniCartPartial", shoppingCartVMs);
        }

        public async Task<IActionResult> RemoveItem(int? id)
        {
            if (id is null) return RedirectToAction("error400", "home");

            Product product = await _context.Products
                .Include(x => x.ProductColours).ThenInclude(x => x.Colour)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return RedirectToAction("error404", "home");

            List<ShoppingCartVM> shoppingCartVMs = new List<ShoppingCartVM>();

            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

                if (!_context.ShoppingCarts.Any(x => x.AppUserId == appUser.Id && x.ProductId == id)) return RedirectToAction("error404", "home");


                List<ShoppingCart> existShoppingCarts = await _context.ShoppingCarts
                    .Include(x => x.Product).ThenInclude(x => x.ProductColours).ThenInclude(x => x.Colour)
                    .Where(x => x.AppUserId == appUser.Id)
                    .ToListAsync();

                ShoppingCart cartItem = existShoppingCarts.Find(x => x.ProductId == id);

                if (cartItem == null) return RedirectToAction("error404", "home");

                existShoppingCarts.Remove(cartItem);
                _context.ShoppingCarts.Remove(cartItem);
                await _context.SaveChangesAsync();

                foreach (ShoppingCart shoppingCart in existShoppingCarts)
                {
                    ShoppingCartVM shopping = new ShoppingCartVM
                    {
                        ProductId = shoppingCart.Product.Id,
                        Title = shoppingCart.Product.Title,
                        MainImage = shoppingCart.Product.MainImage,
                        Count = shoppingCart.Count,
                        Price = (shoppingCart.Product.DiscountPrice != null && shoppingCart.Product.DiscountPrice > 0) ? (double)shoppingCart.Product.DiscountPrice : shoppingCart.Product.Price,
                        StockCount = shoppingCart.Product.Count
                    };
                    shoppingCartVMs.Add(shopping);
                }
            }
            else
            {
                string cookieCart = HttpContext.Request.Cookies["cart"];

                if (!string.IsNullOrWhiteSpace(cookieCart) && cookieCart != "")
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
                    shoppingCartVM.ProductId = dbProduct.Id;
                    shoppingCartVM.Title = dbProduct.Title;
                    shoppingCartVM.MainImage = dbProduct.MainImage;
                    shoppingCartVM.Price = (dbProduct.DiscountPrice != null && dbProduct.DiscountPrice > 0) ? (double)dbProduct.DiscountPrice : dbProduct.Price;
                    shoppingCartVM.StockCount = dbProduct.Count;
                }
            }

            return PartialView("_CartTablePartial", shoppingCartVMs);
        }

        public async Task<IActionResult> ClearAllItems()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

                List<ShoppingCart> existShoppingCarts = await _context.ShoppingCarts
                    .Include(x => x.Product).ThenInclude(x => x.ProductColours).ThenInclude(x => x.Colour)
                    .Where(x => x.AppUserId == appUser.Id)
                    .ToListAsync();

                if (existShoppingCarts != null && existShoppingCarts.Count() > 0)
                {
                    _context.ShoppingCarts.RemoveRange(existShoppingCarts);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return RedirectToAction("error400", "home");
                }
            }
            else
            {
                string cookieCart = HttpContext.Request.Cookies["cart"];

                if (!string.IsNullOrWhiteSpace(cookieCart) && cookieCart != "")
                {
                    HttpContext.Response.Cookies.Delete("cart");
                }
                else
                {
                    return RedirectToAction("error400", "home");
                }
            }

            return RedirectToAction("index", "shoppingcart");
        }
    }
}
