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
    public class ColourController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ColourController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<Colour>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<Colour> colours;

            switch (status)
            {
                case "active":
                    colours = await _context.Colours
                        .Include(c => c.ProductColours).ThenInclude(c => c.Product)
                        .Where(c => !c.IsDeleted)
                        .OrderBy(c => c.Title)
                        .ToListAsync();
                    break;
                case "deleted":
                    colours = await _context.Colours
                        .Include(c => c.ProductColours).ThenInclude(c => c.Product)
                        .Where(c => c.IsDeleted)
                        .OrderBy(c => c.Title)
                        .ToListAsync();
                    break;
                default:
                    colours = await _context.Colours
                        .Include(c => c.ProductColours).ThenInclude(c => c.Product)
                        .OrderBy(c => c.Title)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)colours.Count() / 5);

            return colours.Skip((page - 1) * 5).Take(5);
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
        public async Task<IActionResult> Create(Colour colour, string status = "all", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            if (await _context.Colours.AnyAsync(c => c.Title == colour.Title))
            {
                ModelState.AddModelError("Title", "Given colour name is already exists.");
                return View(colour);
            }

            colour.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Colours.AddAsync(colour);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();

            Colour colour = await _context.Colours.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (colour is null) return NotFound();

            return View(colour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Colour colour, string status = "all", int page = 1)
        {
            if (id is null) return BadRequest();

            if (id != colour.Id) return BadRequest();

            Colour dbColour = await _context.Colours.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
            if (dbColour is null) return NotFound();

            if (!ModelState.IsValid) return View(colour);

            if (await _context.Colours.AnyAsync(c => c.Id != colour.Id && c.Title == colour.Title))
            {
                ModelState.AddModelError("Title", "Given colour name is already exists.");
                return View(colour);
            }

            dbColour.Title = colour.Title;

            dbColour.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "all", int page = 1)
        {
            if (id is null) return BadRequest();

            Colour dbColour = await _context.Colours.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (dbColour is null) return NotFound();

            dbColour.IsDeleted = true;
            dbColour.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_ColoursTablePartial", await PaginateAsync(status, page));
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "all", int page = 1)
        {
            if (id is null) return BadRequest();

            Colour dbColour = await _context.Colours.FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted);

            if (dbColour is null) return NotFound();

            dbColour.IsDeleted = false;
            dbColour.RestoredAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_ColoursTablePartial", await PaginateAsync(status, page));
        }
        #endregion
    }
}
