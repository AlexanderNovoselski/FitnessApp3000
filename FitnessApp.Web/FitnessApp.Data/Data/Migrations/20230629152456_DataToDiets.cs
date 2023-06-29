using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class DataToDiets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDiets",
                table: "UserDiets");

            migrationBuilder.DropIndex(
                name: "IX_UserDiets_DietId",
                table: "UserDiets");

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDiets",
                table: "UserDiets",
                columns: new[] { "DietId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_UserId",
                table: "UserDiets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDiets",
                table: "UserDiets");

            migrationBuilder.DropIndex(
                name: "IX_UserDiets_UserId",
                table: "UserDiets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDiets",
                table: "UserDiets",
                columns: new[] { "UserId", "DietId" });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "DietId", "CaloriesIntake", "Description", "ImageUrl", "Name" },
                values: new object[] { 1, 2000, "This is a sample diet plan.", "https://www.shutterstock.com/image-photo/balanced-diet-healthy-food-on-260nw-590825882.jpg", "Sample Diet 1" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDiets_DietId",
                table: "UserDiets",
                column: "DietId");
        }
    }
}
