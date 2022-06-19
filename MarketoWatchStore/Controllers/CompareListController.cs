using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class CompareListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
