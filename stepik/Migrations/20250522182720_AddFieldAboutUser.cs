using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stepik.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldAboutUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "about_me",
                table: "users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "about_me",
                table: "users");
        }
    }
}
