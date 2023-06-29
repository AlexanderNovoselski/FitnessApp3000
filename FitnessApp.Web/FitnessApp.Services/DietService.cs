using FitnessApp.Data;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
	public class DietService : IDietService
	{

		public readonly ApplicationDbContext dbContext;
		public DietService(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<IEnumerable<DietsResultModel>> GetAllDietsAsync()
		{
			return await dbContext.Diets.Select(b => new DietsResultModel
			{
				CaloriesIntake = b.CaloriesIntake,
				Description = b.Description,
				DietId = b.DietId,
				ImageUrl = b.ImageUrl,
				Name = b.Name,
				UserId = b.UserId,
			}).ToListAsync();
		}

		//public async Task<IEnumerable<DietsResultModel>> GetMyDiet(string userId)
		//{
		//	return await dbContext.Diets
		//.Where(ub => ub.UserId == userId)
		//.Select(b => new DietsResultModel
		//{
		//	Name = b.Name,
		//	Description = b.Description,
		//	DietId = b.DietId,
		//	CaloriesIntake = b.CaloriesIntake,
		//	ImageUrl = b.ImageUrl,
		//	UserId = b.UserId
		//}).ToListAsync();
		//}

		//public async Task AddToCollection(int dietId, string userId)
		//{
		//	bool alreadyAdded = await dbContext.Diets
		//		.AnyAsync(ub => ub.UserId == userId && ub.DietId == dietId);

		//	if (alreadyAdded == false)
		//	{
		//		var userDiet = new Diet
		//		{
		//			UserId = userId,
		//			DietId = dietId,
		//		};

		//		await dbContext.Diets.AddAsync(userDiet);
		//		await dbContext.SaveChangesAsync();
		//	}
		//}
	}
}
