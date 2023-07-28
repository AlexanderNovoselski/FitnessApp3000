using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace FitnessApp.Web.Controllers
{
    public class UserController : BaseController
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

            var pagedUsers = new PagedList<UserViewModel>(users, page, pageSize);

            return View("GetAll", pagedUsers);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Remove(string email)
        {
            try
            {
                await userService.Remove(email);
                return RedirectToAction(nameof(GetAll));
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                return StatusCode(500); // Return an HTTP 500 Internal Server Error
            }
        }
    }
}
