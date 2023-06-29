using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class AddingDbSetOfUserDiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDiet_AspNetUsers_UserId",
                table: "UserDiet");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDiet_Diets_DietId",
                table: "UserDiet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDiet",
                table: "UserDiet");

            migrationBuilder.RenameTable(
                name: "UserDiet",
                newName: "UserDiets");

            migrationBuilder.RenameIndex(
                name: "IX_UserDiet_DietId",
                table: "UserDiets",
                newName: "IX_UserDiets_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDiets",
                table: "UserDiets",
                columns: new[] { "UserId", "DietId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiets_AspNetUsers_UserId",
                table: "UserDiets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiets_Diets_DietId",
                table: "UserDiets",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "DietId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDiets_AspNetUsers_UserId",
                table: "UserDiets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDiets_Diets_DietId",
                table: "UserDiets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDiets",
                table: "UserDiets");

            migrationBuilder.RenameTable(
                name: "UserDiets",
                newName: "UserDiet");

            migrationBuilder.RenameIndex(
                name: "IX_UserDiets_DietId",
                table: "UserDiet",
                newName: "IX_UserDiet_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDiet",
                table: "UserDiet",
                columns: new[] { "UserId", "DietId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiet_AspNetUsers_UserId",
                table: "UserDiet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiet_Diets_DietId",
                table: "UserDiet",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "DietId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
