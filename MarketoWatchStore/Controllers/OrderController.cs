using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using MarketoWatchStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(MarketoDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Create()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Customer")) return RedirectToAction("login", "account");

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (appUser is null) return RedirectToAction("login", "account");

            double total = 0;

            List<ShoppingCart> shoppingCarts = await _context.ShoppingCarts
                .Include(b => b.Product)
                .Where(b => b.AppUserId == appUser.Id)
                .ToListAsync();

            if (shoppingCarts is null || shoppingCarts.Count == 0) return RedirectToAction("index", "shoppingcart");

            foreach (ShoppingCart shoppingCart in shoppingCarts)
            {
                total = (double)(total + (shoppingCart.Count * (shoppingCart.Product.DiscountPrice > 0 ? shoppingCart.Product.DiscountPrice : shoppingCart.Product.Price)));
            }

            ViewBag.Total = total;
            ViewBag.ShoppingCarts = shoppingCarts;

            OrderVM orderVM = new OrderVM
            {
                FullName = appUser.FullName,
                Email = appUser.Email,
                Address = appUser.Address,
                City = appUser.City,
                Country = appUser.Country,
                ZipCode = appUser.ZipCode
            };

            return View(orderVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderVM orderVM)
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (appUser == null)
            {
                return RedirectToAction("login", "Account");
            }
            double total = 0;

            List<ShoppingCart> shoppingCarts = await _context.ShoppingCarts
                .Include(b => b.Product)
                .Where(b => b.AppUserId == appUser.Id)
                .ToListAsync();

            foreach (ShoppingCart shoppingCart in shoppingCarts)
            {
                total = (double)(total + (shoppingCart.Count * (shoppingCart.Product.DiscountPrice > 0 ? shoppingCart.Product.DiscountPrice : shoppingCart.Product.Price)));
            }

            ViewBag.Total = total;
            ViewBag.ShoppingCarts = shoppingCarts;

            if (!ModelState.IsValid)
            {
                return View(orderVM);
            }

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (ShoppingCart shoppingCart in shoppingCarts)
            {
                total = (double)(total + (shoppingCart.Count * (shoppingCart.Product.DiscountPrice > 0 ? shoppingCart.Product.DiscountPrice : shoppingCart.Product.Price)));

                OrderItem orderItem = new OrderItem
                {
                    Count = shoppingCart.Count,
                    Price = ((double)(shoppingCart.Product.DiscountPrice > 0 ? shoppingCart.Product.DiscountPrice : shoppingCart.Product.Price)),
                    ProductId = shoppingCart.ProductId,
                    TotalPrice = ((double)(shoppingCart.Count * (shoppingCart.Product.DiscountPrice > 0 ? shoppingCart.Product.DiscountPrice : shoppingCart.Product.Price))),
                    CreatedAt = DateTime.UtcNow.AddHours(4)
                };

                orderItems.Add(orderItem);
            }

            Order order = new Order
            {
                Address = orderVM.Address,
                AppUserId = appUser.Id,
                City = orderVM.City,
                Country = orderVM.Country,
                TotalPrice = total,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                ZipCode = orderVM.ZipCode,
                OrderItems = orderItems
            };


            _context.ShoppingCarts.RemoveRange(shoppingCarts);
            HttpContext.Response.Cookies.Append("cart", "");
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", "home");
        }
    }
}
