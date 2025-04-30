using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace faig.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "EntryTime",
                table: "Presence",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "DepartureTime",
                table: "Presence",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EntryTime",
                table: "Presence",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DepartureTime",
                table: "Presence",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
