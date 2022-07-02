using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using MarketoWatchStore.ViewModels;
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
        public ShoppingCartController(MarketoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string cookieCart = HttpContext.Request.Cookies["cart"];

            List<ShoppingCartVM> shoppingcartVMs = new List<ShoppingCartVM>();

            if (!string.IsNullOrWhiteSpace(cookieCart))
            {
                shoppingcartVMs = JsonConvert.DeserializeObject<List<ShoppingCartVM>>(cookieCart);

                foreach (ShoppingCartVM shoppingcartVM in shoppingcartVMs)
                {
                    Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == shoppingcartVM.ProductId);

                    shoppingcartVM.MainImage = dbProduct.MainImage;
                    shoppingcartVM.Title = dbProduct.Title;
                    shoppingcartVM.Price = (dbProduct.DiscountPrice != null && dbProduct.DiscountPrice > 0) ? (double)dbProduct.DiscountPrice : dbProduct.Price;
                }
            }

            return View(shoppingcartVMs);
        }

        public async Task<IActionResult> AddToCart(int? id, int count = 1)
        {
            if (id is null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product is null) return RedirectToAction("error404", "home");

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
            if (id is null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return RedirectToAction("error404", "home");

            string cookieCart = HttpContext.Request.Cookies["cart"];

            List<ShoppingCartVM> shoppingCartVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieCart))
            {
                shoppingCartVMs = JsonConvert.DeserializeObject<List<ShoppingCartVM>>(cookieCart);

                ShoppingCartVM shoppingCartVM = shoppingCartVMs.FirstOrDefault(p => p.ProductId == id);

                if (shoppingCartVM is null) return RedirectToAction("error404", "home");

                shoppingCartVMs.Remove(shoppingCartVM);
            }
            else
            {
                return BadRequest();
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

        public IActionResult ClearAllItems()
        {
            string cookieCart = HttpContext.Request.Cookies["cart"];

            if (!string.IsNullOrWhiteSpace(cookieCart))
            {
                HttpContext.Response.Cookies.Delete("cart");
            }
            else
            {
                return BadRequest();
            }

            return RedirectToAction("index", "shoppingcart");
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}
