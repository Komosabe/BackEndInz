using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndInz.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAutomated",
                table: "boards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAutomated",
                table: "boards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
