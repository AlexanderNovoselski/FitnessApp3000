using FitnessApp.Web.ViewModels.Models.Diet;
using FitnessApp.Web.ViewModels.Models.Enums;

namespace FitnessApp.Services.Contracts
{
    public interface IDietService
    {
        public Task<IEnumerable<DietsResultModel>> GetAllDietsAsync(SortType sortingType);

        public Task<IEnumerable<DietsResultModel>> GetMyDiets(string userId);
		
		public Task AddToCollection(int DietId, string userId);

		public Task RemoveFromCollection(int DietId, string userId);

		public Task Remove(int DietId);

		public Task Edit(UpdateDietViewModel model);

		public Task<UpdateDietViewModel> GetEditDiet(int DietId);

        public Task CreateAsync(AddDietViewModel model);

        public Task<AddDietViewModel> GetAddModel();



    }
}
