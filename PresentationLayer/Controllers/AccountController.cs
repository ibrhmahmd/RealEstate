using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace PresentationLayer.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserService _userService;


        public AccountController(UserService userService)
		{
			_userService = userService;
		}

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
		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(string email, string password)
		{
			if (ModelState.IsValid)
			{
				var user = await _userService.AuthenticateUserAsync(email, password);
				if (user != null)
				{
					// Here you would typically set up a session or authentication cookie
					// For now, we'll just redirect to home
					return RedirectToAction("Index", "Home");
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
		public async Task<IActionResult> Register([Bind("UserName,Email,PasswordHash,PhoneNumber")] UserDTO userDto)
		{
			if (ModelState.IsValid)
			{
				try
				{
					
					await _userService.CreateUserAsync(userDto);
					return RedirectToAction("Login", "Account");
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
			// Here you would typically clear the session or authentication cookie
			// For now, we'll just redirect to login
			return RedirectToAction("Index", "Home");
		}

        // GET: /Account/AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}