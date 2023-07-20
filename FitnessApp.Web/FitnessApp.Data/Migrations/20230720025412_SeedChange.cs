using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DataLayer.Migrations
{
    public partial class SeedChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b35ad7b1-5004-4f8e-8bed-99660a297608",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "e76526dc-e6c4-4733-9536-cedee66599d0", "AQAAAAEAACcQAAAAEAyh4Uf0R2kqpA1zXYjsPuBB9votaaFWBOTLgqmfyUl9soRVg77uKr+lFWUZXEwrbw==", "0988766888", "2f2a3659-8621-442a-8866-09334a764599" });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 7, 19, 18, 54, 11, 850, DateTimeKind.Local).AddTicks(8477));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 7, 19, 18, 54, 11, 850, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 7, 19, 18, 54, 11, 850, DateTimeKind.Local).AddTicks(8488));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 1,
                column: "TargetDate",
                value: new DateTime(2023, 8, 18, 18, 54, 11, 850, DateTimeKind.Local).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2023, 9, 2, 18, 54, 11, 850, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2023, 9, 2, 18, 54, 11, 850, DateTimeKind.Local).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 2,
                column: "Description",
                value: "In the “pull” workout you train all the upper body pulling muscles, i.e. the back and biceps.");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 3,
                column: "Name",
                value: "Leg Workout");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b35ad7b1-5004-4f8e-8bed-99660a297608",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { null, "AQAAAAEAACcQAAAAEOJxxYw1u0w+3p1p2F8ubJsB3XvdxpeCiMiKzqsTaiyUaAmneMOmtVFxmLOYboQgTQ==", null, null });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 7, 18, 8, 54, 54, 743, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 7, 18, 8, 54, 54, 743, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 7, 18, 8, 54, 54, 743, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 1,
                column: "TargetDate",
                value: new DateTime(2023, 8, 17, 8, 54, 54, 743, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2023, 9, 1, 8, 54, 54, 743, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2023, 9, 1, 8, 54, 54, 743, DateTimeKind.Local).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 2,
                column: "Description",
                value: "“Push” workouts train the chest, shoulders, and triceps, while “pull” workouts train the back, biceps, and forearms.");

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "WorkoutId",
                keyValue: 3,
                column: "Name",
                value: "Workout 3");
        }
    }
}
