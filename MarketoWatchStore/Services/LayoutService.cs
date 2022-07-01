using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using MarketoWatchStore.ViewModels;
using Microsoft.AspNetCore.Http;
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
        public LayoutService(IHttpContextAccessor httpContextAccessor, MarketoDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<Setting> GetSetting()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }

        public async Task<List<ShoppingCartVM>> GetCart()
        {
            string cookieCart = _httpContextAccessor.HttpContext.Request.Cookies["cart"];

            List<ShoppingCartVM> shoppingCartVMs = null;
            double totalPrice = 0;

            if (!string.IsNullOrEmpty(cookieCart))
            {
                shoppingCartVMs = JsonConvert.DeserializeObject<List<ShoppingCartVM>>(cookieCart);

                foreach (ShoppingCartVM shoppingCartVM in shoppingCartVMs)
                {
                    Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == shoppingCartVM.ProductId);

                    shoppingCartVM.Title = dbProduct.Title;
                    shoppingCartVM.MainImage = dbProduct.MainImage;
                    shoppingCartVM.Price = (dbProduct.DiscountPrice != null && dbProduct.DiscountPrice > 0) ? (double)dbProduct.DiscountPrice : dbProduct.Price;
                    totalPrice = totalPrice + shoppingCartVM.Price;
                }
            }
            else
            {
                shoppingCartVMs = new List<ShoppingCartVM>();
            }

            return shoppingCartVMs;
        }
    }
}
