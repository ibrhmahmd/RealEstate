using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserService userService, SignInManager<User> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        // GET: /Account/Admin
        public IActionResult Admin()
        {
            
            return View("~/Views/Admin/view.cshtml");
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AuthenticateUserAsync(email, password);
                if (user != null)
                {
                    // Create the claims for the user, including Name and UserID
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("Role", user.Role.ToString() )
                    };

                    // Create the ClaimsIdentity and AuthenticationProperties
                    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = rememberMe, 
                        ExpiresUtc = rememberMe ? DateTimeOffset.UtcNow.AddDays(30) : null 
                    };

                    // Sign in the user with the new claims
                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);

                    // Log the user roles and claims
                    var roles = await _userService.GetUserRolesAsync(user.Id);
                    Console.WriteLine($"User Roles: {string.Join(", ", roles)}");

                    var allClaims = claimsIdentity.Claims.Select(c => $"{c.Type}: {c.Value}");
                    Console.WriteLine("User Claims: " + string.Join(", ", allClaims));

                    // Redirect based on the role of the user
                    if (roles.Contains("Admin"))
                    {
                        return Admin();
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
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
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.CreateUserAsync(user);
                    return RedirectToAction("Login", "Account");
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
            }
            return View(user);
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        // GET: /Account/AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }


        // Method to create an admin user for seeding
        public async Task<IActionResult> SeedAdminUser()
        {
            var email = "admin@a.com";
            var password = "Admin123";
            var role = "Admin";

            var result = await _userService.RegisterUserAsync(email, password, role);

            if (result)
            {
                return Ok("Admin user seeded successfully.");
            }

            return BadRequest("Failed to seed admin user.");
        }
    }
}
