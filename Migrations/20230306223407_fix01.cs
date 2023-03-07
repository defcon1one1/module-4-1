using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace module_4_1.Migrations
{
    /// <inheritdoc />
    public partial class fix01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Modules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
