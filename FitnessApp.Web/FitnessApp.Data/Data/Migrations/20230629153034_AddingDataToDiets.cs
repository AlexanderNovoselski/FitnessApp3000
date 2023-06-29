using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class AddingDataToDiets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "DietId", "CaloriesIntake", "Description", "ImageUrl", "Name" },
                values: new object[] { 1, 2000, "This is a sample diet plan.", "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg", "Sample Diet 1" });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "DietId", "CaloriesIntake", "Description", "ImageUrl", "Name" },
                values: new object[] { 2, 1800, "This is a sample diet plan.", "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg", "Sample Diet 2" });

            migrationBuilder.InsertData(
                table: "UserDiets",
                columns: new[] { "DietId", "UserId" },
                values: new object[] { 1, "fb4b829a-b532-4923-b2b2-c7b9819558ff" });

            migrationBuilder.InsertData(
                table: "UserDiets",
                columns: new[] { "DietId", "UserId" },
                values: new object[] { 2, "fb4b829a-b532-4923-b2b2-c7b9819558ff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
