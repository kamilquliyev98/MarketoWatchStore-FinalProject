using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using MarketoWatchStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Services
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MarketoDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public LayoutService(IHttpContextAccessor httpContextAccessor, MarketoDbContext context, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
        }

        public async Task<Setting> GetSetting()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }

        public async Task<List<ShoppingCartVM>> GetCart()
        {
            List<ShoppingCartVM> shoppingCartVMs = new List<ShoppingCartVM>();

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

                List<ShoppingCart> shoppingCarts = await _context
                    .ShoppingCarts.Where(c => c.AppUserId == appUser.Id)
                    .ToListAsync();

                foreach (ShoppingCart shoppingCart in shoppingCarts)
                {
                    ShoppingCartVM shoppingCartVM = new ShoppingCartVM
                    {
                        Title = shoppingCart.Product.Title,
                        MainImage = shoppingCart.Product.MainImage,
                        Price = (shoppingCart.Product.DiscountPrice != null && shoppingCart.Product.DiscountPrice > 0) ? (double)shoppingCart.Product.DiscountPrice : shoppingCart.Product.Price,
                        Count = shoppingCart.Count
                    };
                    shoppingCartVMs.Add(shoppingCartVM);
                }
            }
            else
            {
                string cookieCart = _httpContextAccessor.HttpContext.Request.Cookies["cart"];

                if (!string.IsNullOrWhiteSpace(cookieCart))
                {
                    shoppingCartVMs = JsonConvert.DeserializeObject<List<ShoppingCartVM>>(cookieCart);

                    foreach (ShoppingCartVM shoppingCartVM in shoppingCartVMs)
                    {
                        Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == shoppingCartVM.ProductId);

                        shoppingCartVM.Title = dbProduct.Title;
                        shoppingCartVM.MainImage = dbProduct.MainImage;
                        shoppingCartVM.Price = (dbProduct.DiscountPrice != null && dbProduct.DiscountPrice > 0) ? (double)dbProduct.DiscountPrice : dbProduct.Price;
                    }
                }
            }

            return shoppingCartVMs;
        }

        public async Task<List<CompareListVM>> GetCompare()
        {
            string cookieCompare = _httpContextAccessor.HttpContext.Request.Cookies["compare"];

            List<CompareListVM> compareListVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieCompare))
            {
                compareListVMs = JsonConvert.DeserializeObject<List<CompareListVM>>(cookieCompare);

                foreach (CompareListVM compareListVM in compareListVMs)
                {
                    Product dbProduct = await _context.Products
                        .Include(p => p.Brand)
                        .Include(p => p.Display)
                        .Include(p => p.PowerSource)
                        .Include(p => p.SpecialType)
                        .Include(p => p.ProductImages)
                        .Include(p => p.Reviews)
                        .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                        .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                        .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                        .FirstOrDefaultAsync(p => p.Id == compareListVM.ProductId);

                    compareListVM.Title = dbProduct.Title;
                    compareListVM.MainImage = dbProduct.MainImage;
                    compareListVM.Price = (dbProduct.DiscountPrice != null && dbProduct.DiscountPrice > 0) ? (double)dbProduct.DiscountPrice : dbProduct.Price;
                    compareListVM.Gender = dbProduct.Gender;
                    compareListVM.Brand = dbProduct.Brand.Title;
                    compareListVM.Display = dbProduct.Display.Title;
                    compareListVM.PowerSource = dbProduct.PowerSource.Title;
                    compareListVM.SpecialType = dbProduct.SpecialType.Title;
                }
            }
            else
            {
                compareListVMs = new List<CompareListVM>();
            }

            return compareListVMs;
        }
    }
}
