using FitnessApp.Data;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.Goal;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
    public class GoalService : IGoalService
	{

		public readonly ApplicationDbContext dbContext;
		public GoalService(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
        public async Task<IEnumerable<GoalTargetDateViewModel>> GetGoalsWithinThreeDays(string userId)
        {
            DateTime now = DateTime.Now;
            DateTime threeDaysFromNow = now.AddDays(3);

            var goalsWithinThreeDays = await dbContext.Goals
                .Where(g => g.UserId == userId && ((!g.isCompleted && g.TargetDate.Date >= now.Date && g.TargetDate.Date <= threeDaysFromNow.Date) || (!g.isCompleted && g.TargetDate.Date == now.Date)))
                .Select(g => new GoalTargetDateViewModel
                {
                    GoalId = g.GoalId,
                    GoalType = g.GoalType,
                    TargetDate = g.TargetDate,
                    isCompleted = g.isCompleted
                })
                .ToListAsync();

            return goalsWithinThreeDays;
        }
        public async Task CreateAsync(AddGoalViewModel model, string userId)
		{
			var goal = new Goal
			{
				Description = model.Description,
				GoalType = model.GoalType,
				TargetDate = model.TargetDate,
				TargetWeight = model.TargetWeight,
				isCompleted = false,
				UserId = userId
			};

			dbContext.Goals.Add(goal);
			await dbContext.SaveChangesAsync();
		}


		public Task<AddGoalViewModel> GetAddModel()
		{
			var model = new AddGoalViewModel();
			return Task.FromResult(model);
		}


        public async Task<IEnumerable<GoalsViewModel>> GetMyAsync(string userId, string searchWords = null)
        {
            IQueryable<Goal> query = dbContext.Goals.Where(x => x.UserId == userId && x.isCompleted == false);

            if (!string.IsNullOrEmpty(searchWords))
            {
                query = query.Where(g => g.Description.Contains(searchWords));
            }

            var model = await query.Select(g => new GoalsViewModel
            {
                GoalId = g.GoalId,
                Description = g.Description,
                GoalType = g.GoalType,
                TargetDate = g.TargetDate,
                isCompleted = g.isCompleted,
                TargetWeight = g.TargetWeight,
            }).ToListAsync();

            return model;
        }

        public async Task<UpdateGoalViewModel> GetGoalEdit(int GoalId)
		{
			var model = await dbContext.Goals
				.Where(x => x.GoalId == GoalId)
				.Select(g => new UpdateGoalViewModel
				{
					GoalId = g.GoalId,
					Description = g.Description,
					GoalType = g.GoalType,
					TargetDate = g.TargetDate,
					TargetWeight = g.TargetWeight,
				}).FirstAsync();

			return model;
		}

		public async Task Remove(int id)
		{
			var goal = await dbContext.Goals.FirstOrDefaultAsync(x => x.GoalId == id);

			if (goal == null)
			{
                throw new KeyNotFoundException($"Goal does not exist.");
			}
            dbContext.Goals.Remove(goal);
            await dbContext.SaveChangesAsync();
        }

		public async Task Update(UpdateGoalViewModel model)
		{
			var goal = await dbContext.Goals.FindAsync(model.GoalId);

			if (goal != null)
			{
				goal.GoalId = model.GoalId;
				goal.Description = model.Description;
				goal.TargetDate = model.TargetDate;
				goal.TargetWeight = model.TargetWeight;
				goal.GoalType = model.GoalType;

				dbContext.Update(goal);
				await dbContext.SaveChangesAsync();
			}
		}

        public async Task Completed(int GoalId)
        {
            var goal = await dbContext.Goals.FindAsync(GoalId);

			if (goal != null)
			{
				goal.isCompleted = true;
				goal.CompletedDate = DateTime.UtcNow;
			}

            dbContext.Update(goal);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CompletedViewModel>> GetCompletedGoals(string userId)
        {
            var model = await dbContext.Goals
            .Where(x => x.UserId == userId && x.isCompleted == true)
            .Select(g => new CompletedViewModel
            {
                GoalId = g.GoalId,
                Description = g.Description,
                GoalType = g.GoalType,
                TargetDate = g.TargetDate,
                isCompleted = g.isCompleted,
                TargetWeight = g.TargetWeight,
				CompletedDate = g.CompletedDate
            }).ToListAsync();

            return model;
        }
    }
}
