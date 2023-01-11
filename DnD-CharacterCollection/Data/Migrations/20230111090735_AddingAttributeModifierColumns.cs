using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnD_CharacterCollection.Data.Migrations
{
    public partial class AddingAttributeModifierColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChaModifier",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConModifier",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DexModifier",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IntModifier",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StrModifier",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WisModifier",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaModifier",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "ConModifier",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "DexModifier",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "IntModifier",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "StrModifier",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "WisModifier",
                table: "Attributes");
        }
    }
}
