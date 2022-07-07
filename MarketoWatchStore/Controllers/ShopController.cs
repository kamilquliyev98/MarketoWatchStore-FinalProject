using MarketoWatchStore.DAL;
using MarketoWatchStore.Enums;
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
    public class ShopController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ShopController(MarketoDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                .FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id);

            if (product is null) return RedirectToAction("error404", "home");

            return PartialView("_ProductQuickViewPartial", product);
        }

        public async Task<IActionResult> Product(int? id)
        {
            if (id is null) return RedirectToAction("error400", "home");

            ReviewVM shopVM = new ReviewVM
            {
                Product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Display)
                .Include(p => p.PowerSource)
                .Include(p => p.SpecialType)
                .Include(p => p.ProductImages)
                .Include(p => p.Reviews)
                .Include(p => p.ProductTags).ThenInclude(p => p.Tag)
                .Include(p => p.ProductColours).ThenInclude(p => p.Colour)
                .Include(p => p.ProductFeatures).ThenInclude(p => p.Feature)
                .FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id)
            };

            if (shopVM is null) return RedirectToAction("error404", "home");

            return View(shopVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductReview(int? id, int? star, string comment)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("login", "account");

            if (id is null || star is null || star <= 0 || star > 5) return View();

            Review review = new Review();

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);
            review.Email = appUser.Email;
            review.Name = appUser.UserName;
            review.Star = (int)star;

            ProductVM productVM = new ProductVM()
            {
                Product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted),
                Reviews = await _context.Reviews.Where(p => p.ProductId == id && !p.IsDeleted).ToListAsync()
            };

            if (string.IsNullOrWhiteSpace(comment) || string.IsNullOrEmpty(comment) || comment.Length > 1000)
                return PartialView("_AddReviewForProductPartial", productVM);

            review.Comment = comment.Trim();
            review.ProductId = (int)id;
            review.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            productVM = new ProductVM()
            {
                Product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id),
                Reviews = await _context.Reviews.Where(p => p.ProductId == id && !p.IsDeleted).ToListAsync()
            };

            return RedirectToAction(nameof(Product), new { id });
        }
    }
}
