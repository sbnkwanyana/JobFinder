using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobFinder.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobListings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Company = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    DatePosted = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobListings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JobListings",
                columns: new[] { "Id", "Company", "DatePosted", "Description", "Location", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "Google", new DateTime(2023, 4, 30, 13, 54, 6, 806, DateTimeKind.Local).AddTicks(7551), "C# Programmer", "Johannesburg, South Africa", "C#Developer", null },
                    { 2, "Amazon", new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Node Developer", "Cape Town, South Africa", "JavaScript/TypeScript Developer", null },
                    { 3, "Microsoft", new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data Science Developer", "Durban, South Africa", "Python Developer", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobListings");
        }
    }
}
