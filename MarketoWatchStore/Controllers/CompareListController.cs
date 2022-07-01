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
    public class CompareListController : Controller
    {
        private readonly MarketoDbContext _context;
        public CompareListController(MarketoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string cookieCompare = HttpContext.Request.Cookies["compare"];

            List<CompareListVM> compareListVMs = new List<CompareListVM>();

            if (!string.IsNullOrEmpty(cookieCompare))
            {
                compareListVMs = JsonConvert.DeserializeObject<List<CompareListVM>>(cookieCompare);

                foreach (CompareListVM compareListVM in compareListVMs)
                {
                    Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == compareListVM.ProductId);

                    compareListVM.Title = dbProduct.Title;
                    compareListVM.MainImage = dbProduct.MainImage;
                    compareListVM.Price = (dbProduct.DiscountPrice != null && dbProduct.DiscountPrice > 0) ? (double)dbProduct.DiscountPrice : dbProduct.Price;
                    compareListVM.Gender = dbProduct.Gender;
                    //compareListVM.Features = dbProduct.FeatureIds
                }
            }

            return View(compareListVMs);
        }
    }
}
