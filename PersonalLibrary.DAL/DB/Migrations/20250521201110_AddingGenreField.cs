using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibrary.DAL.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddingGenreField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Book");
        }
    }
}
