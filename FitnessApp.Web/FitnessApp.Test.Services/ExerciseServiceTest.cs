using FitnessApp.Data;
using FitnessApp.Enums;
using FitnessApp.Services;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.Exercise;
using FitnessApp.Web.ViewModels.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Test.Services
{
    [TestClass]
    public class ExerciseServiceTest
    {
        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
         .UseInMemoryDatabase(databaseName: "FitnessDbTest")
         .Options;

        private ApplicationDbContext context;
        private IExerciseService exerciseService;

        [TestInitialize]
        public void Setup()
        {
            context = new ApplicationDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();
            exerciseService = new ExerciseService(context);
        }

        [TestCleanup]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [TestMethod]
        public async Task AddToWorkout_ValidIds_ReturnsExerciseViewModel()
        {
            // Arrange
            int exerciseId = -4;
            int workoutId = -4;

            // Act
            var result = await exerciseService.AddToWorkout(exerciseId, workoutId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Exercise 1", result.Name);
            Assert.AreEqual("Description 1", result.Description);
            Assert.AreEqual(3, result.Sets);
            Assert.AreEqual(10, result.Reps);
        }

        [TestMethod]
        public async Task AddToWorkout_InvalidExerciseId_ThrowsArgumentException()
        {
            // Arrange
            int invalidExerciseId = -1000; // Invalid exerciseId
            int workoutId = -4;

            // Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => exerciseService.AddToWorkout(invalidExerciseId, workoutId));
        }
        [TestMethod]
        public async Task AddToWorkout_InvalidWorkoutId_ThrowsArgumentException()
        {
            // Arrange
            int exerciseId = -4;
            int invalidWorkoutId = -1000; // Invalid workoutId

            // Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => exerciseService.AddToWorkout(exerciseId, invalidWorkoutId));
        }

        [TestMethod]
        public async Task AddToWorkout_ExerciseAlreadyAssociated_ThrowsInvalidOperationException()
        {
            // Arrange
            int exerciseId = -4;
            int workoutId = -4;

            // Add the exercise to the workout
            await exerciseService.AddToWorkout(exerciseId, workoutId);

            // Act and Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => exerciseService.AddToWorkout(exerciseId, workoutId));
        }

        [TestMethod]
        public async Task CreateAsync_ValidModel_AddsExerciseToDatabase()
        {
            // Arrange
            var model = new AddExerciseViewModel
            {
                Name = "New Exercise",
                Description = "New Description",
                Sets = 3,
                Reps = 12
            };

            // Act
            await exerciseService.CreateAsync(model);

            // Assert
            var createdExercise = await context.Exercises.FirstOrDefaultAsync(e => e.Name == "New Exercise");
            Assert.IsNotNull(createdExercise);
            Assert.AreEqual("New Description", createdExercise.Description);
            Assert.AreEqual(3, createdExercise.Sets);
            Assert.AreEqual(12, createdExercise.Reps);
        }

        [TestMethod]
        public async Task GetAddModel_ReturnsAddExerciseViewModel()
        {
            // Act
            var result = await exerciseService.GetAddModel();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AddExerciseViewModel));
        }

        [TestMethod]
        public async Task GetAll_ValidWorkoutId_ReturnsExerciseViewModels()
        {
            // Arrange
            int workoutId = -4;

            // Act
            var result = await exerciseService.GetAll(workoutId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Count()); // Assuming there are 3 exercises not associated with the workout
        }

        [TestMethod]
        public async Task Remove_ExistingExerciseId_RemovesExerciseFromDatabase()
        {
            // Arrange
            int exerciseId = -4;

            // Act
            await exerciseService.Remove(exerciseId);

            // Assert

            var removedExercise = await context.Exercises.FindAsync(exerciseId);
            Assert.IsNull(removedExercise);
        }

        [TestMethod]
        public async Task Remove_NonExistingExerciseId_NoChangesInDatabase()
        {
            // Arrange
            int invalidExerciseId = -1000; // Non-existing exerciseId

            //Act and Assert
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () =>
            {
                await exerciseService.Remove(invalidExerciseId);
            });
        }

        private void SeedDatabase()
        {
            var exercises = new List<Exercise>
        {
            new Exercise {ExerciseId = -4, Name = "Exercise 1", Description = "Description 1", Sets = 3, Reps = 10 },
            new Exercise {ExerciseId = -5, Name = "Exercise 2", Description = "Description 2", Sets = 4, Reps = 12 },
            new Exercise {ExerciseId = -6, Name = "Exercise 3", Description = "Description 3", Sets = 2, Reps = 8 }
        };
            var workout = new Workout
            {
                WorkoutId = -4,
                Name = "Workout",
                Description = "Burnout",
                CaloriesBurned = 1000,
                ImageUrl = "http.test.com",
                Duration = 1000,
            };

            context.Exercises.AddRange(exercises);
            context.Workouts.Add(workout);
            context.SaveChanges();
        }
    }
}
