﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            // Temporarily
            return RedirectToAction("maintenancemode", "home");

            return View();
        }
    }
}
