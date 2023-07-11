using FitnessApp.Data;
using FitnessApp.Services.Contracts;
using FitnessApp.Services;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Web.ViewModels.Models.User;
using FitnessApp.Enums;
using System.Runtime.Intrinsics.X86;

namespace FitnessApp.Test.Services
{
    [TestClass]
    public class UserServiceTest
    {
        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
         .UseInMemoryDatabase(databaseName: "FitnessDbTest")
         .Options;

        private ApplicationDbContext context;
        private IUserService userService;

        [TestInitialize]
        public void Setup()
        {
            context = new ApplicationDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDataBase();
            userService = new UserService(context);
        }

        [TestCleanup]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public async Task GetUsersAsync_ShouldReturnUserViewModels()
        {
            // Arrange
            var expectedUsers = await context.Users.ToListAsync();

            // Act
            var result = await userService.GetUsersAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUsers.Count, result.Count());
            Assert.IsTrue(result.All(u => u is UserViewModel));
        }

        [TestMethod]
        public async Task Remove_ShouldRemoveUser_WhenUserExists()
        {
            // Arrange
            var userEmail = "user1@example.com";

            // Act
            await userService.Remove(userEmail);

            // Assert
            var removedUser = await context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            Assert.IsNull(removedUser);
        }

        [TestMethod]
        public async Task Remove_ShouldNotRemoveUser_WhenUserDoesNotExist()
        {
            // Arrange
            var invalidUserEmail = "nonexistentuser@example.com";

            // Act
            await userService.Remove(invalidUserEmail);

            // Assert
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == invalidUserEmail);
            Assert.IsNull(user);
        }

        private void SeedDataBase()
        {
            var users = new List<User>
            {
                new User
                {
                    Email = "user1@example.com",
                    UserName = "User 1",
                    Age = 25,
                    Gender = GenderType.Male,
                    Weight = 70, HeightInMeters = 1,
                    HeightInCentimeters = 80
                },
                new User
                {
                    Email = "user2@example.com",
                    UserName = "User 2",
                    Age = 30,
                    Gender = GenderType.Male,
                    Weight = 60,
                    HeightInMeters = 1,
                    HeightInCentimeters = 60
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
