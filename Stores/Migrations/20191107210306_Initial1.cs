using Microsoft.EntityFrameworkCore.Migrations;

namespace Stores.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OpeningTime = table.Column<string>(nullable: true),
                    ClosingTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "StoreId" },
                values: new object[,]
                {
                    { 1, "Very very tasty", "Chicken Burger", 2 },
                    { 2, "Heavenly pleasure", "Macaron", 3 },
                    { 3, "So cold", "IceCream BN", 1 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Address", "ClosingTime", "Name", "OpeningTime" },
                values: new object[,]
                {
                    { 1, "MoMo", "22:00", "Baskin Robbins", "10:00" },
                    { 2, "Galileo", "23:00", "McDonalds", "06:00" },
                    { 3, "Prytytskogo 156", "23:00", "BonGenie", "10:00" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
