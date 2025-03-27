using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RootedBack.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductAndFarmer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Consumer_cart",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Farmer_Admin",
                table: "Farmer");

            migrationBuilder.DropForeignKey(
                name: "Consumer_Order",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "Farmer_order",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "Order_Payment",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "Farmer_Prooduct",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "Product_Specification",
                table: "ProductSpecifications");

            migrationBuilder.DropForeignKey(
                name: "Sepcification_Product",
                table: "ProductSpecifications");

            migrationBuilder.DropForeignKey(
                name: "Product_Review",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "Review_Consumer",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Shipping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specification",
                table: "Specification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ProductID",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductS__7E348A2CA8112B49",
                table: "ProductSpecifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_OrderID",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Farmer",
                table: "Farmer");

            migrationBuilder.DropIndex(
                name: "IX_Farmer_VerifiedByAdminId",
                table: "Farmer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consumer",
                table: "Consumer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CArt",
                table: "Cart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "VerifiedByAdminId",
                table: "Farmer");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Payment",
                newName: "ConsumerID");

            migrationBuilder.RenameColumn(
                name: "FarmerID",
                table: "Order",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_FarmerID",
                table: "Order",
                newName: "IX_Order_ProductID");

            migrationBuilder.RenameColumn(
                name: "UserNamer",
                table: "Consumer",
                newName: "UserName");

            migrationBuilder.AlterDatabase(
                collation: "Arabic_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Review",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewID",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "unit",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StatusShpinng",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VerificationStatus",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "Pending",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldDefaultValue: "Pending");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Certificate",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "FarmName",
                table: "Farmer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Admin",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Admin",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Admin",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Admin",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(250)",
                oldFixedLength: true,
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Specific__A384CC1D1928F5E4",
                table: "Specification",
                column: "SpecificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Review__74BC79AE5A1F0831",
                table: "Review",
                column: "ReviewID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductS__7E348A2C3C9A37B0",
                table: "ProductSpecifications",
                columns: new[] { "ProductID", "SpecificationID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Payment__9B556A58EA1E90FD",
                table: "Payment",
                column: "PaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Farmer__731B88E8B91603B4",
                table: "Farmer",
                column: "FarmerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Consumer__63BBE99AE94399EC",
                table: "Consumer",
                column: "ConsumerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Cart__51BCD7971994E889",
                table: "Cart",
                column: "CartID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Admin__719FE4E84F1C5ADD",
                table: "Admin",
                column: "AdminID");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    imagesURL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__19093A2BB32FD215", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Consumer",
                table: "Cart",
                column: "ConsumerID",
                principalTable: "Consumer",
                principalColumn: "ConsumerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Consumer",
                table: "Order",
                column: "ConsumerID",
                principalTable: "Consumer",
                principalColumn: "ConsumerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product",
                table: "Order",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Farmer",
                table: "Product",
                column: "FarmerID",
                principalTable: "Farmer",
                principalColumn: "FarmerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories",
                table: "Product",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecifications_Product",
                table: "ProductSpecifications",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecifications_Specification",
                table: "ProductSpecifications",
                column: "SpecificationID",
                principalTable: "Specification",
                principalColumn: "SpecificationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Consumer",
                table: "Review",
                column: "ConsumerID",
                principalTable: "Consumer",
                principalColumn: "ConsumerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Consumer",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Consumer",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Farmer",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecifications_Product",
                table: "ProductSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecifications_Specification",
                table: "ProductSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Consumer",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Specific__A384CC1D1928F5E4",
                table: "Specification");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Review__74BC79AE5A1F0831",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductS__7E348A2C3C9A37B0",
                table: "ProductSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Payment__9B556A58EA1E90FD",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Farmer__731B88E8B91603B4",
                table: "Farmer");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Consumer__63BBE99AE94399EC",
                table: "Consumer");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Cart__51BCD7971994E889",
                table: "Cart");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Admin__719FE4E84F1C5ADD",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "unit",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StatusShpinng",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FarmName",
                table: "Farmer");

            migrationBuilder.RenameColumn(
                name: "ConsumerID",
                table: "Payment",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Order",
                newName: "FarmerID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ProductID",
                table: "Order",
                newName: "IX_Order_FarmerID");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Consumer",
                newName: "UserNamer");

            migrationBuilder.AlterDatabase(
                oldCollation: "Arabic_CI_AS");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Review",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewID",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "VerificationStatus",
                table: "Farmer",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "Pending",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldDefaultValue: "Pending");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Farmer",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Farmer",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Farmer",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Farmer",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Farmer",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Farmer",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Farmer",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Farmer",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Certificate",
                table: "Farmer",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<int>(
                name: "VerifiedByAdminId",
                table: "Farmer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Admin",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Admin",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Admin",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Admin",
                type: "nchar(250)",
                fixedLength: true,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specification",
                table: "Specification",
                column: "SpecificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ReviewID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductS__7E348A2CA8112B49",
                table: "ProductSpecifications",
                columns: new[] { "ProductID", "SpecificationID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "PaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Farmer",
                table: "Farmer",
                column: "FarmerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consumer",
                table: "Consumer",
                column: "ConsumerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CArt",
                table: "Cart",
                column: "CartID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "AdminID");

            migrationBuilder.CreateTable(
                name: "Shipping",
                columns: table => new
                {
                    ShippingID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ShippingMethod = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ShippingStatus = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Source = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    TrackingNumber = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductID",
                table: "Review",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderID",
                table: "Payment",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_VerifiedByAdminId",
                table: "Farmer",
                column: "VerifiedByAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_OrderID",
                table: "Shipping",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "Consumer_cart",
                table: "Cart",
                column: "ConsumerID",
                principalTable: "Consumer",
                principalColumn: "ConsumerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Farmer_Admin",
                table: "Farmer",
                column: "VerifiedByAdminId",
                principalTable: "Admin",
                principalColumn: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "Consumer_Order",
                table: "Order",
                column: "ConsumerID",
                principalTable: "Consumer",
                principalColumn: "ConsumerID");

            migrationBuilder.AddForeignKey(
                name: "Farmer_order",
                table: "Order",
                column: "FarmerID",
                principalTable: "Farmer",
                principalColumn: "FarmerID");

            migrationBuilder.AddForeignKey(
                name: "Order_Payment",
                table: "Payment",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "Farmer_Prooduct",
                table: "Product",
                column: "FarmerID",
                principalTable: "Farmer",
                principalColumn: "FarmerID");

            migrationBuilder.AddForeignKey(
                name: "Product_Specification",
                table: "ProductSpecifications",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "Sepcification_Product",
                table: "ProductSpecifications",
                column: "SpecificationID",
                principalTable: "Specification",
                principalColumn: "SpecificationID");

            migrationBuilder.AddForeignKey(
                name: "Product_Review",
                table: "Review",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "Review_Consumer",
                table: "Review",
                column: "ConsumerID",
                principalTable: "Consumer",
                principalColumn: "ConsumerID");
        }
    }
}
