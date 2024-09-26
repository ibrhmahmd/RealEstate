using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        // GET: /Account/Admin
        public IActionResult Admin()
        {
            return View("../Admin/view");
        }


        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AuthenticateUserAsync(email, password);
                if (user != null)
                {
                    // Create the claims for the user
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
                // Add other claims if necessary
            };
                    var claimsIdentity = new ClaimsIdentity(claims, "CookieScheme");
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync("CookieScheme", claimsPrincipal); // Sign in the user

                    return RedirectToAction("Index", "Home"); // Redirect to home or desired page
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View();
        }



        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }


        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserName,Email,PasswordHash, Role")] UserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.CreateUserAsync(userDto);
                    return RedirectToAction("Index", "Home");
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
            }
            return View(userDto);
        }


        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("YourCookieScheme"); 
            return RedirectToAction("Login", "Account"); 
        }


        // GET: /Account/AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}