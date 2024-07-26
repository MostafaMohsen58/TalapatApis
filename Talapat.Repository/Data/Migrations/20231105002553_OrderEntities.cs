using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talapat.Repository.Data.Migrations
{
    public partial class OrderEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productBrands_productBrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_productTypeId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "productTypeId",
                table: "products",
                newName: "ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "productBrandId",
                table: "products",
                newName: "ProductBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_products_productTypeId",
                table: "products",
                newName: "IX_products_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_productBrandId",
                table: "products",
                newName: "IX_products_ProductBrandId");

            migrationBuilder.CreateTable(
                name: "DeliveyMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discribtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveyMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAddress_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAddress_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryMethodId = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentIntendId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_DeliveyMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveyMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ProductId = table.Column<int>(type: "int", nullable: false),
                    Product_ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_DeliveryMethodId",
                table: "orders",
                column: "DeliveryMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "products",
                column: "ProductBrandId",
                principalTable: "productBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "productTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productBrands_ProductBrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "DeliveyMethods");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "products",
                newName: "productTypeId");

            migrationBuilder.RenameColumn(
                name: "ProductBrandId",
                table: "products",
                newName: "productBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductTypeId",
                table: "products",
                newName: "IX_products_productTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductBrandId",
                table: "products",
                newName: "IX_products_productBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productBrands_productBrandId",
                table: "products",
                column: "productBrandId",
                principalTable: "productBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_productTypeId",
                table: "products",
                column: "productTypeId",
                principalTable: "productTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
