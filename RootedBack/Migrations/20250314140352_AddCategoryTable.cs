using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RootedBack.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nchar(250)", fixedLength: true, maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    UserName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Consumer",
                columns: table => new
                {
                    ConsumerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Location = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    UserNamer = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumer", x => x.ConsumerID);
                });

            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    SpecificationID = table.Column<int>(type: "int", nullable: false),
                    IsLocal = table.Column<bool>(type: "bit", nullable: true),
                    IsOrganic = table.Column<bool>(type: "bit", nullable: true),
                    IsGMOFree = table.Column<bool>(type: "bit", nullable: true),
                    IsHydroponicallyGrown = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.SpecificationID);
                });

            migrationBuilder.CreateTable(
                name: "Farmer",
                columns: table => new
                {
                    FarmerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Certificate = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Location = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    VerificationStatus = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, defaultValue: "Pending"),
                    VerifiedByAdminId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.FarmerID);
                    table.ForeignKey(
                        name: "FK_Farmer_Admin",
                        column: x => x.VerifiedByAdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminID");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerID = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CArt", x => x.CartID);
                    table.ForeignKey(
                        name: "Consumer_cart",
                        column: x => x.ConsumerID,
                        principalTable: "Consumer",
                        principalColumn: "ConsumerID");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Status = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ConsumerID = table.Column<int>(type: "int", nullable: false),
                    FarmerID = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShippingAddress = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "Consumer_Order",
                        column: x => x.ConsumerID,
                        principalTable: "Consumer",
                        principalColumn: "ConsumerID");
                    table.ForeignKey(
                        name: "Farmer_order",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    FarmerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "Farmer_Prooduct",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Status = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "Order_Payment",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "Shipping",
                columns: table => new
                {
                    ShippingID = table.Column<int>(type: "int", nullable: false),
                    ShippingStatus = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ShippingMethod = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Source = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Destination = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    TrackingNumber = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping", x => x.ShippingID);
                    table.ForeignKey(
                        name: "Order_Shipping",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecifications",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SpecificationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductS__7E348A2CA8112B49", x => new { x.ProductID, x.SpecificationID });
                    table.ForeignKey(
                        name: "Product_Specification",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "Sepcification_Product",
                        column: x => x.SpecificationID,
                        principalTable: "Specification",
                        principalColumn: "SpecificationID");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false),
                    ConsumerID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Comment = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "Product_Review",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "Review_Consumer",
                        column: x => x.ConsumerID,
                        principalTable: "Consumer",
                        principalColumn: "ConsumerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ConsumerID",
                table: "Cart",
                column: "ConsumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_VerifiedByAdminId",
                table: "Farmer",
                column: "VerifiedByAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ConsumerID",
                table: "Order",
                column: "ConsumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_FarmerID",
                table: "Order",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderID",
                table: "Payment",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FarmerID",
                table: "Product",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_SpecificationID",
                table: "ProductSpecifications",
                column: "SpecificationID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ConsumerID",
                table: "Review",
                column: "ConsumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductID",
                table: "Review",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_OrderID",
                table: "Shipping",
                column: "OrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "ProductSpecifications");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Shipping");

            migrationBuilder.DropTable(
                name: "Specification");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Consumer");

            migrationBuilder.DropTable(
                name: "Farmer");

            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
