using FitnessApp.DataLayer.Enums;
using FitnessApp.DataLayer.Models;
using FitnessApp.Enums;
using Microsoft.AspNetCore.Identity;
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
		public DbSet<UserDiet> UserDiets { get; set; }
		public DbSet<ExerciseWorkout> ExerciseWorkouts { get; set; }
		public DbSet<UserWorkout> UserWorkouts { get; set; }
		public DbSet<User> User { get; set; }

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
            // Seed the user
            var user = new User
            {
                Id = "b35ad7b1-5004-4f8e-8bed-99660a297608",
                UserName = "testuser@abv.com",
                NormalizedUserName = "TESTUSER@ABV.COM",
                Email = "testuser@abv.com",
                NormalizedEmail = "TESTUSER@ABV.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "0988766888",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                Age = 30,
                Gender = GenderType.Male,
                HeightInMeters = 1,
                HeightInCentimeters = 80,
                Weight = 70,
                Goals = new List<Goal>(),
                UserDiets = new List<UserDiet>(),
                UserWorkouts = new List<UserWorkout>()
            };

            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(user, "TestUser123");

            user.PasswordHash = hashedPassword;


            modelBuilder.Entity<User>().HasData(user);
            // Seed Diets
            modelBuilder.Entity<Diet>().HasData(
                new Diet
                {
                    DietId = 1,
                    Name = "Ketogenic diet",
                    ImageUrl = "https://ro.co/health-guide/wp-content/uploads/sites/5/2021/06/HG-Keto-Diet.png",
                    Description = "The ketogenic diet is a high-fat, adequate-protein, low-carbohydrate dietary therapy" +
                    " that in conventional medicine is used mainly to treat hard-to-control epilepsy in children.",
                    CaloriesIntake = 2000,
                    CreationDate = DateTime.Now,
                    UserDiets = new List<UserDiet>(),
                },
                new Diet
                {
                    DietId = 2,
                    Name = "Vegan Diet",
                    ImageUrl = "https://cdn-prod.medicalnewstoday.com/content/images/articles/324/324343/plant-meal.jpg",
                    Description = "Vegan diets are made up of only plant-based foods. This type of diet includes fruits," +
                    " vegetables, soy, legumes, nuts and nut butters, plant-based dairy alternatives, sprouted or fermented " +
                    "plant foods and whole grains. Vegan diets don't include animal foods",
                    CaloriesIntake = 1800,
                    CreationDate = DateTime.Now,
                    UserDiets = new List<UserDiet>()
                },
                new Diet
                {
                    DietId = 3,
                    Name = "Carnivore diet",
                    ImageUrl = "https://i.pinimg.com/originals/0c/aa/d3/0caad3ab82c32c3ad719a03dec4d46d0.png",
                    Description = "The Carnivore diet is a fad diet in which only animal products such as meat, eggs, and " +
                    "dairy are consumed. The carnivore diet is associated with pseudoscientific health claims.",
                    CaloriesIntake = 2300,
                    CreationDate = DateTime.Now,
                    UserDiets = new List<UserDiet>()
                }
            );

            // Seed Exercises
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    ExerciseId = 1,
                    Name = "Push ups",
                    Description = "Strong exercsise for developing strong chest",
                    Sets = 3,
                    Reps = 10,
                    ExerciseWorkouts = new List<ExerciseWorkout>()
                },
                new Exercise
                {
                    ExerciseId = 2,
                    Name = "Pull ups",
                    Description = "Strong exercsise for developing back muscles",
                    Sets = 4,
                    Reps = 12,
                    ExerciseWorkouts = new List<ExerciseWorkout>()
                },
                new Exercise
                {
                    ExerciseId = 3,
                    Name = "Squats",
                    Description = "Strong exercsise for developing strong leg",
                    Sets = 3,
                    Reps = 8,
                    ExerciseWorkouts = new List<ExerciseWorkout>()
                }
            );

            // Seed Goals
            modelBuilder.Entity<Goal>().HasData(
                new Goal
                {
                    GoalId = 1,
                    UserId = user.Id,
                    Description = "Gaining muscle for 30 days",
                    GoalType = GoalType.MuscleGain,
                    TargetWeight = 80,
                    isCompleted = false,
                    TargetDate = DateTime.Now.AddDays(30),
                },
                new Goal
                {
                    GoalId = 2,
                    UserId = user.Id,
                    Description = "Losing weight for the summer",
                    GoalType = GoalType.WeightLoss,
                    TargetWeight = 80,
                    isCompleted = false,
                    TargetDate = DateTime.Now.AddDays(45),
                },
                new Goal
                {
                    GoalId = 3,
                    UserId = user.Id,
                    Description = "Building muscle endurance and stamina",
                    GoalType = GoalType.Endurance,
                    TargetWeight = 80,
                    isCompleted = false,
                    TargetDate = DateTime.Now.AddDays(45),
                }
            );

            // Seed ExerciseWorkouts
            modelBuilder.Entity<ExerciseWorkout>().HasData(
                new ExerciseWorkout { ExerciseWorkoutId = 1, ExerciseId = 1, WorkoutId = 1 },
                new ExerciseWorkout { ExerciseWorkoutId = 2, ExerciseId = 2, WorkoutId = 2 },
                new ExerciseWorkout { ExerciseWorkoutId = 3, ExerciseId = 3, WorkoutId = 3 }
            );

           


            // Seed Workouts
            modelBuilder.Entity<Workout>().HasData(
                new Workout
                {
                    WorkoutId = 1,
                    Name = "Push Workout",
                    ImageUrl = "https://weighteasyloss.com/wp-content/uploads/2018/01/4-13.jpg",
                    Description = "n the “push” workout you train all the upper body pushing muscles, i.e. the chest, shoulders and triceps.",
                    Duration = 60,
                    CaloriesBurned = 300,
                    ExerciseWorkouts = new List<ExerciseWorkout>(),
                    UserWorkouts = new List<UserWorkout>()
                },
                new Workout
                {
                    WorkoutId = 2,
                    Name = "Pull Workout",
                    ImageUrl = "https://i.pinimg.com/originals/a3/2a/79/a32a795d8ff0811e9d3e840a88437f03.jpg",
                    Description = "In the “pull” workout you train all the upper body pulling muscles, i.e. the back and biceps.",
                    Duration = 60,
                    CaloriesBurned = 250,
                    ExerciseWorkouts = new List<ExerciseWorkout>(),
                    UserWorkouts = new List<UserWorkout>()
                },
                new Workout
                {
                    WorkoutId = 3,
                    Name = "Leg Workout",
                    ImageUrl = "https://i.pinimg.com/originals/ae/e6/e0/aee6e07be64c900166a750ed850d430f.jpg",
                    Description = "Leg day is the commonly used term for any day that you exercise, and your workout focuses on lower body moves instead of upper body ones.",
                    Duration = 60,
                    CaloriesBurned = 350,
                    ExerciseWorkouts = new List<ExerciseWorkout>(),
                    UserWorkouts = new List<UserWorkout>()
                }
            );

            // Seed UserDiets
            modelBuilder.Entity<UserDiet>().HasData(
                new UserDiet { UserId = user.Id, DietId = 1 },
                new UserDiet { UserId = user.Id, DietId = 2 },
                new UserDiet { UserId = user.Id, DietId = 3 }
            );

            // Seed UserWorkouts
            modelBuilder.Entity<UserWorkout>().HasData(
                new UserWorkout { UserId = user.Id, WorkoutId = 1 },
                new UserWorkout { UserId = user.Id, WorkoutId = 2 },
                new UserWorkout { UserId = user.Id, WorkoutId = 3 }
            );
        }
    }
}