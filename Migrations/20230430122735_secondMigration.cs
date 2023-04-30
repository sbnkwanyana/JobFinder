using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFinder.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobListings",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 4, 30, 14, 27, 34, 986, DateTimeKind.Local).AddTicks(9704));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobListings",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2023, 4, 30, 13, 54, 6, 806, DateTimeKind.Local).AddTicks(7551));
        }
    }
}
