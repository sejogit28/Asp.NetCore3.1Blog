using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlServerConnect.Migrations
{
    public partial class ChangedDatePostedFromDateTimeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DatePosted",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
