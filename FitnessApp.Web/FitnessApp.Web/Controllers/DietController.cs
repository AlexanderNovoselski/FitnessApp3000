using FitnessApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class DietController : BaseController
    {
        private readonly IDietService dietService;

        public DietController(IDietService dietService)
        {
            this.dietService = dietService;
        }

        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var model = await dietService.GetAllDietsAsync();
            return View("GetAll", model);
        }

        [HttpPost]
		public async Task<IActionResult> AddToCollection(int DietId)
		{
			//await dietService.AddToCollection(DietId, GetUserId());

			return RedirectToAction(nameof(GetAll));
		}
	}
}
