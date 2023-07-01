using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class AddingColCreationDateToDiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Diets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 7, 1, 9, 10, 21, 546, DateTimeKind.Local).AddTicks(7827));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 7, 1, 9, 10, 21, 546, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "DietId", "CaloriesIntake", "CreationDate", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 3, 1800, new DateTime(2023, 7, 1, 9, 10, 21, 546, DateTimeKind.Local).AddTicks(7859), "This is a sample diet plan.", "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg", "Sample Diet 3" },
                    { 4, 1800, new DateTime(2023, 7, 1, 9, 10, 21, 546, DateTimeKind.Local).AddTicks(7861), "This is a sample diet plan.", "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg", "Sample Diet 4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Diets");
        }
    }
}
