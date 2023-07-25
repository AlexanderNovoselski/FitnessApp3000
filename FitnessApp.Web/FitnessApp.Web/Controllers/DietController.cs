using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.Diet;
using FitnessApp.Web.ViewModels.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Net;

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
        public async Task<IActionResult> GetAll(SortType sortingType = SortType.Default, int page = 1, int pageSize = 3)
        {
            var model = await dietService.GetAllDietsAsync(sortingType);
            var pagedModel = model.ToPagedList(page, pageSize);
            ViewBag.SortingType = sortingType;

            return View("GetAll", pagedModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetMyDiets(int page = 1, int pageSize = 3)
        {
            var model = await dietService.GetMyDiets(GetUserId());
            var pagedModel = model.ToPagedList(page, pageSize);
            return View("MyDiets", pagedModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int Id)
        {
            try
            {
                await dietService.AddToCollection(Id, GetUserId());
                return RedirectToAction(nameof(GetAll));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(GetAll));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int Id)
        {
            try
            {
                await dietService.RemoveFromCollection(Id, GetUserId());
                return RedirectToAction(nameof(GetAll));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(GetAll));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(int Id)
        {
            try
            {
                await dietService.Remove(Id);
                return RedirectToAction(nameof(GetAll));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(GetAll));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int Id)
        {
            UpdateDietViewModel diet = await dietService.GetEditDiet(Id);

            if (diet == null)
            {
                return RedirectToAction(nameof(GetAll));
            }

            return View("Edit", diet);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateDietViewModel model)
        {

            if (ModelState.IsValid == false)
            {
                return View("Edit", model);
            }
            model.Name = WebUtility.HtmlEncode(model.Name);
            await dietService.Edit(model);

            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Diet/Add")]
        public async Task<IActionResult> GetCreateModel()
        {
            var model = await dietService.GetAddModel();

            return View("Add", model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(AddDietViewModel model)

        {
            if (ModelState.IsValid == false)
            {
                return View("Add", model);
            }
            await dietService.CreateAsync(model);

            return RedirectToAction(nameof(GetAll));
        }
    }
}
