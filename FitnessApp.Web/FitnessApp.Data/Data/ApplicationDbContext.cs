using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diet>().HasData(
                new Diet
                {
                    DietId = 1,
                    UserId = "1b973072-066a-4e28-aa15-6d8fb38b0e58",
                    Name = "Sample Diet 1",
                    ImageUrl = "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg",
                    Description = "This is a sample diet plan.",
                    CaloriesIntake = 2000
                });
           
        }
    }
}