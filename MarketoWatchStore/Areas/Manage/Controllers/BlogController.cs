using MarketoWatchStore.DAL;
using MarketoWatchStore.Extensions;
using MarketoWatchStore.Helpers;
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

            Blog blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null) return NotFound();

            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            return View(blog);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog, string status = "active", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            if (blog.Title.Length > 255)
            {
                ModelState.AddModelError("Title", "Max 255 symbols");
                return View();
            }

            if (blog.ImageFile != null)
            {
                if (!blog.ImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("ImageFile", "File content type is not image/jpeg");
                    return View();
                }

                if (!blog.ImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("ImageFile", "File size is greater than 100 KB");
                    return View();
                }

                blog.Image = blog.ImageFile.CreateFile(_env, "assets", "images", "blog");
            }
            else
            {
                ModelState.AddModelError("ImageFile", "You have to upload an image");
                return View();
            }

            blog.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Blog blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            if (blog == null) return NotFound();

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Blog blog, int? id, string status = "active", int page = 1)
        {
            if (id == null) return BadRequest();

            if (blog.Id != id) return BadRequest();

            Blog dbBlog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            if (dbBlog == null) return NotFound();

            if (!ModelState.IsValid) return View(dbBlog);

            if (blog.Title.Length > 255)
            {
                ModelState.AddModelError("Title", "Max 255 symbols");
                return View(dbBlog);
            }

            if (blog.ImageFile != null)
            {
                if (!blog.ImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("ImageFile", "File content type is not image/jpeg");
                    return View(dbBlog);
                }

                if (!blog.ImageFile.CheckFileSize(100))
                {
                    ModelState.AddModelError("ImageFile", "File size is greater than 100 KB");
                    return View(dbBlog);
                }

                Helper.DeleteFile(_env, dbBlog.Image, "assets", "images", "blog");
                dbBlog.Image = blog.ImageFile.CreateFile(_env, "assets", "images", "blog");
            }

            dbBlog.Title = blog.Title;
            dbBlog.Content = blog.Content;

            dbBlog.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
        #endregion

        #region Delete and Restore mutual view
        public async Task<IActionResult> DeleteRestore(int? id, string status = "active", int page = 1)
        {
            if (id == null) return BadRequest();

            Blog blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null) return NotFound();

            ViewBag.Status = status;
            ViewBag.CurrentPage = page;
            ViewBag.BlogId = id;

            return View(blog);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "active", int page = 1)
        {
            if (id == null) return BadRequest();

            Blog blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null) return NotFound();

            blog.IsDeleted = true;
            blog.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "active", int page = 1)
        {
            if (id == null) return BadRequest();

            Blog blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null) return NotFound();

            blog.IsDeleted = false;
            blog.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }
        #endregion
    }
}
