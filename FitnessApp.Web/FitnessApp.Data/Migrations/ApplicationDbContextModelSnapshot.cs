﻿// <auto-generated />
using System;
using FitnessApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessApp.DataLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Diet", b =>
                {
                    b.Property<int>("DietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DietId"), 1L, 1);

                    b.Property<int>("CaloriesIntake")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DietId");

                    b.ToTable("Diets");

                    b.HasData(
                        new
                        {
                            DietId = 1,
                            CaloriesIntake = 2000,
                            CreationDate = new DateTime(2023, 8, 2, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1759),
                            Description = "The ketogenic diet is a high-fat, adequate-protein, low-carbohydrate dietary therapy that in conventional medicine is used mainly to treat hard-to-control epilepsy in children.",
                            ImageUrl = "https://ro.co/health-guide/wp-content/uploads/sites/5/2021/06/HG-Keto-Diet.png",
                            Name = "Ketogenic diet"
                        },
                        new
                        {
                            DietId = 2,
                            CaloriesIntake = 1800,
                            CreationDate = new DateTime(2023, 8, 2, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1779),
                            Description = "Vegan diets are made up of only plant-based foods. This type of diet includes fruits, vegetables, soy, legumes, nuts and nut butters, plant-based dairy alternatives, sprouted or fermented plant foods and whole grains. Vegan diets don't include animal foods",
                            ImageUrl = "https://cdn-prod.medicalnewstoday.com/content/images/articles/324/324343/plant-meal.jpg",
                            Name = "Vegan Diet"
                        },
                        new
                        {
                            DietId = 3,
                            CaloriesIntake = 2300,
                            CreationDate = new DateTime(2023, 8, 2, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1787),
                            Description = "The Carnivore diet is a fad diet in which only animal products such as meat, eggs, and dairy are consumed. The carnivore diet is associated with pseudoscientific health claims.",
                            ImageUrl = "https://i.pinimg.com/originals/0c/aa/d3/0caad3ab82c32c3ad719a03dec4d46d0.png",
                            Name = "Carnivore diet"
                        });
                });

            modelBuilder.Entity("Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            ExerciseId = 1,
                            Description = "Strong exercsise for developing strong chest",
                            Name = "Push ups",
                            Reps = 10,
                            Sets = 3
                        },
                        new
                        {
                            ExerciseId = 2,
                            Description = "Strong exercsise for developing back muscles",
                            Name = "Pull ups",
                            Reps = 12,
                            Sets = 4
                        },
                        new
                        {
                            ExerciseId = 3,
                            Description = "Strong exercsise for developing strong leg",
                            Name = "Squats",
                            Reps = 8,
                            Sets = 3
                        });
                });

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseWorkoutId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ExerciseWorkouts");

                    b.HasData(
                        new
                        {
                            ExerciseId = 1,
                            WorkoutId = 1,
                            ExerciseWorkoutId = 1
                        },
                        new
                        {
                            ExerciseId = 2,
                            WorkoutId = 2,
                            ExerciseWorkoutId = 2
                        },
                        new
                        {
                            ExerciseId = 3,
                            WorkoutId = 3,
                            ExerciseWorkoutId = 3
                        });
                });

            modelBuilder.Entity("FitnessApp.DataLayer.Models.UserWorkout", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("UserWorkouts");

                    b.HasData(
                        new
                        {
                            UserId = "b35ad7b1-5004-4f8e-8bed-99660a297608",
                            WorkoutId = 1
                        },
                        new
                        {
                            UserId = "b35ad7b1-5004-4f8e-8bed-99660a297608",
                            WorkoutId = 2
                        },
                        new
                        {
                            UserId = "b35ad7b1-5004-4f8e-8bed-99660a297608",
                            WorkoutId = 3
                        });
                });

            modelBuilder.Entity("Goal", b =>
                {
                    b.Property<int>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoalId"), 1L, 1);

                    b.Property<DateTime>("CompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GoalType")
                        .HasColumnType("int");

                    b.Property<DateTime>("TargetDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TargetWeight")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isCompleted")
                        .HasColumnType("bit");

                    b.HasKey("GoalId");

                    b.HasIndex("UserId");

                    b.ToTable("Goals");

                    b.HasData(
                        new
                        {
                            GoalId = 1,
                            CompletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Gaining muscle for 30 days",
                            GoalType = 2,
                            TargetDate = new DateTime(2023, 8, 4, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1860),
                            TargetWeight = 80,
                            UserId = "b35ad7b1-5004-4f8e-8bed-99660a297608",
                            isCompleted = false
                        },
                        new
                        {
                            GoalId = 2,
                            CompletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Losing weight for the summer",
                            GoalType = 0,
                            TargetDate = new DateTime(2023, 9, 16, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1868),
                            TargetWeight = 80,
                            UserId = "b35ad7b1-5004-4f8e-8bed-99660a297608",
                            isCompleted = false
                        },
                        new
                        {
                            GoalId = 3,
                            CompletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Building muscle endurance and stamina",
                            GoalType = 3,
                            TargetDate = new DateTime(2023, 9, 16, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1874),
                            TargetWeight = 80,
                            UserId = "b35ad7b1-5004-4f8e-8bed-99660a297608",
                            isCompleted = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("HeightInCentimeters")
                        .HasColumnType("int");

                    b.Property<int>("HeightInMeters")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b35ad7b1-5004-4f8e-8bed-99660a297608",
                            AccessFailedCount = 0,
                            Age = 30,
                            ConcurrencyStamp = "31fe8893-24dc-452d-8446-251c0b66c33a",
                            Email = "testuser@abv.com",
                            EmailConfirmed = false,
                            Gender = 0,
                            HeightInCentimeters = 80,
                            HeightInMeters = 1,
                            LockoutEnabled = true,
                            NormalizedEmail = "TESTUSER@ABV.COM",
                            NormalizedUserName = "TESTUSER@ABV.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGK2J4BLrKpcvEUeiAwwwHjz7aA7O2B8lIm2xBokMavLp8tAvhITqGRJ78RAx1Grpg==",
                            PhoneNumber = "0988766888",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "84c444a4-e805-43dd-905a-8e9e7c298b40",
                            TwoFactorEnabled = false,
                            UserName = "testuser@abv.com",
                            Weight = 70.0
                        });
                });

            modelBuilder.Entity("UserDiet", b =>
                {
                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DietId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDiets");

                    b.HasData(
                        new
                        {
                            DietId = 1,
                            UserId = "b35ad7b1-5004-4f8e-8bed-99660a297608"
                        },
                        new
                        {
                            DietId = 2,
                            UserId = "b35ad7b1-5004-4f8e-8bed-99660a297608"
                        },
                        new
                        {
                            DietId = 3,
                            UserId = "b35ad7b1-5004-4f8e-8bed-99660a297608"
                        });
                });

            modelBuilder.Entity("Workout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkoutId"), 1L, 1);

                    b.Property<double>("CaloriesBurned")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkoutId");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            WorkoutId = 1,
                            CaloriesBurned = 300.0,
                            Description = "In the “push” workout you train all the upper body pushing muscles, i.e. the chest, shoulders and triceps.",
                            Duration = 60,
                            ImageUrl = "https://weighteasyloss.com/wp-content/uploads/2018/01/4-13.jpg",
                            Name = "Push Workout"
                        },
                        new
                        {
                            WorkoutId = 2,
                            CaloriesBurned = 250.0,
                            Description = "In the “pull” workout you train all the upper body pulling muscles, i.e. the back and biceps.",
                            Duration = 60,
                            ImageUrl = "https://i.pinimg.com/originals/a3/2a/79/a32a795d8ff0811e9d3e840a88437f03.jpg",
                            Name = "Pull Workout"
                        },
                        new
                        {
                            WorkoutId = 3,
                            CaloriesBurned = 350.0,
                            Description = "Leg day is the commonly used term for any day that you exercise, and your workout focuses on lower body.",
                            Duration = 60,
                            ImageUrl = "https://i.pinimg.com/originals/ae/e6/e0/aee6e07be64c900166a750ed850d430f.jpg",
                            Name = "Leg Workout"
                        });
                });

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.HasOne("Exercise", "Exercise")
                        .WithMany("ExerciseWorkouts")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workout", "Workout")
                        .WithMany("ExerciseWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("FitnessApp.DataLayer.Models.UserWorkout", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany("UserWorkouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workout", "Workout")
                        .WithMany("UserWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Goal", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany("Goals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserDiet", b =>
                {
                    b.HasOne("Diet", "Diet")
                        .WithMany("UserDiets")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany("UserDiets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Diet", b =>
                {
                    b.Navigation("UserDiets");
                });

            modelBuilder.Entity("Exercise", b =>
                {
                    b.Navigation("ExerciseWorkouts");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("Goals");

                    b.Navigation("UserDiets");

                    b.Navigation("UserWorkouts");
                });

            modelBuilder.Entity("Workout", b =>
                {
                    b.Navigation("ExerciseWorkouts");

                    b.Navigation("UserWorkouts");
                });
#pragma warning restore 612, 618
        }
    }
}
