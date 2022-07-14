using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class UserController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UserController(MarketoDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        #region Method for Pagination
        private async Task<IEnumerable<AppUser>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;
           
            IEnumerable<AppUser> appUsers;

            switch (status)
            {
                case "active":
                    appUsers = await _context.AppUsers
                        .Where(c => !c.IsDeleted )
                        .OrderByDescending(c => c.IsAdmin)
                        .ToListAsync();
                    break;
                case "deleted":
                    appUsers = await _context.AppUsers
                        .Where(c => c.IsDeleted)
                        .OrderByDescending(c => c.IsAdmin)
                        .ToListAsync();
                    break;
                case "blocked":
                    appUsers = await _context.AppUsers
                        .Where(c => c.IsBlocked)
                        .OrderByDescending(c => c.IsAdmin)
                        .ToListAsync();
                    break;
                default:
                    appUsers = await _context.AppUsers
                        .OrderByDescending(c => c.IsAdmin)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)appUsers.Count() / 10);

            return appUsers.Skip((page - 1) * 10).Take(10);
        }
        #endregion

        public async Task<IActionResult> Index(string status = "all", int page = 1)
        {
            return View(await PaginateAsync(status, page));
        }
    }
}
