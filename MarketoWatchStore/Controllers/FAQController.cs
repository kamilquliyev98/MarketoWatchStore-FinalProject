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
    public class FAQController : Controller
    {
        private readonly MarketoDbContext _context;
        public FAQController(MarketoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            FAQVM faqVM = new FAQVM
            {
                FAQs = await _context.FAQs
                .Where(f => !f.IsDeleted && f.IsShared)
                .ToListAsync()
            };

            return View(faqVM);
        }
    }
}
