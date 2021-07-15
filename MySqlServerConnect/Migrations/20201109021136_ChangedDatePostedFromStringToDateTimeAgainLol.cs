using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlServerConnect.Migrations
{
    public partial class ChangedDatePostedFromStringToDateTimeAgainLol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DatePosted",
                table: "Posts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
