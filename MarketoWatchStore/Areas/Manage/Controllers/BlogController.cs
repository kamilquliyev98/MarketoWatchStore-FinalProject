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
    public class BlogController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<Blog>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<Blog> blogs;

            switch (status)
            {
                case "active":
                    blogs = await _context.Blogs
                        .Where(b => !b.IsDeleted)
                        .OrderByDescending(b => b.Id)
                        .ToListAsync();
                    break;
                case "deleted":
                    blogs = await _context.Blogs
                        .Where(b => b.IsDeleted)
                        .OrderByDescending(b => b.Id)
                        .ToListAsync();
                    break;
                default:
                    blogs = await _context.Blogs
                        .OrderByDescending(b => b.Id)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)blogs.Count() / 5);

            return blogs.Skip((page - 1) * 5).Take(5);
        }
        #endregion

        #region Read
        public async Task<IActionResult> Index(string status = "all", int page = 1)
        {
            return View(await PaginateAsync(status, page));
        }

        public async Task<IActionResult> Detail(int? id, string status = "active", int page = 1)
        {
            if (id == null) return BadRequest();

            Blog blog = await _context.Blogs
                .FirstOrDefaultAsync(p => p.Id == id);

            if (blog == null) return NotFound();

            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            return View(blog);
        }
        #endregion
    }
}
