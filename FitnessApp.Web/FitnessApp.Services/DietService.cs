﻿using FitnessApp.Data;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.Diet;
using FitnessApp.Web.ViewModels.Models.Enums;
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

        public async Task<IEnumerable<DietsResultModel>> GetAllDietsAsync(SortType sortingType)
        {
            IQueryable<Diet> query = dbContext.Diets.Include(d => d.UserDiets);

            switch (sortingType)
            {
                case SortType.Newest:
                    query = query.OrderByDescending(d => d.CreationDate);
                    break;
                case SortType.Oldest:
                    query = query.OrderBy(d => d.CreationDate);
                    break;
                case SortType.Default:
                    break;
                default:
                    break;
            }

            var diets = await query.ToListAsync();

            var dietsResult = diets.Select(d => new DietsResultModel
            {
                DietId = d.DietId,
                Name = d.Name,
                ImageUrl = d.ImageUrl,
                Description = d.Description,
                CaloriesIntake = d.CaloriesIntake,
                UserIds = d.UserDiets.Select(ud => ud.UserId).ToList(),
                SortingType = sortingType
            });

            return dietsResult;
        }

        public async Task<IEnumerable<DietsResultModel>> GetMyDiets(string userId)
        {
            return await dbContext.UserDiets
                 .Where(userDiet => userDiet.UserId == userId)
                 .Select(userDiet => new DietsResultModel
                 {
                     Name = userDiet.Diet.Name,
                     Description = userDiet.Diet.Description,
                     DietId = userDiet.Diet.DietId,
                     CaloriesIntake = userDiet.Diet.CaloriesIntake,
                     ImageUrl = userDiet.Diet.ImageUrl,
                     UserIds = userDiet.Diet.UserDiets.Select(ud => ud.UserId).ToList()
                 }).ToListAsync();
        }

        public async Task AddToCollection(int DietId, string userId)
        {
            bool alreadyAdded = await dbContext.UserDiets
                .AnyAsync(ub => ub.UserId == userId && ub.DietId == DietId);

            if (!alreadyAdded)
            {
                var existingDiet = await dbContext.Diets.FindAsync(DietId);

                if (existingDiet != null)
                {
                    var userDiet = new UserDiet
                    {
                        UserId = userId,
                        DietId = DietId
                    };
                    dbContext.UserDiets.Add(userDiet);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveFromCollection(int DietId, string userId)
        {
            bool isAdded = await dbContext.UserDiets
    .AnyAsync(userDiet => userDiet.DietId == DietId && userDiet.UserId == userId);

            if (isAdded)
            {
                var userDiet = await dbContext.UserDiets
                    .FirstOrDefaultAsync(userDiet => userDiet.DietId == DietId && userDiet.UserId == userId);

                if (userDiet == null)
                {
                    throw new KeyNotFoundException($"UserId with ID {userId} does not exist.");
                    
                }
                dbContext.UserDiets.Remove(userDiet);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"DietId with ID {DietId} does not exist.");
            }
        }

        public async Task Remove(int DietId)
        {
            var diet = await dbContext.Diets.FindAsync(DietId);

            if (diet == null)
            {
                throw new KeyNotFoundException($"Diet with ID {DietId} does not exist.");
            }

            dbContext.Diets.Remove(diet);
            await dbContext.SaveChangesAsync();
        }
        public async Task<UpdateDietViewModel> GetEditDiet(int DietId)
        {

            return await dbContext.Diets
                .Where(b => b.DietId == DietId)
                .Select(b => new UpdateDietViewModel
                {
                    DietId = b.DietId,
                    Name = b.Name,
                    Description = b.Description,
                    CaloriesIntake = b.CaloriesIntake,
                    ImageUrl = b.ImageUrl,
                }).FirstAsync();
        }

        public async Task Edit(UpdateDietViewModel model)
        {
            var diet = await dbContext.Diets.FindAsync(model.DietId);

            if (diet != null)
            {
                diet.Name = model.Name;
                diet.Description = model.Description;
                diet.CaloriesIntake = model.CaloriesIntake;
                diet.ImageUrl = model.ImageUrl;

                dbContext.Update(diet);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task CreateAsync(AddDietViewModel model)
        {
            var diet = new Diet
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                CaloriesIntake = model.CaloriesIntake,
            };

            dbContext.Diets.Add(diet);
            await dbContext.SaveChangesAsync();
        }


        public Task<AddDietViewModel> GetAddModel()
        {
            var model = new AddDietViewModel();
            return Task.FromResult(model);
        }

    }
}
