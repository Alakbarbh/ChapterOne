using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChapterOne.Migrations
{
    public partial class AddColumnToAutobiographyOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Islarge",
                table: "AutobiographyOnes");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AutobiographyOnes",
                newName: "SmallImage");

            migrationBuilder.AddColumn<string>(
                name: "LargeImage",
                table: "AutobiographyOnes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LargeImage",
                table: "AutobiographyOnes");

            migrationBuilder.RenameColumn(
                name: "SmallImage",
                table: "AutobiographyOnes",
                newName: "Image");

            migrationBuilder.AddColumn<bool>(
                name: "Islarge",
                table: "AutobiographyOnes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
