using MarketoWatchStore.DAL;
using MarketoWatchStore.ViewModels;
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
        public ContactController(MarketoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ContactVM contactVM = new ContactVM
            {
                Setting = await _context.Settings.FirstOrDefaultAsync()
            };

            return View(contactVM);
        }
    }
}
