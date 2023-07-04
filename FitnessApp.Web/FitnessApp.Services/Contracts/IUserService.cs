using FitnessApp.Web.ViewModels.Models.User;

namespace FitnessApp.Services.Contracts
{
    public interface IUserService
    {
        public Task<IEnumerable<UserViewModel>> GetUsersAsync();

        public Task Remove(string email);
    }
}
