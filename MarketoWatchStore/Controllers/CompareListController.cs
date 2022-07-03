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

            return View(compareListVMs);
        }

        public async Task<IActionResult> AddToCompare(int? id)
        {
            if (id is null) return RedirectToAction("error400", "home");

            Product product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Display)
                .Include(p => p.PowerSource)
                .Include(p => p.SpecialType)
                .Include(p => p.ProductImages)
                .Include(p => p.Reviews)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product is null) return RedirectToAction("error404", "home");

            string cookieCompare = HttpContext.Request.Cookies["compare"];

            List<CompareListVM> compareListVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieCompare))
            {
                compareListVMs = JsonConvert.DeserializeObject<List<CompareListVM>>(cookieCompare);

                if (compareListVMs.Any(b => b.ProductId == id))
                {
                    return RedirectToAction("index", "comparelist");
                }
                else
                {
                    compareListVMs.Add(new CompareListVM
                    {
                        ProductId = (int)id
                    });
                }
            }
            else
            {
                compareListVMs = new List<CompareListVM>();

                compareListVMs.Add(new CompareListVM
                {
                    ProductId = (int)id
                });
            }

            cookieCompare = JsonConvert.SerializeObject(compareListVMs);
            HttpContext.Response.Cookies.Append("compare", cookieCompare);

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

            return PartialView("_MiniComparePartial", compareListVMs);
        }

        public async Task<IActionResult> RemoveItem(int? id)
        {
            if (id is null) return RedirectToAction("error400", "home");

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return RedirectToAction("error404", "home");

            string cookieCompare = HttpContext.Request.Cookies["compare"];

            List<CompareListVM> compareListVMs = null;

            if (!string.IsNullOrWhiteSpace(cookieCompare))
            {
                compareListVMs = JsonConvert.DeserializeObject<List<CompareListVM>>(cookieCompare);

                CompareListVM compareListVM = compareListVMs.FirstOrDefault(p => p.ProductId == id);

                if (compareListVM is null) return RedirectToAction("error404", "home");

                compareListVMs.Remove(compareListVM);
            }
            else
            {
                return RedirectToAction("error400", "home");
            }

            cookieCompare = JsonConvert.SerializeObject(compareListVMs);
            HttpContext.Response.Cookies.Append("compare", cookieCompare);

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

            return PartialView("_CompareTablePartial", compareListVMs);
        }
    }
}
