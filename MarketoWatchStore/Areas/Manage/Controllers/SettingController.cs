using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly MarketoDbContext _context;
        public SettingController(MarketoDbContext context)
        {
            _context = context;
        }

        #region Get Settings Method
        private async Task<Setting> GetSettingsAsync()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }
        #endregion

        #region Read
        public async Task<IActionResult> Index()
        {
            return View(await GetSettingsAsync());
        }
        #endregion
    }
}
