using MarketoWatchStore.DAL;
using MarketoWatchStore.Enums;
using MarketoWatchStore.Models;
using MarketoWatchStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly MarketoDbContext _context;
        public ShopController(MarketoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ShopVM shopVM = new ShopVM
            {
                Products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Display)
                .Include(p => p.PowerSource)
                .Include(p => p.SpecialType)
                .Include(p => p.ProductImages)
                .Include(p => p.Reviews)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Id)
                .ToListAsync(),

                Brands = await _context.Brands
                .Include(b => b.Products)
                .Where(b => b.Products.Where(p => !p.IsDeleted).Count() > 0)
                .OrderBy(b => b.Title)
                .ToListAsync(),

                Colours = await _context.Colours
                .Include(c => c.ProductColours).ThenInclude(c => c.Colour)
                .Where(c => c.ProductColours.Count() > 0)
                .OrderBy(c => c.Title)
                .ToListAsync(),

                Genders = (IEnumerable<GenderType>)Enum.GetValues(typeof(GenderType)),

                Features = await _context.Features
                .Include(f => f.ProductFeatures).ThenInclude(f => f.Feature)
                .Where(f => f.ProductFeatures.Count() > 0)
                .OrderBy(f => f.Title)
                .ToListAsync(),

                PowerSources = await _context.PowerSources
                .Include(ps => ps.Products)
                .Where(ps => ps.Products.Where(p => !p.IsDeleted).Count() > 0)
                .OrderBy(f => f.Title)
                .ToListAsync(),

                AdsBanners = await _context.AdsBanners
                .Where(b => !b.IsDeleted && b.IsShared)
                .OrderByDescending(b => b.Id)
                .ToListAsync()
            };

            return View(shopVM);
        }

        public async Task<IActionResult> QuickView(int? id)
        {
            if (id == null) return BadRequest();

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
                .FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id);

            if (product == null) return NotFound();

            return PartialView("_ProductQuickViewPartial", product);
        }

        public async Task<IActionResult> Product(int? id)
        {
            if (id == null) return BadRequest();

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
                .FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id);

            if (product == null) return NotFound();

            return View(product);
        }
    }
}
