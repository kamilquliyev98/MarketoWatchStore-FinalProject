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
    public class ServicePolicyController : Controller
    {
        private readonly MarketoDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ServicePolicyController(MarketoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Method for Pagination
        private async Task<IEnumerable<ServicePolicy>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<ServicePolicy> servicePolicies;

            switch (status)
            {
                case "active":
                    servicePolicies = await _context.ServicePolicies
                        .Where(sp => !sp.IsDeleted)
                        .OrderByDescending(sp => sp.Id)
                        .ToListAsync();
                    break;
                case "deleted":
                    servicePolicies = await _context.ServicePolicies
                        .Where(sp => sp.IsDeleted)
                        .OrderByDescending(sp => sp.Id)
                        .ToListAsync();
                    break;
                default:
                    servicePolicies = await _context.ServicePolicies
                        .OrderByDescending(sp => sp.Id)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)servicePolicies.Count() / 5);

            return servicePolicies.Skip((page - 1) * 5).Take(5);
        }
        #endregion

        #region Read
        public async Task<IActionResult> Index(string status = "all", int page = 1)
        {
            return View(await PaginateAsync(status, page));
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicePolicy servicePolicy, string status = "all", int page = 1)
        {
            if (!ModelState.IsValid) return View();

            if (servicePolicy.ImageFile != null)
            {
                if (!servicePolicy.ImageFile.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("ImageFile", "File content type is not image/png");
                    return View();
                }

                if (!servicePolicy.ImageFile.CheckFileSize(5))
                {
                    ModelState.AddModelError("ImageFile", "File size is greater than 5 KB");
                    return View();
                }

                servicePolicy.Image = servicePolicy.ImageFile.CreateFile(_env, "assets", "images", "service-policies");
            }
            else
            {
                ModelState.AddModelError("ImageFile", "This Field is Required");
                return View();
            }

            servicePolicy.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.ServicePolicies.AddAsync(servicePolicy);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            ServicePolicy servicePolicy = await _context.ServicePolicies.FirstOrDefaultAsync(sp => sp.Id == id && !sp.IsDeleted);

            if (servicePolicy == null) return NotFound();

            return View(servicePolicy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ServicePolicy servicePolicy, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            if (id != servicePolicy.Id) return BadRequest();

            ServicePolicy dbServicePolicy = await _context.ServicePolicies.FirstOrDefaultAsync(sp => sp.Id == id && !sp.IsDeleted);
            if (dbServicePolicy == null) return NotFound();

            if (!ModelState.IsValid) return View(dbServicePolicy);

            if (servicePolicy.ImageFile != null)
            {
                if (!servicePolicy.ImageFile.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("ImageFile", "File content type is not image/png");
                    return View(dbServicePolicy);
                }

                if (!servicePolicy.ImageFile.CheckFileSize(5))
                {
                    ModelState.AddModelError("ImageFile", "File size is greater than 5 KB");
                    return View(dbServicePolicy);
                }

                Helper.DeleteFile(_env, dbServicePolicy.Image, "assets", "images", "service-policies");
                dbServicePolicy.Image = servicePolicy.ImageFile.CreateFile(_env, "assets", "images", "service-policies");
            }

            dbServicePolicy.Title = servicePolicy.Title;
            dbServicePolicy.Description = servicePolicy.Description;

            dbServicePolicy.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = status, page = page });
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            ServicePolicy dbServicePolicy = await _context.ServicePolicies.FirstOrDefaultAsync(sp => sp.Id == id && !sp.IsDeleted);

            if (dbServicePolicy == null) return NotFound();

            dbServicePolicy.IsDeleted = true;
            dbServicePolicy.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_ServicePoliciesTablePartial", await PaginateAsync(status, page));
        }
        #endregion

        #region Restore
        public async Task<IActionResult> Restore(int? id, string status = "all", int page = 1)
        {
            if (id == null) return BadRequest();

            ServicePolicy dbServicePolicy = await _context.ServicePolicies.FirstOrDefaultAsync(sp => sp.Id == id && sp.IsDeleted);

            if (dbServicePolicy == null) return NotFound();

            dbServicePolicy.IsDeleted = false;
            dbServicePolicy.RestoredAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_ServicePoliciesTablePartial", await PaginateAsync(status, page));
        }
        #endregion
    }
}
