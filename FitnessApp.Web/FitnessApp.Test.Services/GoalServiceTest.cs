using FitnessApp.Data;
using FitnessApp.DataLayer.Enums;
using FitnessApp.Services;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.Goal;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Test.Services
{
    [TestClass]
    public class GoalServiceTest
    {
        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
         .UseInMemoryDatabase(databaseName: "FitnessDbTest")
         .Options;

        private ApplicationDbContext context;
        private IGoalService goalService;

        [TestInitialize]
        public void Setup()
        {
            context = new ApplicationDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDataBase();
            goalService = new GoalService(context);
        }

        [TestCleanup]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }


        private void SeedDataBase()
        {
            var goals = new List<Goal>
            {
                new Goal
                {
                    GoalId = -1,
                    Description = "Goal 1",
                    GoalType = GoalType.MuscleGain,
                    TargetDate = DateTime.Now.AddDays(7),
                    TargetWeight = 70,
                    isCompleted = false,
                    UserId = "user1"
                },
                new Goal
                {
                    GoalId = -2,
                    Description = "Goal 2",
                    GoalType = GoalType.WeightLoss,
                    TargetDate = DateTime.Now.AddDays(14),
                    TargetWeight = 65,
                    isCompleted = false,
                    UserId = "user1",
                },
                new Goal
                {
                    GoalId = -3,
                    Description = "Goal 3",
                    GoalType = GoalType.WeightLoss,
                    TargetDate = DateTime.Now.AddDays(21),
                    TargetWeight = 75,
                    isCompleted = false,
                    UserId = "user2"
                }
            };

            context.Goals.AddRange(goals);
            context.SaveChanges();
        }

        [TestMethod]
        public async Task CreateAsync_AddsNewGoalToDatabase()
        {
            // Arrange
            var model = new AddGoalViewModel
            {
                Description = "New Goal",
                GoalType = GoalType.WeightLoss,
                TargetDate = DateTime.Now.AddDays(7),
                TargetWeight = 70
            };
            var userId = "user1";

            // Act
            await goalService.CreateAsync(model, userId);
            var savedGoal = await context.Goals.FirstOrDefaultAsync(g => g.Description == model.Description);

            // Assert
            Assert.IsNotNull(savedGoal);
            Assert.AreEqual(model.Description, savedGoal.Description);
            Assert.AreEqual(model.GoalType, savedGoal.GoalType);
            Assert.AreEqual(model.TargetDate, savedGoal.TargetDate);
            Assert.AreEqual(model.TargetWeight, savedGoal.TargetWeight);
            Assert.AreEqual(userId, savedGoal.UserId);
        }

        [TestMethod]
        public async Task GetMyAsync_ReturnsGoalsForSpecificUser()
        {
            // Arrange
            var userId = "user1";
            var searchWords = "Goal";

            // Act
            var goals = await goalService.GetMyAsync(userId, searchWords);

            // Debugging
            Console.WriteLine($"Actual Goals Count: {goals.Count()}");
            foreach (var goal in goals)
            {
                Console.WriteLine($"Goal Description: {goal.Description}");
                Console.WriteLine($"Goal Type: {goal.GoalType}");
                Console.WriteLine($"Goal Target Date: {goal.TargetDate}");
                Console.WriteLine($"Goal isCompleted: {goal.isCompleted}");
                Console.WriteLine($"Goal Target Weight: {goal.TargetWeight}");
            }

            // Assert
            Assert.AreEqual(2, goals.Count());
            Assert.IsTrue(goals.All(g => g.Description.Contains(searchWords)));
            Assert.AreEqual("Goal 1", goals.ElementAt(0).Description);
            Assert.AreEqual("Goal 2", goals.ElementAt(1).Description);
        }

        [TestMethod]
        public async Task GetGoalEdit_ReturnsCorrectGoalViewModel()
        {
            // Arrange
            var goalId = -1;

            // Act
            var viewModel = await goalService.GetGoalEdit(goalId);

            // Assert
            Assert.IsNotNull(viewModel);
            Assert.AreEqual(goalId, viewModel.GoalId);
        }

        [TestMethod]
        public async Task Remove_RemovesGoalFromDatabase()
        {
            // Arrange
            var goalId = -1;

            // Act
            await goalService.Remove(goalId);
            var deletedGoal = await context.Goals.FindAsync(goalId);

            // Assert
            Assert.IsNull(deletedGoal);
        }

        [TestMethod]
        public async Task Remove_ShouldNotRemovesGoalFromDatabase_GoalDoesNotExist()
        {
            // Arrange
            var invalidGoalId = -1000;

            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () =>
            {
                await goalService.Remove(invalidGoalId);
            });
        }

        [TestMethod]
        public async Task Update_UpdatesGoalInDatabase()
        {
            // Arrange
            var model = new UpdateGoalViewModel
            {
                GoalId = -1,
                Description = "Updated Goal",
                GoalType = GoalType.MuscleGain,
                TargetDate = DateTime.Now.AddDays(14),
                TargetWeight = 75
            };

            // Act
            await goalService.Update(model);
            var updatedGoal = await context.Goals.FindAsync(model.GoalId);

            // Assert
            Assert.IsNotNull(updatedGoal);
            Assert.AreEqual(model.Description, updatedGoal.Description);
            Assert.AreEqual(model.GoalType, updatedGoal.GoalType);
            Assert.AreEqual(model.TargetDate, updatedGoal.TargetDate);
            Assert.AreEqual(model.TargetWeight, updatedGoal.TargetWeight);
        }

        [TestMethod]
        public async Task Completed_MarksGoalAsCompletedInDatabase()
        {
            // Arrange
            var goalId = -1;

            // Act
            await goalService.Completed(goalId);
            var completedGoal = await context.Goals.FindAsync(goalId);

            // Assert
            Assert.IsNotNull(completedGoal);
            Assert.IsTrue(completedGoal.isCompleted);
            Assert.IsNotNull(completedGoal.CompletedDate);
        }

        [TestMethod]
        public async Task GetCompletedGoals_ReturnsCompletedGoalsForSpecificUser()
        {
            // Arrange
            var goalId = -1;
            var userId = "user1";

            // Act
            var completeGoal = goalService.Completed(goalId);
            var completedGoals = await goalService.GetCompletedGoals(userId);

            // Assert
            Assert.AreEqual(1, completedGoals.Count());
            Assert.IsTrue(completedGoals.All(g => g.isCompleted));
        }
    }

}

