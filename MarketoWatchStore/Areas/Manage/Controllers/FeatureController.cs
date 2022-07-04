using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class FeatureController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public FeatureController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<Feature>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<Feature> features;

            switch (status)
            {
                case "active":
                    features = await _context.Features
                        .Include(f => f.ProductFeatures).ThenInclude(f => f.Product)
                        .Where(f => !f.IsDeleted)
                        .OrderBy(f => f.Title)
                        .ToListAsync();
                    break;
                case "deleted":
                    features = await _context.Features
                        .Include(f => f.ProductFeatures).ThenInclude(f => f.Product)
                        .Where(f => f.IsDeleted)
                        .OrderBy(f => f.Title)
                        .ToListAsync();
                    break;
                default:
                    features = await _context.Features
                        .Include(f => f.ProductFeatures).ThenInclude(f => f.Product)
                        .OrderBy(f => f.Title)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)features.Count() / 5);

            return features.Skip((page - 1) * 5).Take(5);
        }
        #endregion

        #region Read
        public async Task<IActionResult> Index(string status = "all", int page = 1)
        {
            return View(await PaginateAsync(status, page));
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Feature feature, string status = "all", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            if (await _context.Features.AnyAsync(f => f.Title == feature.Title))
            {
                ModelState.AddModelError("Title", "Given feature name is already exists.");
                return View(feature);
            }

            feature.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Features.AddAsync(feature);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();

            Feature feature = await _context.Features.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);

            if (feature is null) return NotFound();

            return View(feature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Feature feature, string status = "all", int page = 1)
        {
            if (id is null) return BadRequest();

            if (id != feature.Id) return BadRequest();

            Feature dbFeature = await _context.Features.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (dbFeature is null) return NotFound();

            if (!ModelState.IsValid) return View(feature);

            if (await _context.Features.AnyAsync(f => f.Id != feature.Id && f.Title == feature.Title))
            {
                ModelState.AddModelError("Title", "Given feature name is already exists.");
                return View(feature);
            }

            dbFeature.Title = feature.Title;

            dbFeature.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "all", int page = 1)
        {
            if (id is null) return BadRequest();

            Feature dbFeature = await _context.Features.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);

            if (dbFeature is null) return NotFound();

            dbFeature.IsDeleted = true;
            dbFeature.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_FeaturesTablePartial", await PaginateAsync(status, page));
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "all", int page = 1)
        {
            if (id is null) return BadRequest();

            Feature dbFeature = await _context.Features.FirstOrDefaultAsync(f => f.Id == id && f.IsDeleted);

            if (dbFeature is null) return NotFound();

            dbFeature.IsDeleted = false;
            dbFeature.RestoredAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_FeaturesTablePartial", await PaginateAsync(status, page));
        }
        #endregion
    }
}
