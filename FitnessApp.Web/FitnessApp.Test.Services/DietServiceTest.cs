using FitnessApp.Data;
using FitnessApp.Services;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.Diet;
using FitnessApp.Web.ViewModels.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Test.Services
{

    [TestClass]
    public class DietServiceTest
    {
        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "FitnessDbTest")
            .Options;

        private ApplicationDbContext context;
        private IDietService dietService;

        [TestInitialize]
        public void Setup()
        {
            context = new ApplicationDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDataBase();
            dietService = new DietService(context);
        }

        [TestCleanup]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [TestMethod]
        public async Task GetAllDietsAsync_ShouldReturnDietsBasedOnSortingType()
        {
            // Arrange
            var expectedSortingType = SortType.Newest;

            // Act
            var result = await dietService.GetAllDietsAsync(expectedSortingType);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(d => d.SortingType == expectedSortingType));
        }

        [TestMethod]
        public async Task GetMyDiets_ShouldReturnDietsForUser()
        {
            // Arrange
            var userId = "test-user-id3";

            // Retrieve the seeded diets from the database
            var seededDiets = context.Diets.ToList();

            // Create user diets using the seeded diets
            var userDiets = seededDiets.Select(diet => new UserDiet
            {
                UserId = userId,
                Diet = diet
            }).ToList();
            context.UserDiets.AddRange(userDiets);
            context.SaveChanges();

            // Act
            var result = await dietService.GetMyDiets(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userDiets.Count, result.Count());
            Assert.IsTrue(result.All(d => d.UserIds.Contains(userId)));
        }

        [TestMethod]
        public async Task AddToCollection_ShouldAddDietToUserCollection()
        {
            // Arrange
            var userId = "test-user-id";
            var dietId = -1; // Use a unique diet ID

            // Act
            await dietService.AddToCollection(dietId, userId);

            // Assert
            var userDiet = await context.UserDiets
                .FirstOrDefaultAsync(ub => ub.UserId == userId && ub.DietId == dietId);
            Assert.IsNotNull(userDiet);
        }

        [TestMethod]
        public async Task RemoveFromCollection_ShouldRemoveDietFromUserCollection_WhenDietExists()
        {
            // Arrange
            var userId = "test-user-id3";
            var dietId = -1; // Use a unique diet ID

            // Add a user diet to the database
            var userDiet = new UserDiet
            {
                UserId = userId,
                DietId = dietId
            };
            context.UserDiets.Add(userDiet);
            context.SaveChanges();

            // Act
            await dietService.RemoveFromCollection(dietId, userId);

            // Assert
            var removedUserDiet = await context.UserDiets
                .FirstOrDefaultAsync(ud => ud.DietId == dietId && ud.UserId == userId);
            Assert.IsNull(removedUserDiet);
        }

        [TestMethod]
        public async Task RemoveFromCollection_ShouldNotRemoveDietFromUserCollection_WhenDietDoesNotExist()
        {
            // Arrange
            var userId = "test-user-id";
            var invalidDietId = -1000; // Use a unique diet ID

            // Act and Assert
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () =>
            {
                await dietService.RemoveFromCollection(invalidDietId, userId);
            });
        }
        [TestMethod]
        public async Task RemoveFromCollection_ShouldNotRemoveDietFromUserCollection_WhenUserDoesNotExist()
        {
            // Arrange
            var invalidUserId = "invalid";
            var invalidDietId = -1; // Use a unique diet ID

            // Act and Assert
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () =>
            {
                await dietService.RemoveFromCollection(invalidDietId, invalidUserId);
            });
        }

        [TestMethod]
        public async Task Remove_ShouldRemoveDiet_WhenDietExists()
        {
            // Arrange
            var dietId = -1; // Use a unique diet ID


            // Act
            await dietService.Remove(dietId);

            // Assert
            var removedDiet = await context.Diets.FindAsync(dietId);
            Assert.IsNull(removedDiet);
        }

        [TestMethod]
        public async Task Remove_ShouldNotRemoveDiet_WhenDietDoesNotExist()
        {
            // Arrange
            var invalidDietId = -1000; // Use a unique diet ID

            // Assert
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () =>
            {
                // Act
                await dietService.Remove(invalidDietId);
            });
        }

        [TestMethod]
        public async Task GetEditDiet_ShouldReturnUpdateDietViewModel_WhenDietExists()
        {
            // Arrange
            var diet = new Diet
            {
                DietId = -5,
                Name = "Test Diet",
                Description = "Test Description",
                CaloriesIntake = 1500,
                ImageUrl = "test.jpg"
            };

            context.Diets.Add(diet);
            context.SaveChanges();

            // Act
            var result = await dietService.GetEditDiet(diet.DietId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(diet.DietId, result.DietId);
            Assert.AreEqual(diet.Name, result.Name);
            Assert.AreEqual(diet.Description, result.Description);
            Assert.AreEqual(diet.CaloriesIntake, result.CaloriesIntake);
            Assert.AreEqual(diet.ImageUrl, result.ImageUrl);
        }

        [TestMethod]
        public async Task Edit_ShouldUpdateDiet_WhenDietExists()
        {
            // Arrange
            var diet = new Diet
            {
                DietId = -5,
                Name = "Test Diet",
                Description = "Test Description",
                CaloriesIntake = 1500,
                ImageUrl = "test.jpg"
            };

            context.Diets.Add(diet);
            context.SaveChanges();

            var model = new UpdateDietViewModel
            {
                DietId = diet.DietId,
                Name = "Updated Diet",
                Description = "Updated Description",
                CaloriesIntake = 1800,
                ImageUrl = "updated.jpg"
            };

            // Act
            await dietService.Edit(model);

            // Assert
            var updatedDiet = context.Diets.Find(diet.DietId);
            Assert.IsNotNull(updatedDiet);
            Assert.AreEqual(model.Name, updatedDiet.Name);
            Assert.AreEqual(model.Description, updatedDiet.Description);
            Assert.AreEqual(model.CaloriesIntake, updatedDiet.CaloriesIntake);
            Assert.AreEqual(model.ImageUrl, updatedDiet.ImageUrl);
        }

        [TestMethod]
        public async Task CreateAsync_ShouldAddNewDiet()
        {
            // Arrange
            var model = new AddDietViewModel
            {
                Name = "New Diet",
                Description = "New Description",
                CaloriesIntake = 2000,
                ImageUrl = "new.jpg"
            };

            // Act
            await dietService.CreateAsync(model);

            // Assert
            var createdDiet = context.Diets.FirstOrDefault(d => d.Name == model.Name && d.Description == model.Description && d.ImageUrl == model.ImageUrl);
            Assert.IsNotNull(createdDiet);
            Assert.AreEqual(model.Name, createdDiet.Name);
            Assert.AreEqual(model.Description, createdDiet.Description);
            Assert.AreEqual(model.CaloriesIntake, createdDiet.CaloriesIntake);
            Assert.AreEqual(model.ImageUrl, createdDiet.ImageUrl);
        }

        [TestMethod]
        public async Task GetAddModel_ShouldReturnAddDietViewModel()
        {
            // Act
            var result = await dietService.GetAddModel();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AddDietViewModel));
        }


        private void SeedDataBase()
        {
            var diets = new List<Diet>()
             {
             new Diet
             {
                DietId = -1, // Use negative value for unique identifier
                Name = "Diet 1",
                ImageUrl = "url1",
                Description = "Description 1",
                CaloriesIntake = 1500,
                UserDiets = new List<UserDiet>()
             },
             new Diet
             {
                   DietId = -2, // Use negative value for unique identifier
                   Name = "Diet 2",
                   ImageUrl = "url2",
                   Description = "Description 2",
                   CaloriesIntake = 1800,
                   UserDiets = new List<UserDiet>()
              },
             };

            var userDiets = new List<UserDiet>()
            {
                new UserDiet
                {
                    DietId = -1,
                    UserId = "test-user-id"
                },
                 new UserDiet
                {
                    DietId = -2,
                    UserId = "test-user-id2"
                }
            };
            context.Diets.AddRange(diets);
            context.UserDiets.AddRange(userDiets);
            context.SaveChanges();
        }

    }
}