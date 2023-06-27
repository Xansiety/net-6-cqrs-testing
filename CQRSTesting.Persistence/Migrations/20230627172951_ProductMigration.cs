using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRSTesting.Persistence.Migrations
{
    public partial class ProductMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "DateCreated", "DatePublished", "Description", "Name", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("331f5ce3-5357-4bd5-acc9-c44ce04f4040"), new DateTime(2023, 6, 27, 11, 29, 51, 436, DateTimeKind.Local).AddTicks(5552), new DateTime(2023, 6, 28, 11, 29, 51, 436, DateTimeKind.Local).AddTicks(5562), "Test Product", "Product 1", 100m },
                    { new Guid("398d3c2d-e5ee-4fb9-8978-a351ba15c432"), new DateTime(2023, 6, 27, 11, 29, 51, 436, DateTimeKind.Local).AddTicks(5613), new DateTime(2023, 6, 28, 11, 29, 51, 436, DateTimeKind.Local).AddTicks(5614), "Test Product", "Product 3", 500m },
                    { new Guid("935c8090-d996-4903-9bee-69d478b621e0"), new DateTime(2023, 6, 27, 11, 29, 51, 436, DateTimeKind.Local).AddTicks(5626), new DateTime(2023, 6, 28, 11, 29, 51, 436, DateTimeKind.Local).AddTicks(5626), "Test Product", "Product 4", 80m },
                    { new Guid("e27f324b-c16b-428e-a2b9-7911ee652ca4"), new DateTime(2023, 6, 27, 11, 29, 51, 436, DateTimeKind.Local).AddTicks(5599), new DateTime(2023, 6, 28, 11, 29, 51, 436, DateTimeKind.Local).AddTicks(5600), "Test Product", "Product 2", 120m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
