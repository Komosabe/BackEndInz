using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndInz.Migrations
{
    /// <inheritdoc />
    public partial class testowo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_labels_notes_NoteId",
                table: "labels");

            migrationBuilder.AddForeignKey(
                name: "FK_labels_notes_NoteId",
                table: "labels",
                column: "NoteId",
                principalTable: "notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_labels_notes_NoteId",
                table: "labels");

            migrationBuilder.AddForeignKey(
                name: "FK_labels_notes_NoteId",
                table: "labels",
                column: "NoteId",
                principalTable: "notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
