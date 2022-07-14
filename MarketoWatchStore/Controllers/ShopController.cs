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

            if (id is null || star is null || star <= 0 || star > 5) return RedirectToAction("error400", "home");

            Review review = new Review();

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (_context.Reviews.Any(x => x.ProductId == id && x.AppUserId == appUser.Id))
                return RedirectToAction(nameof(Product), new { id });

            review.AppUserId = appUser.Id;
            review.Email = appUser.Email;
            review.Name = appUser.UserName;
            review.Star = (int)star;

            ProductVM productVM = new ProductVM()
            {
                Product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted),
                Reviews = await _context.Reviews.Where(p => p.ProductId == id && !p.IsDeleted).ToListAsync()
            };

            if (string.IsNullOrWhiteSpace(comment) || string.IsNullOrEmpty(comment) || comment.Length > 1000)
                return RedirectToAction(nameof(Product), new { id });

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

        public async Task<IActionResult> Filter(string brands, string colors, string genders
           , string features, string powers
            //int maxPrice, int page = 1
            )
        {
            IQueryable<Product> products = _context.Products
                .Include(p => p.ProductColours)
                .Include(p => p.Brand)
                .Include(p => p.SpecialType)
                .Include(p => p.Reviews)
                .Include(p => p.ProductFeatures).ThenInclude(p=>p.Feature)
                .Include(p => p.PowerSource)
                .Where(p => !p.IsDeleted
                    && !p.Brand.IsDeleted
                    && !p.PowerSource.IsDeleted
                    )
                ;

            if (string.IsNullOrWhiteSpace(brands)
                && string.IsNullOrWhiteSpace(colors)
                && string.IsNullOrWhiteSpace(genders)
                && string.IsNullOrWhiteSpace(features)
                && string.IsNullOrWhiteSpace(powers)
                )
            {
                return PartialView("_ShopProductListPartial", await _context.Products
                    .Include(p => p.ProductColours)
                    .Include(p => p.Reviews)
                    .Include(p => p.SpecialType)
                    .Where(p => !p.IsDeleted).ToListAsync());
            }
            if (!string.IsNullOrWhiteSpace(brands))
            {
                string[] sizs = brands.Split(",");
                foreach (var s in sizs)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        products = products
                            .Where(p => p.BrandId.ToString() == s && !p.Brand.IsDeleted);
                    }

                }
            }
            if (!string.IsNullOrWhiteSpace(colors))
            {
                string[] colrs = colors.Split(",");
                foreach (var c in colrs)
                {
                    if (!string.IsNullOrWhiteSpace(c))
                    {
                        products = products
                        .Where(p => p.ProductColours.Any(p => p.ColourId.ToString() == c.ToString()));
                    }

                }
            }
            if (!string.IsNullOrWhiteSpace(genders))
            {
                string[] colrs = genders.Split(",");
                foreach (var c in colrs)
                {
                    if (!string.IsNullOrWhiteSpace(c))
                    {
                        products = products
                        .Where(p => ((int)p.Gender).ToString() == c);
                    }

                }
            }
            if (!string.IsNullOrWhiteSpace(features))
            {
                string[] colrs = features.Split(",");
                foreach (var c in colrs)
                {
                    if (!string.IsNullOrWhiteSpace(c))
                    {
                        products = products
                        .Where(p => p.ProductFeatures.Any(p => p.FeatureId.ToString() == c.ToString()));
                    }

                }
            }
            if (!string.IsNullOrWhiteSpace(powers))
            {
                string[] colrs = powers.Split(",");
                foreach (var c in colrs)
                {
                    if (!string.IsNullOrWhiteSpace(c))
                    {
                        products = products
                        .Where(p => p.PowerSourceId.ToString() == c.ToString());
                    }

                }
            }
            //if (!string.IsNullOrWhiteSpace(minPrice.ToString()))
            //{
            //    products = from p in products
            //               let produccs = p.ProductColorSizes.FirstOrDefault()
            //               where produccs.Price >= minPrice
            //               select p;
            //}
            //if (!string.IsNullOrWhiteSpace(maxPrice.ToString()))
            //{
            //    products = from p in products
            //               let produccs = p.ProductColorSizes.FirstOrDefault()
            //               where produccs.Price <= maxPrice
            //               select p;
            //}

            //ViewBag.PageIndex = page;

            //ViewBag.PageCount = Math.Ceiling((double)products.Count() / 6);
            
            return PartialView("_ShopProductListPartial", products.Where(p => !p.IsDeleted).ToList());
        }
    }
}
