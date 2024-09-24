using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.DTOModels;
using BusinessLayer.Services;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                // Logic for logging the user in
                // Here you can directly check the email and password if needed
                // Currently just redirecting as an example
                return RedirectToAction("Index", "Home"); // Redirect to a suitable page
            }
            return View(userDto);
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdUser = await _userService.CreateUserAsync(userDto);
                    return RedirectToAction("Login"); // Redirect to login after successful registration
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
            }
            return View(userDto);
        }
    }
}
