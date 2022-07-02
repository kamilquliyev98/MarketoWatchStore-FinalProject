using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class BlogController : Controller
    {
        private readonly MarketoDbContext _context;
        public BlogController(MarketoDbContext context)
        {
            _context = context;
        }

        #region Method for Pagination
        private async Task<IEnumerable<Blog>> PaginateAsync(int page)
        {
            ViewBag.CurrentPage = page;

            IEnumerable<Blog> blogs = await _context.Blogs
                .Where(b => !b.IsDeleted)
                .OrderByDescending(b => b.Id)
                .ToListAsync();

            ViewBag.PageCount = Math.Ceiling((double)blogs.Count() / 6);

            return blogs.Skip((page - 1) * 6).Take(6);
        }
        #endregion

        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await PaginateAsync(page));
        }

        public async Task<IActionResult> Blog(int? id)
        {
            if (id is null) return BadRequest();

            Blog blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            if (blog is null) return NotFound();

            return View(blog);
        }
    }
}
