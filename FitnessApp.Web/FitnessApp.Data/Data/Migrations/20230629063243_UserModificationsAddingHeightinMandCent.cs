using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Web.Data.Migrations
{
    public partial class UserModificationsAddingHeightinMandCent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Height",
                table: "AspNetUsers",
                newName: "HeightInMeters");

            migrationBuilder.AddColumn<int>(
                name: "HeightInCentimeters",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeightInCentimeters",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "HeightInMeters",
                table: "AspNetUsers",
                newName: "Height");
        }
    }
}
