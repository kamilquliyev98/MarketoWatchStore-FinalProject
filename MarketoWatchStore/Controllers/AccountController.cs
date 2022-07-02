using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using MarketoWatchStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly MarketoDbContext _context;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, MarketoDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = new AppUser
            {
                FullName = registerVM.Fullname,
                Email = registerVM.Email,
                UserName = registerVM.Username,
                IsAdmin = true
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View();
            }

            await _userManager.AddToRoleAsync(appUser, "Customer");

            await _signInManager.SignInAsync(appUser, true);

            //return Json(new { status = 200 });

            return RedirectToAction("index", "home");
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == loginVM.Email.ToUpperInvariant() && !u.IsAdmin);

            if (appUser is null)
            {
                ModelState.AddModelError("", "Email or Password is incorrect.");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is incorrect.");
                return View();
            }

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Account has been blocked. Try again later.");
                return View();
            }

            string cookieCart = HttpContext.Request.Cookies["cart"];

            if (!string.IsNullOrWhiteSpace(cookieCart))
            {
                List<ShoppingCartVM> shoppingCartVMs = JsonConvert.DeserializeObject<List<ShoppingCartVM>>(cookieCart);

                List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();

                List<ShoppingCart> existShoppingCart = await _context.ShoppingCarts.Where(b => b.AppUserId == appUser.Id).ToListAsync();

                foreach (ShoppingCartVM shoppingCartVM in shoppingCartVMs)
                {
                    if (existShoppingCart.Any(b => b.ProductId == shoppingCartVM.ProductId))
                    {
                        existShoppingCart.Find(b => b.ProductId == shoppingCartVM.ProductId).Count = shoppingCartVM.Count;
                    }
                    else
                    {
                        //ShoppingCartVM shoppingCartVM = new ShoppingCartVM
                        //{
                        //    AppUserId = appUser.Id,
                        //    ProductId = shoppingCartVM.ProductId,
                        //    Count = shoppingCartVM.Count,
                        //    CreatedAt = DateTime.UtcNow.AddHours(4)
                        //};

                        shoppingCartVMs.Add(shoppingCartVM);
                    }


                }

                if (shoppingCartVMs.Count > 0)
                {
                    //await _context.ShoppingCarts.AddRangeAsync(shoppingCartVMs);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("index", "home");
        }
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        #endregion

        #region Create Role
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Customer" });

        //    return Ok();
        //}
        #endregion
    }
}
