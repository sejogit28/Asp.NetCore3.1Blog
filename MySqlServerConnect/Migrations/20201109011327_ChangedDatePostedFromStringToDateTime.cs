using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySqlServerConnect.Migrations
{
    public partial class ChangedDatePostedFromStringToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "varchar(100)",
                nullable: false);
               
                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DatePosted",
                table: "Posts",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
