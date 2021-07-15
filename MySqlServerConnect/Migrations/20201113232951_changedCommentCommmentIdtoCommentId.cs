using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlServerConnect.Migrations
{
    public partial class changedCommentCommmentIdtoCommentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubcommentId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubcommentId",
                table: "Comments",
                type: "int",
                nullable: true);
        }
    }
}
