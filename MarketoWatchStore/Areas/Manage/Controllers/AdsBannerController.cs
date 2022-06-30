using MarketoWatchStore.DAL;
using MarketoWatchStore.Extensions;
using MarketoWatchStore.Helpers;
using MarketoWatchStore.Models;
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
    public class AdsBannerController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AdsBannerController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<AdsBanner>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<AdsBanner> adsBanners;

            switch (status)
            {
                case "active":
                    adsBanners = await _context.AdsBanners
                        .Where(b => !b.IsDeleted)
                        .OrderByDescending(b => b.Id)
                        .ToListAsync();
                    break;
                case "deleted":
                    adsBanners = await _context.AdsBanners
                        .Where(b => b.IsDeleted)
                        .OrderByDescending(b => b.Id)
                        .ToListAsync();
                    break;
                default:
                    adsBanners = await _context.AdsBanners
                        .OrderByDescending(b => b.Id)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)adsBanners.Count() / 5);

            return adsBanners.Skip((page - 1) * 5).Take(5);
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
        public async Task<IActionResult> Create(AdsBanner adsBanner, string status = "all", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            if (adsBanner.Title.Length > 80)
            {
                ModelState.AddModelError("Title", "Max: 80 symbols");
                return View();
            }

            if (adsBanner.Text.Length > 255)
            {
                ModelState.AddModelError("Text", "Max: 255 symbols");
                return View();
            }

            if (adsBanner.ImageFile != null)
            {
                if (!adsBanner.ImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("ImageFile", "File content type is not image/jpeg");
                    return View();
                }

                if (!adsBanner.ImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("ImageFile", "File size is greater than 100 KB");
                    return View();
                }

                adsBanner.Image = adsBanner.ImageFile.CreateFile(_env, "assets", "images", "banner");
            }
            else
            {
                ModelState.AddModelError("ImageFile", "You have to upload an image.");
                return View();
            }

            adsBanner.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.AdsBanners.AddAsync(adsBanner);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            AdsBanner adsBanner = await _context.AdsBanners.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            if (adsBanner == null) return NotFound();

            return View(adsBanner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, AdsBanner adsBanner, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            if (id != adsBanner.Id) return BadRequest();

            AdsBanner dbAdsBanner = await _context.AdsBanners.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
            if (dbAdsBanner == null) return NotFound();

            if (!ModelState.IsValid) return View(dbAdsBanner);

            if (adsBanner.Title.Length > 80)
            {
                ModelState.AddModelError("Title", "Max: 80 symbols");
                return View();
            }

            if (adsBanner.Text.Length > 255)
            {
                ModelState.AddModelError("Text", "Max: 255 symbols");
                return View();
            }

            if (adsBanner.ImageFile != null)
            {
                if (!adsBanner.ImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("ImageFile", "File content type is not image/jpeg");
                    return View(dbAdsBanner);
                }

                if (!adsBanner.ImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("ImageFile", "File size is greater than 100 KB");
                    return View(dbAdsBanner);
                }

                Helper.DeleteFile(_env, dbAdsBanner.Image, "assets", "images", "banner");
                dbAdsBanner.Image = adsBanner.ImageFile.CreateFile(_env, "assets", "images", "banner");
            }

            dbAdsBanner.Title = adsBanner.Title;
            dbAdsBanner.Text = adsBanner.Text;
            dbAdsBanner.AdsUrl = adsBanner.AdsUrl;
            dbAdsBanner.IsShared = adsBanner.IsShared;

            dbAdsBanner.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion
    }
}
