using Microsoft.AspNetCore.Mvc;
using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserDTO userDto)
    {
        if (ModelState.IsValid)
        {
            // Validate user credentials
            bool isValidUser = await _userService.ValidateUserAsync(userDto.Email, userDto.Password);
            if (isValidUser)
            {
                // Handle successful login (e.g., set authentication cookie, redirect to home page)
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
            }
        }
        return View(userDto); // Return view with model errors
    }
}
