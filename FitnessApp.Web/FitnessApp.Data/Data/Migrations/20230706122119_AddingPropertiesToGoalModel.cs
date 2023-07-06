using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class AddingPropertiesToGoalModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalType",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "Goals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 7, 6, 15, 21, 18, 775, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 7, 6, 15, 21, 18, 775, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 7, 6, 15, 21, 18, 775, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 7, 6, 15, 21, 18, 775, DateTimeKind.Local).AddTicks(1784));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalType",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "Goals");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 7, 3, 14, 44, 58, 638, DateTimeKind.Local).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 7, 3, 14, 44, 58, 638, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 7, 3, 14, 44, 58, 638, DateTimeKind.Local).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 7, 3, 14, 44, 58, 638, DateTimeKind.Local).AddTicks(4420));
        }
    }
}
