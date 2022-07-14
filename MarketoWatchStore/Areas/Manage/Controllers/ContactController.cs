using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class ContactController : Controller
    {
        private readonly MarketoDbContext _context;
        public ContactController(MarketoDbContext context)
        {
            _context = context;
        }

        #region Method for Pagination
        private async Task<IEnumerable<Contact>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<Contact> contacts;

            switch (status)
            {
                case "active":
                    contacts = await _context.Contacts
                        .Where(c => !c.IsDeleted)
                        .OrderByDescending(c => c.CreatedAt)
                        .ToListAsync();
                    break;
                case "deleted":
                    contacts = await _context.Contacts
                        .Where(c => c.IsDeleted)
                        .OrderByDescending(c => c.CreatedAt)
                        .ToListAsync();
                    break;
                default:
                    contacts = await _context.Contacts
                        .OrderByDescending(c => c.CreatedAt)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)contacts.Count() / 5);

            return contacts.Skip((page - 1) * 5).Take(5);
        }
        #endregion

        #region Read
        public async Task<IActionResult> Index(string status = "active", int page = 1)
        {
            return View(await PaginateAsync(status, page));
        }

        public async Task<IActionResult> Detail(int? id, string status = "active", int page = 1)
        {
            if (id is null) return BadRequest();

            Contact contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);

            if (contact is null) return NotFound();

            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            return View(contact);
        }
        #endregion

        #region Delete and Restore mutual view
        public async Task<IActionResult> DeleteRestore(int? id, string status = "active", int page = 1)
        {
            if (id is null) return BadRequest();

            Contact contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);

            if (contact is null) return NotFound();

            ViewBag.Status = status;
            ViewBag.CurrentPage = page;
            ViewBag.BlogId = id;

            return View(contact);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "active", int page = 1)
        {
            if (id is null) return BadRequest();

            Contact contact = await _context.Contacts.FirstOrDefaultAsync(b => b.Id == id);

            if (contact is null) return NotFound();

            contact.IsDeleted = true;
            contact.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "active", int page = 1)
        {
            if (id is null) return BadRequest();

            Contact contact = await _context.Contacts.FirstOrDefaultAsync(b => b.Id == id);

            if (contact is null) return NotFound();

            contact.IsDeleted = false;
            contact.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
        #endregion
    }
}
