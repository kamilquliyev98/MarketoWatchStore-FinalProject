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
    public class SpecialTypeController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SpecialTypeController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<SpecialType>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<SpecialType> specialTypes;

            switch (status)
            {
                case "active":
                    specialTypes = await _context.SpecialTypes
                        .Include(st => st.Products)
                        .Where(st => !st.IsDeleted)
                        .OrderByDescending(st => st.Id)
                        .ToListAsync();
                    break;
                case "deleted":
                    specialTypes = await _context.SpecialTypes
                        .Include(st => st.Products)
                        .Where(st => st.IsDeleted)
                        .OrderByDescending(st => st.Id)
                        .ToListAsync();
                    break;
                default:
                    specialTypes = await _context.SpecialTypes
                        .Include(st => st.Products)
                        .OrderByDescending(st => st.Id)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)specialTypes.Count() / 5);

            return specialTypes.Skip((page - 1) * 5).Take(5);
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
        public async Task<IActionResult> Create(SpecialType specialType, string status = "all", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            if (specialType.ImageFile != null)
            {
                if (!specialType.ImageFile.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("ImageFile", "File content type is not image/png");
                    return View();
                }

                if (!specialType.ImageFile.CheckFileSize(20))
                {
                    ModelState.AddModelError("ImageFile", "File size is greater than 20 KB");
                    return View();
                }

                specialType.Image = specialType.ImageFile.CreateFile(_env, "assets", "images", "special-types");
            }
            else
            {
                ModelState.AddModelError("ImageFile", "You have to upload an image.");
                return View();
            }

            specialType.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SpecialTypes.AddAsync(specialType);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            SpecialType specialType = await _context.SpecialTypes.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            if (specialType == null) return NotFound();

            return View(specialType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SpecialType specialType, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            if (id != specialType.Id) return BadRequest();

            SpecialType dbSpecialType = await _context.SpecialTypes.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
            if (dbSpecialType == null) return NotFound();

            if (!ModelState.IsValid) return View(dbSpecialType);

            if (specialType.ImageFile != null)
            {
                if (!specialType.ImageFile.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("ImageFile", "File content type is not image/png");
                    return View(dbSpecialType);
                }

                if (!specialType.ImageFile.CheckFileSize(20))
                {
                    ModelState.AddModelError("ImageFile", "File size is greater than 20 KB");
                    return View(dbSpecialType);
                }

                Helper.DeleteFile(_env, dbSpecialType.Image, "assets", "images", "special-types");
                dbSpecialType.Image = specialType.ImageFile.CreateFile(_env, "assets", "images", "special-types");
            }

            dbSpecialType.Title = specialType.Title;
            dbSpecialType.IsShared = specialType.IsShared;

            dbSpecialType.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            SpecialType dbSpecialType = await _context.SpecialTypes.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            if (dbSpecialType == null) return NotFound();

            dbSpecialType.IsDeleted = true;
            dbSpecialType.IsShared = false;
            dbSpecialType.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_SpecialTypesTablePartial", await PaginateAsync(status, page));
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            SpecialType dbSpecialType = await _context.SpecialTypes.FirstOrDefaultAsync(b => b.Id == id && b.IsDeleted);

            if (dbSpecialType == null) return NotFound();

            dbSpecialType.IsDeleted = false;
            dbSpecialType.RestoredAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_SpecialTypesTablePartial", await PaginateAsync(status, page));
        }
        #endregion
    }
}
