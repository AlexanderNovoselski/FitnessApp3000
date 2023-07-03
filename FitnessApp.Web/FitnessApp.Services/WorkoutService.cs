using FitnessApp.Data;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FitnessApp.Services
{
    public class WorkoutService : IWorkoutService
    {
        public readonly ApplicationDbContext dbContext;
        public WorkoutService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<WorkoutsResultModel>> GetAllAsync()
        {
            var workoutResult = await dbContext.Workouts
                .Select(d => new WorkoutsResultModel
                {
                    WorkoutId = d.WorkoutId,
                    Name = d.Name,
                    Description = d.Description,
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

            if (workout != null)
            {
                dbContext.Remove(workout);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task Update(UpdateWorkoutViewModel model)
        {
            var workout = await dbContext.Workouts
                .Include(w => w.ExerciseWorkouts)
                    .ThenInclude(ew => ew.Exercise)
                .FirstOrDefaultAsync(x => x.WorkoutId == model.WorkoutId);

            if (workout != null)
            {
                workout.Duration = model.Duration;
                workout.Name = model.Name;
                workout.Description = model.Description;
                workout.CaloriesBurned = model.CaloriesBurned;

                // Update existing exercise workouts or add new ones
                foreach (var exerciseWorkoutModel in model.ExerciseWorkouts)
                {
                    var exerciseWorkout = workout.ExerciseWorkouts
                        .FirstOrDefault(ew => ew.ExerciseId == exerciseWorkoutModel.ExerciseId);

                    if (exerciseWorkout != null)
                    {
                        // Update sets and reps for existing exercise workout
                        exerciseWorkout.Exercise.Name = exerciseWorkoutModel.ExerciseName;
                        exerciseWorkout.Exercise.Description = exerciseWorkoutModel.ExerciseDescription;
                        exerciseWorkout.Exercise.Sets = exerciseWorkoutModel.Sets;
                        exerciseWorkout.Exercise.Reps = exerciseWorkoutModel.Reps;
                    }
                    else
                    {
                        // Add new exercise workout
                        var exercise = await dbContext.Exercises.FindAsync(exerciseWorkoutModel.ExerciseId);

                        if (exercise != null)
                        {
                            workout.ExerciseWorkouts.Add(new ExerciseWorkout
                            {
                                Exercise = exercise
                            });
                        }
                    }
                }

                // Remove exercise workouts that are not in the updated model
                var exerciseWorkoutIds = model.ExerciseWorkouts.Select(ew => ew.ExerciseId).ToList();
                var exerciseWorkoutsToRemove = workout.ExerciseWorkouts
                    .Where(ew => !exerciseWorkoutIds.Contains(ew.ExerciseId))
                    .ToList();

                foreach (var exerciseWorkout in exerciseWorkoutsToRemove)
                {
                    workout.ExerciseWorkouts.Remove(exerciseWorkout);
                }

                dbContext.Update(workout);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
