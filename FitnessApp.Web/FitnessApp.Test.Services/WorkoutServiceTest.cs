using FitnessApp.Data;
using FitnessApp.Services;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.Workout;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Test.Services
{
    [TestClass]
    public class WorkoutServiceTest
    {
        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
         .UseInMemoryDatabase(databaseName: "FitnessDbTest")
         .Options;

        private ApplicationDbContext context;
        private IWorkoutService workoutService;

        [TestInitialize]
        public void Setup()
        {
            context = new ApplicationDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();
            workoutService = new WorkoutService(context);
        }

        [TestCleanup]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        private void SeedDatabase()
        {
            var workouts = new List<Workout>
            {
                new Workout
                {
                    WorkoutId = -1,
                    Name = "Workout 1",
                    Description = "Description 1",
                    ImageUrl = "image1.jpg",
                    Duration = 30,
                    CaloriesBurned = 200,
                    ExerciseWorkouts = new List<ExerciseWorkout>
                    {
                        new ExerciseWorkout
                        {
                            ExerciseId = -1,
                            Exercise = new Exercise
                            {
                                ExerciseId = -1,
                                Name = "Exercise 1",
                                Description = "Exercise Description 1",
                                Sets = 3,
                                Reps = 12
                            }
                        },
                        new ExerciseWorkout
                        {
                            ExerciseId = -2,
                            Exercise = new Exercise
                            {
                                ExerciseId = -2,
                                Name = "Exercise 2",
                                Description = "Exercise Description 2",
                                Sets = 4,
                                Reps = 10
                            }
                        }
                    }
                },
                new Workout
                {
                    WorkoutId = -2,
                    Name = "Workout 2",
                    Description = "Description 2",
                    ImageUrl = "image2.jpg",
                    Duration = 45,
                    CaloriesBurned = 300,
                    ExerciseWorkouts = new List<ExerciseWorkout>
                    {
                        new ExerciseWorkout
                        {
                            ExerciseId = -3,
                            Exercise = new Exercise
                            {
                                ExerciseId = -3,
                                Name = "Exercise 3",
                                Description = "Exercise Description 3",
                                Sets = 3,
                                Reps = 12
                            }
                        },
                        new ExerciseWorkout
                        {
                            ExerciseId = -4,
                            Exercise = new Exercise
                            {
                                ExerciseId = -4,
                                Name = "Exercise 4",
                                Description = "Exercise Description 4",
                                Sets = 4,
                                Reps = 10
                            }
                        }
                    }
                }
            };

            context.Workouts.AddRange(workouts);
            context.SaveChanges();
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsAllWorkouts()
        {
            // Act
            var workouts = await workoutService.GetAllAsync();

            // Assert
            Assert.AreEqual(context.Workouts.Count(), workouts.Count());
        }

        [TestMethod]
        public async Task GetWorkoutEdit_ReturnsCorrectWorkoutViewModel()
        {
            // Arrange
            var workoutId = -1;

            // Act
            var viewModel = await workoutService.GetWorkoutEdit(workoutId);

            // Assert
            Assert.IsNotNull(viewModel);
            Assert.AreEqual(workoutId, viewModel.WorkoutId);
        }

        [TestMethod]
        public async Task Remove_RemovesWorkoutFromDatabase()
        {
            // Arrange
            var workoutId = -1;

            // Act
            await workoutService.Remove(workoutId);
            var deletedWorkout = await context.Workouts.FirstOrDefaultAsync(w => w.WorkoutId == workoutId);

            // Assert
            Assert.IsNull(deletedWorkout);
        }

        [TestMethod]
        public async Task Remove_InvalidWorkoutId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var invalidWorkoutId = -1000;

            // Assert & Act
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () =>
            {
                await workoutService.Remove(invalidWorkoutId);
            });
        }

        [TestMethod]
        public async Task Update_UpdatesWorkoutInDatabase()
        {
            // Arrange
            var model = new UpdateWorkoutViewModel
            {
                WorkoutId = -1,
                Name = "Updated Workout",
                Description = "Updated Description",
                ImageUrl = "updated_image.jpg",
                Duration = 40,
                CaloriesBurned = 250,
                ExerciseWorkouts = new List<ExerciseWorkoutModel>
                {
                    new ExerciseWorkoutModel
                    {
                        ExerciseId = -1,
                        ExerciseName = "Updated Exercise 1",
                        ExerciseDescription = "Updated Exercise Description 1",
                        Sets = 4,
                        Reps = 15
                    },
                    new ExerciseWorkoutModel
                    {
                        ExerciseId = -2,
                        ExerciseName = "Updated Exercise 2",
                        ExerciseDescription = "Updated Exercise Description 2",
                        Sets = 5,
                        Reps = 12
                    }
                }
            };

            // Act
            await workoutService.Update(model);
            var updatedWorkout = await context.Workouts.FindAsync(model.WorkoutId);

            // Assert
            Assert.IsNotNull(updatedWorkout);
            Assert.AreEqual(model.Name, updatedWorkout.Name);
            Assert.AreEqual(model.Description, updatedWorkout.Description);
            Assert.AreEqual(model.ImageUrl, updatedWorkout.ImageUrl);
            Assert.AreEqual(model.Duration, updatedWorkout.Duration);
            Assert.AreEqual(model.CaloriesBurned, updatedWorkout.CaloriesBurned);
            Assert.AreEqual(2, updatedWorkout.ExerciseWorkouts.Count);
        }


        [TestMethod]
        public async Task CreateAsync_AddsNewWorkoutToDatabase()
        {
            // Arrange
            var model = new AddWorkoutViewModel
            {
                Name = "New Workout",
                Description = "New Description",
                ImageUrl = "new_image.jpg",
                Duration = 50,
                CaloriesBurned = 400
            };

            // Act
            await workoutService.CreateAsync(model);
            var savedWorkout = await context.Workouts.FirstOrDefaultAsync(w => w.Name == model.Name);

            // Assert
            Assert.IsNotNull(savedWorkout);
            Assert.AreEqual(model.Name, savedWorkout.Name);
            Assert.AreEqual(model.Description, savedWorkout.Description);
            Assert.AreEqual(model.ImageUrl, savedWorkout.ImageUrl);
            Assert.AreEqual(model.Duration, savedWorkout.Duration);
            Assert.AreEqual(model.CaloriesBurned, savedWorkout.CaloriesBurned);
        }

        [TestMethod]
        public async Task GetExerciseDetails_ReturnsExerciseDetailsForWorkout()
        {
            // Arrange
            var workoutId = -1;

            // Act
            var exerciseDetails = await workoutService.GetExerciseDetails(workoutId);

            // Assert
            Assert.AreEqual(2, exerciseDetails.Count());
            // Add assertions for exercise workout details
        }
    }
}
