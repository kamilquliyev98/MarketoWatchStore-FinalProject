using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class OrderController : Controller
    {
        private readonly MarketoDbContext _context;
        public OrderController(MarketoDbContext context)
        {
            _context = context;
        }

        #region Method for Pagination
        private async Task<IEnumerable<Order>> PaginateAsync(string status, int page)
        {
            ViewBag.Status = status;
            ViewBag.CurrentPage = page;

            IEnumerable<Order> orders;

            switch (status)
            {
                case "pending":
                    orders = await _context.Orders
                        .Include(o => o.AppUser)
                        .Include(o => o.OrderItems)
                        .Where(o => !o.IsDeleted && (int)o.Status == 0)
                        .OrderByDescending(o => o.Id)
                        .ToListAsync();
                    break;
                case "accepted":
                    orders = await _context.Orders
                        .Include(o => o.AppUser)
                        .Include(o => o.OrderItems)
                        .Where(o => !o.IsDeleted && (int)o.Status == 1)
                        .OrderByDescending(o => o.Id)
                        .ToListAsync();
                    break;
                case "rejected":
                    orders = await _context.Orders
                        .Include(o => o.AppUser)
                        .Include(o => o.OrderItems)
                        .Where(o => !o.IsDeleted && (int)o.Status == 2)
                        .OrderByDescending(o => o.Id)
                        .ToListAsync();
                    break;
                case "delivered":
                    orders = await _context.Orders
                        .Include(o => o.AppUser)
                        .Include(o => o.OrderItems)
                        .Where(o => !o.IsDeleted && (int)o.Status == 3)
                        .OrderByDescending(o => o.Id)
                        .ToListAsync();
                    break;
                default:
                    orders = await _context.Orders
                        .Include(o => o.AppUser)
                        .Include(o => o.OrderItems)
                        .Where(o => !o.IsDeleted)
                        .OrderByDescending(o => o.Id)
                        .ToListAsync();
                    break;
            }

            ViewBag.PageCount = Math.Ceiling((double)orders.Count() / 5);

            return orders.Skip((page - 1) * 5).Take(5);
        }
        #endregion

        public async Task<IActionResult> Index(string status = "pending", int page = 1)
        {
            return View(await PaginateAsync(status, page));
        }
    }
}
