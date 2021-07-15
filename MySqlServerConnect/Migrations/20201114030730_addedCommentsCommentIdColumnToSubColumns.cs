using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlServerConnect.Migrations
{
    public partial class addedCommentsCommentIdColumnToSubColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentsCommentId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentsCommentId",
                table: "Comments",
                column: "CommentsCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentsCommentId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentsCommentId",
                table: "Comments",
                column: "CommentsCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
