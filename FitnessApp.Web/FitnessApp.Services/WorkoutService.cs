using FitnessApp.Data;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.Workout;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
	public class WorkoutService : IWorkoutService
	{
		public readonly ApplicationDbContext dbContext;
		public WorkoutService(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<WorkoutsViewModel>> GetAllAsync()
		{
			var workoutResult = await dbContext.Workouts
				.Select(d => new WorkoutsViewModel
				{
					WorkoutId = d.WorkoutId,
					Name = d.Name,
					Description = d.Description,
					ImageUrl = d.ImageUrl,
					CaloriesBurned = d.CaloriesBurned,
					Duration = d.Duration,
					UserIds = d.UserWorkouts.Select(ud => ud.UserId).ToList(),
					ExerciseWorkouts = d.ExerciseWorkouts.Select(ew => new ExerciseWorkoutModel
					{
						ExerciseId = ew.ExerciseId,
						ExerciseName = ew.Exercise.Name,
						Sets = ew.Exercise.Sets,
						Reps = ew.Exercise.Reps
					}).ToList()
				}).ToListAsync();


			return workoutResult;
		}

		public async Task<UpdateWorkoutViewModel> GetWorkoutEdit(int id)
		{
			var model = await dbContext.Workouts
				.Where(d => d.WorkoutId == id)
				.Select(b => new UpdateWorkoutViewModel
				{
					WorkoutId = b.WorkoutId,
					Name = b.Name,
					ImageUrl = b.ImageUrl,
					Description = b.Description,
					Duration = b.Duration,
					CaloriesBurned = b.CaloriesBurned,
					ExerciseWorkouts = b.ExerciseWorkouts.Select(ew => new ExerciseWorkoutModel
					{
						ExerciseId = ew.ExerciseId,
						ExerciseName = ew.Exercise.Name,
						ExerciseDescription = ew.Exercise.Description,
						Sets = ew.Exercise.Sets,
						Reps = ew.Exercise.Reps
					}).ToList()
				}).FirstOrDefaultAsync();

			return model;
		}

		public async Task Remove(int WorkoutId)
		{
			var workout = await dbContext.Workouts.FindAsync(WorkoutId);

			if (workout == null)
			{
                throw new KeyNotFoundException($"WorkoutId does not exist.");
			}
            dbContext.Workouts.Remove(workout);
            await dbContext.SaveChangesAsync();
        }
		public async Task Update(UpdateWorkoutViewModel model)
		{
			var workout = await dbContext.Workouts
				.Include(w => w.ExerciseWorkouts)
					.ThenInclude(ew => ew.Exercise)
				.FirstOrDefaultAsync(x => x.WorkoutId == model.WorkoutId);

			if (workout != null)
			{
				workout.WorkoutId = model.WorkoutId;
				workout.Duration = model.Duration;
				workout.Name = model.Name;
				workout.Description = model.Description;
				workout.ImageUrl = model.ImageUrl;
				workout.CaloriesBurned = model.CaloriesBurned;

				if (model.ExerciseWorkouts != null && model.ExerciseWorkouts.Any())
				{
					foreach (var exerciseWorkoutModel in model.ExerciseWorkouts)
					{
						var exerciseWorkout = workout.ExerciseWorkouts
							.FirstOrDefault(ew => ew.ExerciseId == exerciseWorkoutModel.ExerciseId);

						if (exerciseWorkout != null)
						{
							exerciseWorkout.Exercise.Name = exerciseWorkoutModel.ExerciseName;
							exerciseWorkout.Exercise.Description = exerciseWorkoutModel.ExerciseDescription;
							exerciseWorkout.Exercise.Sets = exerciseWorkoutModel.Sets;
							exerciseWorkout.Exercise.Reps = exerciseWorkoutModel.Reps;
						}
					}
				}
			}

			await dbContext.SaveChangesAsync();
		}

		public async Task RemoveExerciseFromWorkout(int workoutId, int exerciseId)
		{
			var workout = await dbContext.Workouts
		 .Include(w => w.ExerciseWorkouts)
		 .FirstOrDefaultAsync(w => w.WorkoutId == workoutId);

			if (workout != null)
			{
				var exerciseWorkout = workout.ExerciseWorkouts.FirstOrDefault(ew => ew.ExerciseId == exerciseId);

				if (exerciseWorkout != null)
				{
					workout.ExerciseWorkouts.Remove(exerciseWorkout);
					await dbContext.SaveChangesAsync();
				}
				else
				{
                    throw new KeyNotFoundException($"ExerciseId does not exist.");
                }
			}
			else
			{
                throw new KeyNotFoundException($"WorkoutId does not exist.");
            }
		}
		public async Task CreateAsync(AddWorkoutViewModel model)
		{
			var workout = new Workout
			{
				Name = model.Name,
				Description = model.Description,
				ImageUrl = model.ImageUrl,
				Duration = model.Duration,
				CaloriesBurned = model.CaloriesBurned,
			};

			dbContext.Workouts.Add(workout);
			await dbContext.SaveChangesAsync();
		}

		public Task<AddWorkoutViewModel> GetAddModel()
		{
			var model = new AddWorkoutViewModel();
			return Task.FromResult(model);
		}
		public async Task<List<ExerciseWorkoutModel>> GetExerciseDetails(int WorkoutId)
		{
			var exerciseDetails = await dbContext.ExerciseWorkouts
				.Where(ew => ew.WorkoutId == WorkoutId)
				.Include(ew => ew.Exercise)
				.Select(ew => new ExerciseWorkoutModel
				{
					ExerciseId = ew.Exercise.ExerciseId,
					ExerciseName = ew.Exercise.Name,
					ExerciseDescription = ew.Exercise.Description,
					Sets = ew.Exercise.Sets,
					Reps = ew.Exercise.Reps
				})
				.ToListAsync();

			return exerciseDetails;
		}
	}
}
