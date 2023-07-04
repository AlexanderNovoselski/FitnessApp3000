using FitnessApp.Data;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
    public class UserService : IUserService
    {
        public readonly ApplicationDbContext dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var models = await dbContext.Users.Select(d => new UserViewModel
            {
                Email = d.Email,
                UserName = d.UserName,
                Age = d.Age,
                Gender = d.Gender,
                Weight = d.Weight,
                Height = $"{d.HeightInMeters}m {d.HeightInCentimeters}c"
                
            }).ToListAsync();

            return models;
        }

        public async Task Remove(string email)
        {
            var user = dbContext.Set<User>().SingleOrDefault(u => u.Email == email);
            if (user != null)
            {
                dbContext.Set<User>().Remove(user);
                await dbContext.SaveChangesAsync();
            }

            await Task.CompletedTask;
        }
    }
}
