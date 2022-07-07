using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using MarketoWatchStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class ContactController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ContactController(MarketoDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ContactVM contactVM = new ContactVM
            {
                Setting = await _context.Settings.FirstOrDefaultAsync(),

                Contact = await _context.Contacts.FirstOrDefaultAsync()
            };

            return View(contactVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactMessage(Contact contact, string message)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("login", "account");

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name && !u.IsAdmin);

            if (string.IsNullOrWhiteSpace(contact.FirstName))
            {
                ModelState.AddModelError("FirstName", "This field is required.");
                return View();
            }

            if (contact.FirstName.Length > 255)
            {
                ModelState.AddModelError("FirstName", "Max: 255 characters");
                return View();
            }

            if (string.IsNullOrWhiteSpace(contact.LastName))
            {
                ModelState.AddModelError("LastName", "This field is required.");
                return View();
            }

            if (contact.LastName.Length > 255)
            {
                ModelState.AddModelError("LastName", "Max: 255 characters");
                return View();
            }

            if (string.IsNullOrWhiteSpace(contact.Email))
            {
                ModelState.AddModelError("Email", "This field is required.");
                return View();
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                ModelState.AddModelError("Message", "This field is required.");
                return View();
            }

            if (contact.Message.Length > 1000)
            {
                ModelState.AddModelError("LastName", "Max: 1000 characters");
                return View();
            }

            contact.Message = message;
            contact.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
