using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly MarketoDbContext _context;
        public SearchController(MarketoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string key, int page = 1)
        {
            if (string.IsNullOrEmpty(key))
            {
                return BadRequest();
            }
            else
            {
                key = key.ToLower().Trim();
            }

            ViewBag.CurrentPage = page;
            ViewBag.Key = key;

            IEnumerable<Product> products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Display)
                .Include(p => p.PowerSource)
                .Include(p => p.SpecialType)
                .Include(p => p.ProductImages)
                .Include(p => p.Reviews)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                .Where(p => (!p.IsDeleted) && (p.Title.ToLower().Contains(key)
                || p.Description.ToLower().Contains(key)
                || p.Price.ToString().Contains(key)
                || p.DiscountPrice.ToString().Contains(key)
                || p.Brand.Title.ToLower().Contains(key)
                || p.Display.Title.ToLower().Contains(key)
                || p.PowerSource.Title.ToLower().Contains(key)
                || p.SpecialType.Title.ToLower().Contains(key)
                || p.ProductFeatures.Any(p => p.Feature.Title.ToLower().Contains(key))
                || p.ProductTags.Any(p => p.Tag.Title.ToLower().Contains(key))
                || p.ProductColours.Any(p => p.Colour.Title.ToLower().Contains(key))
                ))
                .OrderByDescending(b => b.Id)
                .ToListAsync();

            ViewBag.ProductCount = products.Count();
            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 8);

            return View(products.Skip((page - 1) * 8).Take(8));
        }
    }
}
