using MarketoWatchStore.DAL;
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
    public class PowerSourceController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public PowerSourceController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<PowerSource>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<PowerSource> powerSources;

            switch (status)
            {
                case "active":
                    powerSources = await _context.PowerSources
                        .Include(ps => ps.Products)
                        .Where(ps => !ps.IsDeleted)
                        .OrderBy(ps => ps.Title)
                        .ToListAsync();
                    break;
                case "deleted":
                    powerSources = await _context.PowerSources
                        .Include(ps => ps.Products)
                        .Where(ps => ps.IsDeleted)
                        .OrderBy(ps => ps.Title)
                        .ToListAsync();
                    break;
                default:
                    powerSources = await _context.PowerSources
                        .Include(ps => ps.Products)
                        .OrderBy(ps => ps.Title)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)powerSources.Count() / 5);

            return powerSources.Skip((page - 1) * 5).Take(5);
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
        public async Task<IActionResult> Create(PowerSource powerSource, string status = "all", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            if (await _context.PowerSources.AnyAsync(ps => ps.Title == powerSource.Title))
            {
                ModelState.AddModelError("Title", "Given power source name is already exists.");
                return View(powerSource);
            }

            powerSource.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.PowerSources.AddAsync(powerSource);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            PowerSource powerSource = await _context.PowerSources.FirstOrDefaultAsync(ps => ps.Id == id && !ps.IsDeleted);

            if (powerSource == null) return NotFound();

            return View(powerSource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, PowerSource powerSource, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            if (id != powerSource.Id) return BadRequest();

            PowerSource dbPowerSource = await _context.PowerSources.FirstOrDefaultAsync(ps => ps.Id == id && !ps.IsDeleted);
            if (dbPowerSource == null) return NotFound();

            if (!ModelState.IsValid) return View(powerSource);

            if (await _context.PowerSources.AnyAsync(ps => ps.Id != powerSource.Id && ps.Title == powerSource.Title))
            {
                ModelState.AddModelError("Title", "Given power source name is already exists.");
                return View(powerSource);
            }

            dbPowerSource.Title = powerSource.Title;

            dbPowerSource.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            PowerSource dbPowerSource = await _context.PowerSources.FirstOrDefaultAsync(ps => ps.Id == id && !ps.IsDeleted);

            if (dbPowerSource == null) return NotFound();

            dbPowerSource.IsDeleted = true;
            dbPowerSource.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_PowerSourcesTablePartial", await PaginateAsync(status, page));
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            PowerSource dbPowerSource = await _context.PowerSources.FirstOrDefaultAsync(ps => ps.Id == id && ps.IsDeleted);

            if (dbPowerSource == null) return NotFound();

            dbPowerSource.IsDeleted = false;
            dbPowerSource.RestoredAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_PowerSourcesTablePartial", await PaginateAsync(status, page));
        }
        #endregion
    }
}
