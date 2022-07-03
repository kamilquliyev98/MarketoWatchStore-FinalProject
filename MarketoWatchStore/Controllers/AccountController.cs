using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using MarketoWatchStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MarketoWatchStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly MarketoDbContext _context;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration config, MarketoDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _context = context;
        }

        #region Register
        public IActionResult Register() => View();

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
                IsAdmin = false
            };

            string token = Guid.NewGuid().ToString();
            appUser.EmailConfirmationToken = token;

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

            var link = Url.Action(nameof(VerifyEmail), "Account", new { id = appUser.Id, token }, Request.Scheme, Request.Host.ToString());

            EmailVM email = _config.GetSection("Email").Get<EmailVM>();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email.SenderEmail, email.SenderName);
            mail.To.Add(appUser.Email);
            mail.Subject = "Verify Email";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/assets/templates/verifyemail.html"))
            {
                body = reader.ReadToEnd();
            }
            mail.Body = body.Replace("{link}", link);
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = email.Server;
            smtp.Port = email.Port;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(email.SenderEmail, email.Password);
            smtp.Send(mail);

            return RedirectToAction(nameof(EmailVerification));
        }
        #endregion

        public async Task<IActionResult> VerifyEmail(string id, string token)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser is null) return NotFound();

            if (appUser.EmailConfirmationToken != token) return BadRequest();

            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            IdentityResult result = await _userManager.ConfirmEmailAsync(appUser, emailConfirmationToken);

            if (!result.Succeeded) return BadRequest();

            string newToken = Guid.NewGuid().ToString();
            appUser.EmailConfirmationToken = newToken;
            await _userManager.UpdateAsync(appUser);
            return View();
        }

        public IActionResult EmailVerification() => View();

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
