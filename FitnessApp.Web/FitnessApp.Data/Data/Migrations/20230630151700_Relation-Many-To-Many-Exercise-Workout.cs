using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class RelationManyToManyExerciseWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkout_Exercises_ExercisesExerciseId",
                table: "ExerciseWorkout");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkout_Workouts_WorkoutsWorkoutId",
                table: "ExerciseWorkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseWorkout",
                table: "ExerciseWorkout");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseWorkout_WorkoutsWorkoutId",
                table: "ExerciseWorkout");

            migrationBuilder.RenameTable(
                name: "ExerciseWorkout",
                newName: "ExerciseWorkouts");

            migrationBuilder.RenameColumn(
                name: "WorkoutsWorkoutId",
                table: "ExerciseWorkouts",
                newName: "ExerciseWorkoutId");

            migrationBuilder.RenameColumn(
                name: "ExercisesExerciseId",
                table: "ExerciseWorkouts",
                newName: "WorkoutId");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "ExerciseWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ExerciseWorkouts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseWorkouts",
                table: "ExerciseWorkouts",
                columns: new[] { "ExerciseId", "WorkoutId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkouts_UserId",
                table: "ExerciseWorkouts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkouts_WorkoutId",
                table: "ExerciseWorkouts",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkouts_AspNetUsers_UserId",
                table: "ExerciseWorkouts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkouts_Exercises_ExerciseId",
                table: "ExerciseWorkouts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkouts_Workouts_WorkoutId",
                table: "ExerciseWorkouts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkouts_AspNetUsers_UserId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkouts_Exercises_ExerciseId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkouts_Workouts_WorkoutId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseWorkouts",
                table: "ExerciseWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseWorkouts_UserId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseWorkouts_WorkoutId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExerciseWorkouts");

            migrationBuilder.RenameTable(
                name: "ExerciseWorkouts",
                newName: "ExerciseWorkout");

            migrationBuilder.RenameColumn(
                name: "ExerciseWorkoutId",
                table: "ExerciseWorkout",
                newName: "WorkoutsWorkoutId");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "ExerciseWorkout",
                newName: "ExercisesExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseWorkout",
                table: "ExerciseWorkout",
                columns: new[] { "ExercisesExerciseId", "WorkoutsWorkoutId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkout_WorkoutsWorkoutId",
                table: "ExerciseWorkout",
                column: "WorkoutsWorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkout_Exercises_ExercisesExerciseId",
                table: "ExerciseWorkout",
                column: "ExercisesExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkout_Workouts_WorkoutsWorkoutId",
                table: "ExerciseWorkout",
                column: "WorkoutsWorkoutId",
                principalTable: "Workouts",
                principalColumn: "WorkoutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
