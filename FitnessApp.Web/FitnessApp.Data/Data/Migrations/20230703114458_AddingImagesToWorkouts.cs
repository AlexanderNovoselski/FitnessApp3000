using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class AddingImagesToWorkouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Workouts");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 7, 3, 12, 37, 40, 318, DateTimeKind.Local).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 7, 3, 12, 37, 40, 318, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 7, 3, 12, 37, 40, 318, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 7, 3, 12, 37, 40, 318, DateTimeKind.Local).AddTicks(7532));
        }
    }
}
