using Juan_ShoesStore.Extensions;
using Juan_ShoesStore.Helpers;
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
    public class SettingController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SettingController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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

        #region Update
        public async Task<IActionResult> Update()
        {
            return View(await GetSettingsAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Setting setting)
        {
            Setting dbSetting = await GetSettingsAsync();

            if (!ModelState.IsValid) return View(dbSetting);

            if (setting.LogoImage != null)
            {
                if (!setting.LogoImage.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("LogoImage", "File type of logo must be .png");
                    return View(dbSetting);
                }

                if (!setting.LogoImage.CheckFileSize(5))
                {
                    ModelState.AddModelError("LogoImage", "Max size of logo must be 5 KB");
                    return View(dbSetting);
                }

                Helper.DeleteFile(_env, dbSetting.Logo, "assets", "images", "logo");
                dbSetting.Logo = setting.LogoImage.CreateFile(_env, "assets", "images", "logo");
            }

            dbSetting.Offer = setting.Offer;
            dbSetting.Address = setting.Address;
            dbSetting.Email1 = setting.Email1;
            dbSetting.Email2 = setting.Email2;
            dbSetting.Phone1 = setting.Phone1;
            dbSetting.Phone2 = setting.Phone2;
            dbSetting.Facebook = setting.Facebook;
            dbSetting.Instagram = setting.Instagram;
            dbSetting.Twitter = setting.Twitter;

            dbSetting.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        #endregion
    }
}
