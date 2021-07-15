using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlServerConnect.Migrations
{
    public partial class AddedSubcommmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCommentID",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Comments",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "CommentsCommentId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentsCommentId",
                table: "Comments",
                column: "CommentsCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentsCommentId",
                table: "Comments",
                column: "CommentsCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentsCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentsCommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentsCommentId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ParentCommentID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
