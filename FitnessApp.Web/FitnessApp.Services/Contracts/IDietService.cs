using FitnessApp.Web.ViewModels.Models;

namespace FitnessApp.Services.Contracts
{
    public interface IDietService
    {
        public Task<IEnumerable<DietsResultModel>> GetAllDietsAsync();

        //public Task<IEnumerable<DietsResultModel>> GetMyDiet(string userId);

        //public Task AddToCollection(int bookId, string userId);

	}
}
