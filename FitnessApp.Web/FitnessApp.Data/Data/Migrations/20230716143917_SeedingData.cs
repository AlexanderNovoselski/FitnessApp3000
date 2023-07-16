using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserDiets",
                keyColumns: new[] { "DietId", "UserId" },
                keyValues: new object[] { 1, "fb4b829a-b532-4923-b2b2-c7b9819558ff" });

            migrationBuilder.DeleteData(
                table: "UserDiets",
                keyColumns: new[] { "DietId", "UserId" },
                keyValues: new object[] { 2, "fb4b829a-b532-4923-b2b2-c7b9819558ff" });

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "DietId", "CaloriesIntake", "CreationDate", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 3014, 2000, new DateTime(2023, 7, 16, 17, 39, 16, 843, DateTimeKind.Local).AddTicks(5906), "The ketogenic diet is a high-fat, adequate-protein, low-carbohydrate dietary therapy that in conventional medicine is used mainly to treat hard-to-control epilepsy in children. The diet forces the body to burn fats rather than carbohydrates.", "https://ro.co/health-guide/wp-content/uploads/sites/5/2021/06/HG-Keto-Diet.png", "Ketogenic diet" },
                    { 3015, 1800, new DateTime(2023, 7, 16, 17, 39, 16, 843, DateTimeKind.Local).AddTicks(5911), "Vegan diets are made up of only plant-based foods. This type of diet includes fruits, vegetables, soy, legumes, nuts and nut butters, plant-based dairy alternatives, sprouted or fermented plant foods and whole grains. Vegan diets don't include animal foods like eggs, dairy, meat, poultry or seafood.", "https://cdn-prod.medicalnewstoday.com/content/images/articles/324/324343/plant-meal.jpg", "Vegan Diet" },
                    { 3016, 2300, new DateTime(2023, 7, 16, 17, 39, 16, 843, DateTimeKind.Local).AddTicks(5915), "The Carnivore diet is a fad diet in which only animal products such as meat, eggs, and dairy are consumed. The carnivore diet is associated with pseudoscientific health claims. Such a diet can lead to deficiencies of vitamins and dietary fiber, and increase the risk of chronic diseases.", "https://i.pinimg.com/originals/0c/aa/d3/0caad3ab82c32c3ad719a03dec4d46d0.png", "Carnivore diet" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "Description", "Name", "Reps", "Sets" },
                values: new object[,]
                {
                    { 1, "Strong exercsise for developing strong chest", "Push ups", 10, 3 },
                    { 2, "Strong exercsise for developing back muscles", "Pull ups", 12, 4 },
                    { 3, "Strong exercsise for developing strong leg", "Squats", 8, 3 }
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "GoalId", "CompletedDate", "Description", "GoalType", "TargetDate", "TargetWeight", "UserId", "isCompleted" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaining muscle for 30 days", 2, new DateTime(2023, 8, 15, 17, 39, 16, 843, DateTimeKind.Local).AddTicks(6023), 80, "4f115243-ce00-43f3-a0e8-85df5d8d28cf", false },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Losing weight for the summer", 0, new DateTime(2023, 8, 30, 17, 39, 16, 843, DateTimeKind.Local).AddTicks(6028), 80, "4f115243-ce00-43f3-a0e8-85df5d8d28cf", false },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Building muscle endurance and stamina", 3, new DateTime(2023, 8, 30, 17, 39, 16, 843, DateTimeKind.Local).AddTicks(6030), 80, "4f115243-ce00-43f3-a0e8-85df5d8d28cf", false }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "WorkoutId", "CaloriesBurned", "Description", "Duration", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 300.0, "n the “push” workout you train all the upper body pushing muscles, i.e. the chest, shoulders and triceps.", 60, "https://weighteasyloss.com/wp-content/uploads/2018/01/4-13.jpg", "Push Workout" },
                    { 2, 250.0, "“Push” workouts train the chest, shoulders, and triceps, while “pull” workouts train the back, biceps, and forearms.", 60, "https://i.pinimg.com/originals/a3/2a/79/a32a795d8ff0811e9d3e840a88437f03.jpg", "Pull Workout" },
                    { 3, 350.0, "Leg day is the commonly used term for any day that you exercise, and your workout focuses on lower body moves instead of upper body ones.", 60, "https://i.pinimg.com/originals/ae/e6/e0/aee6e07be64c900166a750ed850d430f.jpg", "Workout 3" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseWorkouts",
                columns: new[] { "ExerciseId", "WorkoutId", "ExerciseWorkoutId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserDiets",
                columns: new[] { "DietId", "UserId" },
                values: new object[,]
                {
                    { 3014, "4f115243-ce00-43f3-a0e8-85df5d8d28cf" },
                    { 3015, "4f115243-ce00-43f3-a0e8-85df5d8d28cf" },
                    { 3016, "4f115243-ce00-43f3-a0e8-85df5d8d28cf" }
                });

            migrationBuilder.InsertData(
                table: "UserWorkouts",
                columns: new[] { "UserId", "WorkoutId" },
                values: new object[,]
                {
                    { "4f115243-ce00-43f3-a0e8-85df5d8d28cf", 1 },
                    { "4f115243-ce00-43f3-a0e8-85df5d8d28cf", 2 },
                    { "4f115243-ce00-43f3-a0e8-85df5d8d28cf", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseWorkouts",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ExerciseWorkouts",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ExerciseWorkouts",
                keyColumns: new[] { "ExerciseId", "WorkoutId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserDiets",
                keyColumns: new[] { "DietId", "UserId" },
                keyValues: new object[] { 3014, "4f115243-ce00-43f3-a0e8-85df5d8d28cf" });

            migrationBuilder.DeleteData(
                table: "UserDiets",
                keyColumns: new[] { "DietId", "UserId" },
                keyValues: new object[] { 3015, "4f115243-ce00-43f3-a0e8-85df5d8d28cf" });

            migrationBuilder.DeleteData(
                table: "UserDiets",
                keyColumns: new[] { "DietId", "UserId" },
                keyValues: new object[] { 3016, "4f115243-ce00-43f3-a0e8-85df5d8d28cf" });

            migrationBuilder.DeleteData(
                table: "UserWorkouts",
                keyColumns: new[] { "UserId", "WorkoutId" },
                keyValues: new object[] { "4f115243-ce00-43f3-a0e8-85df5d8d28cf", 1 });

            migrationBuilder.DeleteData(
                table: "UserWorkouts",
                keyColumns: new[] { "UserId", "WorkoutId" },
                keyValues: new object[] { "4f115243-ce00-43f3-a0e8-85df5d8d28cf", 2 });

            migrationBuilder.DeleteData(
                table: "UserWorkouts",
                keyColumns: new[] { "UserId", "WorkoutId" },
                keyValues: new object[] { "4f115243-ce00-43f3-a0e8-85df5d8d28cf", 3 });

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3014);

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3015);

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3016);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "DietId", "CaloriesIntake", "CreationDate", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 2000, new DateTime(2023, 7, 6, 17, 20, 0, 538, DateTimeKind.Local).AddTicks(8928), "This is a sample diet plan.", "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg", "Sample Diet 1" },
                    { 2, 1800, new DateTime(2023, 7, 6, 17, 20, 0, 538, DateTimeKind.Local).AddTicks(8957), "This is a sample diet plan.", "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg", "Sample Diet 2" },
                    { 3, 1800, new DateTime(2023, 7, 6, 17, 20, 0, 538, DateTimeKind.Local).AddTicks(8960), "This is a sample diet plan.", "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg", "Sample Diet 3" },
                    { 4, 1800, new DateTime(2023, 7, 6, 17, 20, 0, 538, DateTimeKind.Local).AddTicks(8962), "This is a sample diet plan.", "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg", "Sample Diet 4" }
                });

            migrationBuilder.InsertData(
                table: "UserDiets",
                columns: new[] { "DietId", "UserId" },
                values: new object[] { 1, "fb4b829a-b532-4923-b2b2-c7b9819558ff" });

            migrationBuilder.InsertData(
                table: "UserDiets",
                columns: new[] { "DietId", "UserId" },
                values: new object[] { 2, "fb4b829a-b532-4923-b2b2-c7b9819558ff" });
        }
    }
}
