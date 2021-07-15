using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlServerConnect.Migrations
{
    public partial class changedCommentIdonSubCommentTableToBoolonCommentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSubcomment",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSubcomment",
                table: "Comments",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
