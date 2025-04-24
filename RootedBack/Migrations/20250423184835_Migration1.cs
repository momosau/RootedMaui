using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RootedBack.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
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
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImagesUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Consumer",
                columns: table => new
                {
                    ConsumerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserNamer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HouseNum = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumer", x => x.ConsumerID);
                });

            migrationBuilder.CreateTable(
                name: "Farmer",
                columns: table => new
                {
                    FarmerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Certificate = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VerificationStatus = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('Pending')"),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FarmName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FarmNum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.FarmerID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerID = table.Column<int>(type: "int", nullable: true),
                    ConsumerID = table.Column<int>(type: "int", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "FarmerApplication",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    SubmitDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Certificate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ImageURL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    VerificationStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FarmName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FarmNum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerApplication", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_AdminAplication",
                        column: x => x.AdminID,
                        principalTable: "Admin",
                        principalColumn: "AdminID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FarmerID = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_CategoryProduct",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "Farmer_Prooduct",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CArt", x => x.CartID);
                    table.ForeignKey(
                        name: "Consumer_cart",
                        column: x => x.ConsumerID,
                        principalTable: "Consumer",
                        principalColumn: "ConsumerID");
                    table.ForeignKey(
                        name: "FK_Cart_product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ConsumerID = table.Column<int>(type: "int", nullable: false),
                    FarmerID = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HouseNum = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
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
                        name: "FK_Order_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "Farmer_order",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FarmerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_FarmerReview",
                        column: x => x.FarmerID,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID");
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

            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    SpecificationID = table.Column<int>(type: "int", nullable: false),
                    IsOrganic = table.Column<bool>(type: "bit", nullable: true),
                    IsGMOFree = table.Column<bool>(type: "bit", nullable: true),
                    IsHydroponicallyGrown = table.Column<bool>(type: "bit", nullable: true),
                    IsPesticideFree = table.Column<bool>(type: "bit", nullable: true),
                    IsLocal = table.Column<bool>(type: "bit", nullable: true),
                    FarmerId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    FarmerApplicationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.SpecificationID);
                    table.ForeignKey(
                        name: "FK_Specification_Farmer",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "FarmerID");
                    table.ForeignKey(
                        name: "FK_Specification_FarmerAPpliaction",
                        column: x => x.FarmerApplicationId,
                        principalTable: "FarmerApplication",
                        principalColumn: "ApplicationID");
                    table.ForeignKey(
                        name: "FK_Specification_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ConsumerID",
                table: "Cart",
                column: "ConsumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductID",
                table: "Cart",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerApplication_AdminID",
                table: "FarmerApplication",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ConsumerID",
                table: "Order",
                column: "ConsumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_FarmerID",
                table: "Order",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductID",
                table: "Order",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderID",
                table: "Payment",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FarmerID",
                table: "Product",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ConsumerID",
                table: "Review",
                column: "ConsumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_FarmerID",
                table: "Review",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductID",
                table: "Review",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Applocation",
                table: "Specification",
                column: "FarmerApplicationId",
                unique: true,
                filter: "[FarmerApplicationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer",
                table: "Specification",
                column: "FarmerId",
                unique: true,
                filter: "[FarmerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product",
                table: "Specification",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Specification");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "FarmerApplication");

            migrationBuilder.DropTable(
                name: "Consumer");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Farmer");
        }
    }
}
