using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndInz.Migrations
{
    /// <inheritdoc />
    public partial class test09112023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_labels_notes_NoteId",
                table: "labels");

            migrationBuilder.DropIndex(
                name: "IX_labels_NoteId",
                table: "labels");

            migrationBuilder.CreateIndex(
                name: "IX_notes_LabelId",
                table: "notes",
                column: "LabelId",
                unique: true,
                filter: "[LabelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_labels_LabelId",
                table: "notes",
                column: "LabelId",
                principalTable: "labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notes_labels_LabelId",
                table: "notes");

            migrationBuilder.DropIndex(
                name: "IX_notes_LabelId",
                table: "notes");

            migrationBuilder.CreateIndex(
                name: "IX_labels_NoteId",
                table: "labels",
                column: "NoteId",
                unique: true,
                filter: "[NoteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_labels_notes_NoteId",
                table: "labels",
                column: "NoteId",
                principalTable: "notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
