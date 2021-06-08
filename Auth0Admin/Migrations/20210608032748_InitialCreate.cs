using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0Admin.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FeaturedImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrls = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "DateTime", "Description", "FeaturedImageUrl", "Location", "Name", "ImageUrls" },
                values: new object[] { 1, "Fundraising", new DateTime(2019, 12, 25, 11, 30, 0, 0, DateTimeKind.Unspecified), "Spend an elegant night of dinner and dancing with us as we raise money for our new rescue farm.", "https://placekitten.com/500/500", "1234 Fancy Ave.", "Charity Ball", "[\"https://placekitten.com/500/500\", \"https://placekitten.com/500/500\", \"https://placekitten.com/500/500\"]" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "DateTime", "Description", "FeaturedImageUrl", "Location", "Name", "ImageUrls" },
                values: new object[] { 2, "Adoptions", new DateTime(2019, 11, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), "Come to our donation drive to help us replenish our stock of pet food, toys, bedding, etc. We will have live bands, games, food trucks, and much more.", "https://placekitten.com/500/500", "1234 Dog Alley", "Rescue Center Goods Drive", "[\"https://placekitten.com/500/500\"]" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
