using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DataLayer.Migrations
{
    public partial class InitSetupDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b35ad7b1-5004-4f8e-8bed-99660a297608",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31fe8893-24dc-452d-8446-251c0b66c33a", "AQAAAAEAACcQAAAAEGK2J4BLrKpcvEUeiAwwwHjz7aA7O2B8lIm2xBokMavLp8tAvhITqGRJ78RAx1Grpg==", "84c444a4-e805-43dd-905a-8e9e7c298b40" });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 8, 2, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 8, 2, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 8, 2, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 1,
                column: "TargetDate",
                value: new DateTime(2023, 8, 4, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2023, 9, 16, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2023, 9, 16, 20, 54, 45, 486, DateTimeKind.Local).AddTicks(1874));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b35ad7b1-5004-4f8e-8bed-99660a297608",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "343cec10-44ab-48b1-8eaa-a5d6368c8723", "AQAAAAEAACcQAAAAEK4Rn90cSIZF4PALXPlbSo9Ag4RUzY7w0ZCepHJ9F4poCOZNQUJYjCBp4L+vhc5YgA==", "e4d72eea-ea14-43b8-820c-87b8a714e8de" });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 8, 2, 20, 52, 28, 421, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 8, 2, 20, 52, 28, 421, DateTimeKind.Local).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 8, 2, 20, 52, 28, 421, DateTimeKind.Local).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 1,
                column: "TargetDate",
                value: new DateTime(2023, 8, 4, 20, 52, 28, 421, DateTimeKind.Local).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 2,
                column: "TargetDate",
                value: new DateTime(2023, 9, 16, 20, 52, 28, 421, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "GoalId",
                keyValue: 3,
                column: "TargetDate",
                value: new DateTime(2023, 9, 16, 20, 52, 28, 421, DateTimeKind.Local).AddTicks(5576));
        }
    }
}
