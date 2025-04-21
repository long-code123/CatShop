using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeSupply = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cats_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "IsLoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsLoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IsLoves_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_IsLoves_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplyId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Supplies_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Persian Cat", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618), "Long-haired, calm and gentle.", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618) },
                    { 2, "Siamese Cat", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618), "Elegant with striking blue eyes and short coat.", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618) },
                    { 3, "Maine Coon", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618), "One of the largest domestic cats, fluffy and friendly.", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618) },
                    { 4, "Bengal Cat", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618), "Wild-looking coat, very active and playful.", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618) },
                    { 5, "Ragdoll", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618), "Blue-eyed and docile, loves to be cuddled.", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618) },
                    { 6, "British Shorthair", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618), "Stocky with a plush coat, very calm.", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618) },
                    { 7, "Scottish Fold", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618), "Known for its cute folded ears.", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618) },
                    { 8, "Sphynx Cat", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618), "Hairless breed, very affectionate and curious.", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618) },
                    { 9, "Abyssinian", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618), "Short coat with a wild, ticked fur pattern.", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618) },
                    { 10, "Norwegian Forest Cat", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618), "Thick coat, strong and agile climber.", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(8618) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "LoginType", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Hanoi", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415), "alice@example.com", 1, "Alice Nguyen", "password1", "0901234567", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415) },
                    { 2, "Saigon", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415), "bob@example.com", 1, "Bob Tran", "password2", "0912345678", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415) },
                    { 3, "Da Nang", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415), "charlie@example.com", 0, "Charlie Le", "password3", "0923456789", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415) },
                    { 4, "Can Tho", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415), "david@example.com", 1, "David Pham", "password4", "0934567890", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415) },
                    { 5, "Hue", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415), "evelyn@example.com", 0, "Evelyn Hoang", "password5", "0945678901", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415) },
                    { 6, "Vung Tau", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415), "frank@example.com", 1, "Frank Vo", "password6", "0956789012", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415) },
                    { 7, "Bien Hoa", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415), "grace@example.com", 0, "Grace Bui", "password7", "0967890123", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415) },
                    { 8, "Hai Phong", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415), "henry@example.com", 0, "Henry Do", "password8", "0978901234", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415) },
                    { 9, "Nha Trang", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415), "isabella@example.com", 0, "Isabella Dang", "password9", "0989012345", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415) },
                    { 10, "Quy Nhon", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415), "jackie@example.com", 0, "Jackie Lam", "password10", "0990123456", new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(4415) }
                });

            migrationBuilder.InsertData(
                table: "Supplies",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "Name", "Price", "Quantity", "TypeSupply", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494), "Premium dry cat food", "cat_food.jpg", "Cat Food", 12.5, 100, 0, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494) },
                    { 2, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494), "Easy clean litter box", "litter_box.jpg", "Litter Box", 20.0, 50, 3, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494) },
                    { 3, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494), "Pack of 10 toys", "cat_toys.jpg", "Cat Toys", 15.0, 200, 1, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494) },
                    { 4, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494), "Multi-level climbing tree", "cat_tree.jpg", "Cat Tree", 70.0, 30, 3, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494) },
                    { 5, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494), "Gentle cat shampoo", "cat_shampoo.jpg", "Cat Shampoo", 8.5, 40, 2, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494) },
                    { 6, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494), "Double bowl set", "food_bowl.jpg", "Food Bowl", 10.0, 100, 3, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494) },
                    { 7, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494), "Durable scratching post", "scratch_post.jpg", "Scratching Post", 25.0, 60, 1, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494) },
                    { 8, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494), "Portable carrier", "carrier_box.jpg", "Carrier Box", 35.0, 30, 3, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494) },
                    { 9, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494), "Soft bristle brush", "cat_brush.jpg", "Cat Brush", 7.5, 80, 3, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494) },
                    { 10, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494), "Healthy cat snacks", "cat_treats.jpg", "Cat Treats", 5.0, 120, 0, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(4494) }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedAt", "Description", "Image", "IsSold", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "2", 1, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240), "Playful Persian kitten", "milo.jpg", false, "Milo", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240) },
                    { 2, "1", 2, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240), "Elegant Siamese cat", "luna.jpg", false, "Luna", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240) },
                    { 3, "3", 3, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240), "Big and friendly Maine Coon", "leo.jpg", true, "Leo", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240) },
                    { 4, "1", 4, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240), "Energetic Bengal cat", "zara.jpg", false, "Zara", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240) },
                    { 5, "4", 5, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240), "Relaxed Ragdoll", "coco.jpg", true, "Coco", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240) },
                    { 6, "2", 6, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240), "Plush British Shorthair", "tom.jpg", false, "Tom", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240) },
                    { 7, "1", 7, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240), "Folded-ear cutie", "mimi.jpg", true, "Mimi", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240) },
                    { 8, "2", 8, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240), "Hairless Sphynx", "nala.jpg", false, "Nala", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240) },
                    { 9, "3", 9, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240), "Wild-looking Abyssinian", "simba.jpg", false, "Simba", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240) },
                    { 10, "5", 10, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240), "Big Norwegian climber", "oreo.jpg", true, "Oreo", new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(7240) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "PaymentStatus", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743), 1, 3, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743) },
                    { 2, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743), 2, 1, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743) },
                    { 3, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743), 3, 0, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743) },
                    { 4, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743), 4, 2, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743) },
                    { 5, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743), 5, 2, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743) },
                    { 6, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743), 6, 1, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743) },
                    { 7, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743), 7, 0, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743) },
                    { 8, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743), 8, 0, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743) },
                    { 9, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743), 9, 0, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743) },
                    { 10, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743), 10, 1, new DateTime(2025, 4, 19, 11, 22, 33, 305, DateTimeKind.Local).AddTicks(6743) }
                });

            migrationBuilder.InsertData(
                table: "IsLoves",
                columns: new[] { "Id", "CatId", "CreatedAt", "CustomerId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139), 1, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139) },
                    { 2, 2, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139), 2, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139) },
                    { 3, 3, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139), 3, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139) },
                    { 4, 4, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139), 4, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139) },
                    { 5, 5, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139), 5, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139) },
                    { 6, 6, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139), 6, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139) },
                    { 7, 7, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139), 7, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139) },
                    { 8, 8, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139), 8, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139) },
                    { 9, 9, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139), 9, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139) },
                    { 10, 10, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139), 10, new DateTime(2025, 4, 19, 11, 22, 33, 307, DateTimeKind.Local).AddTicks(3139) }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "CreatedAt", "OrderId", "Quantity", "SupplyId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069), 1, 2, 1, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069) },
                    { 2, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069), 2, 1, 3, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069) },
                    { 3, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069), 3, 1, 2, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069) },
                    { 4, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069), 4, 1, 4, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069) },
                    { 5, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069), 5, 2, 5, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069) },
                    { 6, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069), 6, 3, 6, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069) },
                    { 7, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069), 7, 1, 7, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069) },
                    { 8, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069), 8, 2, 8, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069) },
                    { 9, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069), 9, 1, 9, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069) },
                    { 10, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069), 10, 2, 10, new DateTime(2025, 4, 19, 11, 22, 33, 306, DateTimeKind.Local).AddTicks(3069) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cats_CategoryId",
                table: "Cats",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IsLoves_CatId",
                table: "IsLoves",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_IsLoves_CustomerId",
                table: "IsLoves",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SupplyId",
                table: "OrderDetails",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IsLoves");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
