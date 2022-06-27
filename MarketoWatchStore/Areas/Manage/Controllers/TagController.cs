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
    public class TagController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TagController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<Tag>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<Tag> tags;

            switch (status)
            {
                case "active":
                    tags = await _context.Tags
                        .Include(t => t.ProductTags).ThenInclude(t => t.Product)
                        .Where(t => !t.IsDeleted)
                        .OrderBy(t => t.Title)
                        .ToListAsync();
                    break;
                case "deleted":
                    tags = await _context.Tags
                        .Include(t => t.ProductTags).ThenInclude(t => t.Product)
                        .Where(t => t.IsDeleted)
                        .OrderBy(t => t.Title)
                        .ToListAsync();
                    break;
                default:
                    tags = await _context.Tags
                        .Include(t => t.ProductTags).ThenInclude(t => t.Product)
                        .OrderBy(t => t.Title)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)tags.Count() / 5);

            return tags.Skip((page - 1) * 5).Take(5);
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
        public async Task<IActionResult> Create(Tag tag, string status = "all", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            if (await _context.Tags.AnyAsync(t => t.Title == tag.Title))
            {
                ModelState.AddModelError("Title", "Given tag name is already exists.");
                return View(tag);
            }

            if (!tag.Title.All(c => Char.IsLetterOrDigit(c)))
            {
                ModelState.AddModelError("Title", "It's wrong tag type.");
                return View(tag);
            }

            tag.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Tag tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);

            if (tag == null) return NotFound();

            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Tag tag, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            if (id != tag.Id) return BadRequest();

            Tag dbTag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
            if (dbTag == null) return NotFound();

            if (!ModelState.IsValid) return View(tag);

            if (await _context.Tags.AnyAsync(t => t.Id != tag.Id && t.Title == tag.Title))
            {
                ModelState.AddModelError("Title", "Given tag name is already exists.");
                return View(tag);
            }

            if (!tag.Title.All(c => Char.IsLetterOrDigit(c)))
            {
                ModelState.AddModelError("Title", "It's wrong tag type.");
                return View(tag);
            }

            dbTag.Title = tag.Title;

            dbTag.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            Tag dbTag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);

            if (dbTag == null) return NotFound();

            dbTag.IsDeleted = true;
            dbTag.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_TagsTablePartial", await PaginateAsync(status, page));
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            Tag dbTag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id && t.IsDeleted);

            if (dbTag == null) return NotFound();

            dbTag.IsDeleted = false;
            dbTag.RestoredAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_TagsTablePartial", await PaginateAsync(status, page));
        }
        #endregion
    }
}
