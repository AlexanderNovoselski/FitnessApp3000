using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class Customizing_User_DietMany_To_Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_AspNetUsers_UserId",
                table: "Diets");

            migrationBuilder.DropIndex(
                name: "IX_Diets_UserId",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Diets");

            migrationBuilder.CreateTable(
                name: "UserDiet",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiet", x => new { x.UserId, x.DietId });
                    table.ForeignKey(
                        name: "FK_UserDiet_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDiet_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "DietId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDiet_DietId",
                table: "UserDiet",
                column: "DietId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDiet");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Diets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "DietId",
                keyValue: 1,
                column: "UserId",
                value: "1b973072-066a-4e28-aa15-6d8fb38b0e58");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserId",
                table: "Diets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_AspNetUsers_UserId",
                table: "Diets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
