﻿using MarketoWatchStore.DAL;
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
                Slides = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Reviews)
                .Where(p => !p.IsDeleted && p.SlideImage != null && p.ShareOnHomeSlide)
                .ToListAsync(),

                Setting = await _context.Settings.FirstOrDefaultAsync(),

                ServicePolicies = await _context.ServicePolicies
                .Where(sp => !sp.IsDeleted)
                .ToListAsync(),

                Posters = await _context.Products
                .Include(p => p.Brand)
                .Where(p => !p.IsDeleted && p.PosterImage != null && p.ShareAsPoster)
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
                .ToListAsync(),

                SpecialTypes = await _context.SpecialTypes
                .Where(st => !st.IsDeleted && st.Products.Where(p => !p.IsDeleted).Count() > 0)
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

                Brands = await _context.Brands
                .Where(b => !b.IsDeleted && b.Logo != null && b.IsShared)
                .ToListAsync()
            };

            return View(homeVM);
        }

        public IActionResult Error404() => View();

        public IActionResult Error400() => View();

        public IActionResult MaintenanceMode() => View();
    }
}
