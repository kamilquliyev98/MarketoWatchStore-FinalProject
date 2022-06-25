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
    public class BrandController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BrandController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<Brand>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<Brand> brands;

            switch (status)
            {
                case "active":
                    brands = await _context.Brands
                        .Include(b => b.Products)
                        .Where(b => !b.IsDeleted)
                        .OrderBy(b => b.Title)
                        .ToListAsync();
                    break;
                case "deleted":
                    brands = await _context.Brands
                        .Include(b => b.Products)
                        .Where(b => b.IsDeleted)
                        .OrderBy(b => b.Title)
                        .ToListAsync();
                    break;
                default:
                    brands = await _context.Brands
                        .Include(b => b.Products)
                        .OrderBy(b => b.Title)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)brands.Count() / 5);

            return brands.Skip((page - 1) * 5).Take(5);
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
        public async Task<IActionResult> Create(Brand brand, string status = "all", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            if (brand.ImageFile != null)
            {
                if (!brand.ImageFile.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("ImageFile", "Content type must be .png");
                    return View();
                }

                if (!brand.ImageFile.CheckFileSize(20))
                {
                    ModelState.AddModelError("ImageFile", "Max file size: 20 KB");
                    return View();
                }

                brand.Logo = brand.ImageFile.CreateFile(_env, "assets", "images", "brand");
            }
            else
            {
                if (brand.IsShared == true)
                {
                    ModelState.AddModelError("IsShared", "You can't share without image.");
                    return View();
                }
            }

            brand.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Brand brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            if (brand == null) return NotFound();

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Brand brand, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            if (id != brand.Id) return BadRequest();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
            if (dbBrand == null) return NotFound();

            if (!ModelState.IsValid) return View(dbBrand);

            if (brand.ImageFile != null)
            {
                if (!brand.ImageFile.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("ImageFile", "Content type must be .png");
                    return View(dbBrand);
                }

                if (!brand.ImageFile.CheckFileSize(20))
                {
                    ModelState.AddModelError("ImageFile", "Max file size: 20 KB");
                    return View(dbBrand);
                }

                if (dbBrand.Logo != null)
                {
                    Helper.DeleteFile(_env, dbBrand.Logo, "assets", "images", "brand");
                }

                dbBrand.Logo = brand.ImageFile.CreateFile(_env, "assets", "images", "brand");
            }

            if (dbBrand.Logo == null && brand.Logo == null && brand.IsShared == true)
            {
                ModelState.AddModelError("IsShared", "You can't share without image.");
                return View();
            }

            dbBrand.Title = brand.Title;
            dbBrand.Website = brand.Website;
            dbBrand.IsShared = brand.IsShared;

            dbBrand.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            if (dbBrand == null) return NotFound();

            dbBrand.IsDeleted = true;
            dbBrand.IsShared = false;
            dbBrand.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_BrandsTablePartial", await PaginateAsync(status, page));
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id && b.IsDeleted);

            if (dbBrand == null) return NotFound();

            dbBrand.IsDeleted = false;
            dbBrand.RestoredAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_BrandsTablePartial", await PaginateAsync(status, page));
        }
        #endregion
    }
}
