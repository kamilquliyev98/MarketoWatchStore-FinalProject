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
    public class FAQController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public FAQController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<FAQ>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<FAQ> FAQs;

            switch (status)
            {
                case "active":
                    FAQs = await _context.FAQs
                        .Where(f => !f.IsDeleted)
                        .OrderByDescending(f => f.Id)
                        .ToListAsync();
                    break;
                case "deleted":
                    FAQs = await _context.FAQs
                        .Where(f => f.IsDeleted)
                        .OrderByDescending(f => f.Id)
                        .ToListAsync();
                    break;
                default:
                    FAQs = await _context.FAQs
                        .OrderByDescending(f => f.Id)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)FAQs.Count() / 5);

            return FAQs.Skip((page - 1) * 5).Take(5);
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
        public async Task<IActionResult> Create(FAQ faq, string status = "all", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            faq.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.FAQs.AddAsync(faq);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            FAQ faq = await _context.FAQs.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);

            if (faq == null) return NotFound();

            return View(faq);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, FAQ faq, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            if (id != faq.Id) return BadRequest();

            FAQ dbFaq = await _context.FAQs.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);
            if (dbFaq == null) return NotFound();

            if (!ModelState.IsValid) return View(faq);

            dbFaq.Question = faq.Question;
            dbFaq.Answer = faq.Answer;
            dbFaq.IsShared = faq.IsShared;

            dbFaq.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            FAQ dbFaq = await _context.FAQs.FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted);

            if (dbFaq == null) return NotFound();

            dbFaq.IsDeleted = true;
            dbFaq.IsShared = false;
            dbFaq.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_FAQsTablePartial", await PaginateAsync(status, page));
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            FAQ dbFaq = await _context.FAQs.FirstOrDefaultAsync(f => f.Id == id && f.IsDeleted);

            if (dbFaq == null) return NotFound();

            dbFaq.IsDeleted = false;
            dbFaq.RestoredAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_FAQsTablePartial", await PaginateAsync(status, page));
        }
        #endregion
    }
}
