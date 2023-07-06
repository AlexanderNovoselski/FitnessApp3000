using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class AddingPropToGoals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "Goals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 7, 6, 16, 55, 11, 716, DateTimeKind.Local).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 7, 6, 16, 55, 11, 716, DateTimeKind.Local).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 7, 6, 16, 55, 11, 716, DateTimeKind.Local).AddTicks(9625));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 7, 6, 16, 55, 11, 716, DateTimeKind.Local).AddTicks(9627));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "Goals");

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
    }
}
