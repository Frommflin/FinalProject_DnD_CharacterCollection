using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnD_CharacterCollection.Data.Migrations
{
    public partial class AddingCharacterColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Eyes",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hair",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Skin",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eyes",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Hair",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Skin",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Characters");
        }
    }
}
