using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;

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
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var users = await userService.GetUsersAsync();

            // Create a PagedList from the list of users
            var pagedUsers = new PagedList<UserViewModel>(users, page, pageSize);

            return View("GetAll", pagedUsers);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(string email)
        {
            await userService.Remove(email);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
