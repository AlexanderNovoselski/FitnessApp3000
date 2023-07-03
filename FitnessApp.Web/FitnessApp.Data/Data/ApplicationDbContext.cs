using FitnessApp.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
		public DbSet<UserDiet> UserDiets { get; set; }
		public DbSet<Achievement> Achievements { get; set; }
		public DbSet<ExerciseWorkout> ExerciseWorkouts { get; set; }
		public DbSet<UserWorkout> UserWorkouts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<ExerciseWorkout>()
			.HasKey(ud => new { ud.ExerciseId, ud.WorkoutId });

            modelBuilder.Entity<UserWorkout>()
            .HasKey(ud => new { ud.UserId, ud.WorkoutId });

            modelBuilder.Entity<UserDiet>()
				 .HasKey(ud => new { ud.DietId, ud.UserId });

			modelBuilder.Entity<ExerciseWorkout>()
				.HasOne(ud => ud.Exercise)
				.WithMany(d => d.ExerciseWorkouts)
				.HasForeignKey(ud => ud.ExerciseId);

			modelBuilder.Entity<ExerciseWorkout>()
				.HasOne(ud => ud.Workout)
				.WithMany(u => u.ExerciseWorkouts)
				.HasForeignKey(ud => ud.WorkoutId);

			modelBuilder.Entity<UserDiet>()
				.HasOne(ud => ud.Diet)
				.WithMany(d => d.UserDiets)
				.HasForeignKey(ud => ud.DietId);

			modelBuilder.Entity<UserDiet>()
				.HasOne(ud => ud.User)
				.WithMany(u => u.UserDiets)
				.HasForeignKey(ud => ud.UserId);


			SeedData(modelBuilder);
		}
		private void SeedData(ModelBuilder modelBuilder)
		{
			var adminUserId = "fb4b829a-b532-4923-b2b2-c7b9819558ff"; // Replace with the ID of the admin user

			modelBuilder.Entity<Diet>().HasData(
				new Diet
				{
					DietId = 1,
					Name = "Sample Diet 1",
					ImageUrl = "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg",
					Description = "This is a sample diet plan.",
					CaloriesIntake = 2000
				},
				new Diet
				{
					DietId = 2,
					Name = "Sample Diet 2",
					ImageUrl = "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg",
					Description = "This is a sample diet plan.",
					CaloriesIntake = 1800
				},
				new Diet
				{
					DietId = 3,
					Name = "Sample Diet 3",
					ImageUrl = "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg",
					Description = "This is a sample diet plan.",
					CaloriesIntake = 1800
				},
				new Diet
				{
					DietId = 4,
					Name = "Sample Diet 4",
					ImageUrl = "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg",
					Description = "This is a sample diet plan.",
					CaloriesIntake = 1800
				});

			modelBuilder.Entity<UserDiet>().HasData(
				 new UserDiet { DietId = 1, UserId = "fb4b829a-b532-4923-b2b2-c7b9819558ff" },
				 new UserDiet { DietId = 2, UserId = "fb4b829a-b532-4923-b2b2-c7b9819558ff" }
			 );

		}
	}
}