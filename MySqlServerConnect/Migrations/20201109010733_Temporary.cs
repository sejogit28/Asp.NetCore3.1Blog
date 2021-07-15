using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlServerConnect.Migrations
{
    public partial class Temporary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateCreated",
                table: "Comments",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
