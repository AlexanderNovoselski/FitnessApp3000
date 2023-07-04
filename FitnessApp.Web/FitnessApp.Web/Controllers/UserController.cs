using FitnessApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FitnessApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await userService.GetUsersAsync();

            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(string email)
        {
            await userService.Remove(email);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
