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
    public class DisplayController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public DisplayController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<Display>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<Display> displays;

            switch (status)
            {
                case "active":
                    displays = await _context.Displays
                        .Include(d => d.Products)
                        .Where(d => !d.IsDeleted)
                        .OrderBy(d => d.Title)
                        .ToListAsync();
                    break;
                case "deleted":
                    displays = await _context.Displays
                        .Include(d => d.Products)
                        .Where(d => d.IsDeleted)
                        .OrderBy(d => d.Title)
                        .ToListAsync();
                    break;
                default:
                    displays = await _context.Displays
                        .Include(d => d.Products)
                        .OrderBy(d => d.Title)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)displays.Count() / 5);

            return displays.Skip((page - 1) * 5).Take(5);
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
        public async Task<IActionResult> Create(Display display, string status = "all", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            if (await _context.Displays.AnyAsync(d => d.Title == display.Title))
            {
                ModelState.AddModelError("Title", "Given display name is already exists.");
                return View(display);
            }

            display.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Displays.AddAsync(display);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();

            Display display = await _context.Displays.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

            if (display is null) return NotFound();

            return View(display);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Display display, string status = "all", int page = 1)
        {
            if (id is null) return BadRequest();

            if (id != display.Id) return BadRequest();

            Display dbDisplay = await _context.Displays.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
            if (dbDisplay is null) return NotFound();

            if (!ModelState.IsValid) return View(display);

            if (await _context.Displays.AnyAsync(d => d.Id != display.Id && d.Title == display.Title))
            {
                ModelState.AddModelError("Title", "Given display name is already exists.");
                return View(display);
            }

            dbDisplay.Title = display.Title;

            dbDisplay.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "all", int page = 1)
        {
            if (id is null) return BadRequest();

            Display dbDisplay = await _context.Displays.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

            if (dbDisplay is null) return NotFound();

            dbDisplay.IsDeleted = true;
            dbDisplay.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_DisplaysTablePartial", await PaginateAsync(status, page));
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "all", int page = 1)
        {
            if (id is null) return BadRequest();

            Display dbDisplay = await _context.Displays.FirstOrDefaultAsync(d => d.Id == id && d.IsDeleted);

            if (dbDisplay is null) return NotFound();

            dbDisplay.IsDeleted = false;
            dbDisplay.RestoredAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_DisplaysTablePartial", await PaginateAsync(status, page));
        }
        #endregion
    }
}
