using MarketoWatchStore.DAL;
using MarketoWatchStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MarketoDbContext _context;
        public HomeController(MarketoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                ServicePolicies = await _context.ServicePolicies
                .Where(sp => !sp.IsDeleted)
                .ToListAsync(),

                SpecialTypes = await _context.SpecialTypes
                .Where(st => !st.IsDeleted && st.Products.Count() > 0)
                .ToListAsync(),

                Brands = await _context.Brands
                .Where(b => !b.IsDeleted && b.Logo != null && b.IsShared)
                .ToListAsync(),

                LatestProducts = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Display)
                .Include(p => p.PowerSource)
                .Include(p => p.SpecialType)
                .Include(p => p.ProductImages)
                .Include(p => p.Reviews)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                .Where(p => !p.IsDeleted && !p.IsNewArrival)
                .OrderByDescending(p => p.Id)
                .Take(10)
                .ToListAsync(),

                NewArrival = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Display)
                .Include(p => p.PowerSource)
                .Include(p => p.SpecialType)
                .Include(p => p.ProductImages)
                .Include(p => p.Reviews)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                .Where(p => !p.IsDeleted && p.IsNewArrival)
                .ToListAsync()
            };

            return View(homeVM);
        }
    }
}
