using MarketoWatchStore.DAL;
using MarketoWatchStore.Models;
using MarketoWatchStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
                FullName = registerVM.FullName,
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

        #region Email Verification
        public IActionResult EmailVerification() => View();

        public async Task<IActionResult> VerifyEmail(string id, string token)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("error404", "home");

            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser is null) return RedirectToAction("error404", "home");

            if (appUser.EmailConfirmationToken != token) return RedirectToAction("error400", "home");

            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            IdentityResult result = await _userManager.ConfirmEmailAsync(appUser, emailConfirmationToken);

            if (!result.Succeeded) return RedirectToAction("error400", "home");

            string newToken = Guid.NewGuid().ToString();
            appUser.EmailConfirmationToken = newToken;
            await _userManager.UpdateAsync(appUser);

            return View();
        }
        #endregion

        #region Reset Password
        public IActionResult ResetPassword() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM reset)
        {
            if (string.IsNullOrWhiteSpace(reset.Email))
            {
                ModelState.AddModelError("Email", "Enter your email.");
                return View();
            }

            AppUser appUser = await _userManager.FindByEmailAsync(reset.Email);

            if (appUser is null)
            {
                ModelState.AddModelError("", "The email you entered is not registered.");
                return View();
            }

            var link = Url.Action(nameof(NewPassword), "Account", new { id = appUser.Id, token = appUser.PasswordResetToken }, Request.Scheme, Request.Host.ToString());
            EmailVM email = _config.GetSection("Email").Get<EmailVM>();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email.SenderEmail, email.SenderName);
            mail.To.Add(reset.Email);
            mail.Subject = "Reset Password";
            mail.Body = $"<a href=\"{link}\">Click here to Reset Password</a>";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = email.Server;
            smtp.Port = email.Port;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(email.SenderEmail, email.Password);
            smtp.Send(mail);

            return RedirectToAction(nameof(EmailVerification));
        }

        public IActionResult NewPassword(ResetPasswordVM reset) => View(reset);

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("NewPassword")]
        public async Task<IActionResult> NewPasswordPost(ResetPasswordVM reset)
        {
            if (!ModelState.IsValid) return View(reset);

            if (reset.Id is null) return RedirectToAction("error404", "home");

            AppUser appUser = await _userManager.FindByIdAsync(reset.Id);

            if (appUser is null) return RedirectToAction("error404", "home");

            if (appUser.PasswordResetToken != reset.Token) return RedirectToAction("error400", "home");

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(appUser);
            IdentityResult result = await _userManager.ResetPasswordAsync(appUser, resetToken, reset.Password);

            if (!result.Succeeded) return RedirectToAction("error400", "home");

            string passwordResetToken = Guid.NewGuid().ToString();
            appUser.PasswordResetToken = passwordResetToken;
            await _userManager.UpdateAsync(appUser);

            return RedirectToAction("login", "account");
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");

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

            if (!await _userManager.IsEmailConfirmedAsync(appUser))
            {
                ModelState.AddModelError("", "Please verify your account first!");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);

            if (!signInResult.Succeeded)
            {
                if (signInResult.IsLockedOut)
                {
                    ModelState.AddModelError("", "Your account has been temporarily blocked. Try again later.");
                    return View();
                }

                ModelState.AddModelError("", "Email or Password is incorrect.");
                return View();
            }

            if (appUser.IsAdmin)
            {
                ModelState.AddModelError("", "Email or Password is incorrect.");
                return View();
            }

            return RedirectToAction("index", "home");
        }
        #endregion

        #region Profile
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Profile()
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == User.Identity.Name.ToUpperInvariant() && !u.IsAdmin);

            if (appUser is null) return RedirectToAction("index", "home");

            CustomerProfileVM customerProfileVM = new CustomerProfileVM
            {
                Customer = new CustomerUpdateVM
                {
                    Address = appUser.Address,
                    City = appUser.City,
                    FullName = appUser.FullName,
                    PhoneNumber = appUser.PhoneNumber,
                    UserName = appUser.UserName,
                    Email = appUser.Email
                },

                Orders = await _context.Orders
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .Include(o => o.AppUser)
                .Where(o => !o.IsDeleted && o.AppUserId == appUser.Id)
                .ToListAsync()
            };

            return View(customerProfileVM);
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
