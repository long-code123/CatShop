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
                    { 1, "Persian Cat", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040), "Long-haired, calm and gentle.", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040) },
                    { 2, "Siamese Cat", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040), "Elegant with striking blue eyes and short coat.", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040) },
                    { 3, "Maine Coon", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040), "One of the largest domestic cats, fluffy and friendly.", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040) },
                    { 4, "Bengal Cat", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040), "Wild-looking coat, very active and playful.", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040) },
                    { 5, "Ragdoll", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040), "Blue-eyed and docile, loves to be cuddled.", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040) },
                    { 6, "British Shorthair", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040), "Stocky with a plush coat, very calm.", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040) },
                    { 7, "Scottish Fold", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040), "Known for its cute folded ears.", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040) },
                    { 8, "Sphynx Cat", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040), "Hairless breed, very affectionate and curious.", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040) },
                    { 9, "Abyssinian", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040), "Short coat with a wild, ticked fur pattern.", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040) },
                    { 10, "Norwegian Forest Cat", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040), "Thick coat, strong and agile climber.", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(3040) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "LoginType", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Hanoi", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877), "alice@example.com", 1, "Alice Nguyen", "$2a$11$6J4lR0yC8IcHzc33LGUX7uJPtdpsYKvIL.Qgfg/Vv18XYqPetmi.e", "0901234567", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877) },
                    { 2, "Saigon", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877), "bob@example.com", 1, "Bob Tran", "$2a$11$QEKNyRiR06SAcxfmXw6ma.3zhg.kkqAQt14zFjKePcaQ/BwJrQqfi", "0912345678", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877) },
                    { 3, "Da Nang", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877), "charlie@example.com", 0, "Charlie Le", "$2a$11$88n7DgnMbjQJXmTuueIOAuJUck2BAiZfXsQDSL36YgUeCncMaDFkG", "0923456789", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877) },
                    { 4, "Can Tho", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877), "david@example.com", 1, "David Pham", "$2a$11$8DcelmAa3P508RfQPUt.Ju5JVUh/oAojD4i/v9hiSlejyttWBdCg2", "0934567890", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877) },
                    { 5, "Hue", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877), "evelyn@example.com", 0, "Evelyn Hoang", "$2a$11$NhoyEoQPgYTN47NTbV2DM.PTPsPVZdGxW.d4zQrc5tXnrYAm5VXkq", "0945678901", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877) },
                    { 6, "Vung Tau", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877), "frank@example.com", 1, "Frank Vo", "$2a$11$T5W7mu0A6TXPv5TUhDSRCOXEYrs18k4tuU2yJM12po7m/hq.CE2yS", "0956789012", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877) },
                    { 7, "Bien Hoa", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877), "grace@example.com", 0, "Grace Bui", "$2a$11$B44LvviD96qkQrsV9wt3F.G68vyPq7Lh6Zk0rcH8WV7md65w8ud7a", "0967890123", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877) },
                    { 8, "Hai Phong", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877), "henry@example.com", 0, "Henry Do", "$2a$11$R2rMA6P14knnOIxlb5t5GuJAAuUIsVa1Qndeye1Cg1.seH1OvlFFO", "0978901234", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877) },
                    { 9, "Nha Trang", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877), "isabella@example.com", 0, "Isabella Dang", "$2a$11$.qvTLYi4fzC8MJ2jouipk..A7FRpvuz9zmuGSMBSuH1HkNO8m7a56", "0989012345", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877) },
                    { 10, "Quy Nhon", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877), "jackie@example.com", 0, "Jackie Lam", "$2a$11$qgv/XgamLCh72RfutAOoUOu0fPwBMzATPgqhYeVa9RohgaiVebNJm", "0990123456", new DateTime(2025, 4, 24, 14, 21, 19, 138, DateTimeKind.Local).AddTicks(877) }
                });

            migrationBuilder.InsertData(
                table: "Supplies",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "Name", "Price", "Quantity", "TypeSupply", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105), "Premium dry cat food", "cat_food.jpg", "Cat Food", 12.5, 100, 0, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105) },
                    { 2, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105), "Easy clean litter box", "litter_box.jpg", "Litter Box", 20.0, 50, 3, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105) },
                    { 3, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105), "Pack of 10 toys", "cat_toys.jpg", "Cat Toys", 15.0, 200, 1, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105) },
                    { 4, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105), "Multi-level climbing tree", "cat_tree.jpg", "Cat Tree", 70.0, 30, 3, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105) },
                    { 5, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105), "Gentle cat shampoo", "cat_shampoo.jpg", "Cat Shampoo", 8.5, 40, 2, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105) },
                    { 6, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105), "Double bowl set", "food_bowl.jpg", "Food Bowl", 10.0, 100, 3, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105) },
                    { 7, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105), "Durable scratching post", "scratch_post.jpg", "Scratching Post", 25.0, 60, 1, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105) },
                    { 8, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105), "Portable carrier", "carrier_box.jpg", "Carrier Box", 35.0, 30, 3, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105) },
                    { 9, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105), "Soft bristle brush", "cat_brush.jpg", "Cat Brush", 7.5, 80, 3, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105) },
                    { 10, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105), "Healthy cat snacks", "cat_treats.jpg", "Cat Treats", 5.0, 120, 0, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(7105) }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "Age", "CategoryId", "CreatedAt", "Description", "Image", "IsSold", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "2", 1, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267), "Playful Persian kitten", "milo.jpg", false, "Milo", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267) },
                    { 2, "1", 2, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267), "Elegant Siamese cat", "luna.jpg", false, "Luna", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267) },
                    { 3, "3", 3, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267), "Big and friendly Maine Coon", "leo.jpg", true, "Leo", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267) },
                    { 4, "1", 4, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267), "Energetic Bengal cat", "zara.jpg", false, "Zara", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267) },
                    { 5, "4", 5, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267), "Relaxed Ragdoll", "coco.jpg", true, "Coco", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267) },
                    { 6, "2", 6, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267), "Plush British Shorthair", "tom.jpg", false, "Tom", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267) },
                    { 7, "1", 7, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267), "Folded-ear cutie", "mimi.jpg", true, "Mimi", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267) },
                    { 8, "2", 8, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267), "Hairless Sphynx", "nala.jpg", false, "Nala", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267) },
                    { 9, "3", 9, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267), "Wild-looking Abyssinian", "simba.jpg", false, "Simba", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267) },
                    { 10, "5", 10, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267), "Big Norwegian climber", "oreo.jpg", true, "Oreo", new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(1267) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "PaymentStatus", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768), 1, 3, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768) },
                    { 2, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768), 2, 1, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768) },
                    { 3, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768), 3, 0, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768) },
                    { 4, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768), 4, 2, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768) },
                    { 5, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768), 5, 2, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768) },
                    { 6, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768), 6, 1, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768) },
                    { 7, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768), 7, 0, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768) },
                    { 8, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768), 8, 0, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768) },
                    { 9, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768), 9, 0, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768) },
                    { 10, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768), 10, 1, new DateTime(2025, 4, 24, 14, 21, 19, 135, DateTimeKind.Local).AddTicks(7768) }
                });

            migrationBuilder.InsertData(
                table: "IsLoves",
                columns: new[] { "Id", "CatId", "CreatedAt", "CustomerId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227), 1, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227) },
                    { 2, 2, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227), 2, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227) },
                    { 3, 3, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227), 3, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227) },
                    { 4, 4, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227), 4, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227) },
                    { 5, 5, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227), 5, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227) },
                    { 6, 6, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227), 6, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227) },
                    { 7, 7, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227), 7, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227) },
                    { 8, 8, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227), 8, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227) },
                    { 9, 9, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227), 9, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227) },
                    { 10, 10, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227), 10, new DateTime(2025, 4, 24, 14, 21, 19, 137, DateTimeKind.Local).AddTicks(9227) }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "CreatedAt", "OrderId", "Quantity", "SupplyId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159), 1, 2, 1, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159) },
                    { 2, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159), 2, 1, 3, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159) },
                    { 3, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159), 3, 1, 2, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159) },
                    { 4, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159), 4, 1, 4, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159) },
                    { 5, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159), 5, 2, 5, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159) },
                    { 6, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159), 6, 3, 6, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159) },
                    { 7, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159), 7, 1, 7, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159) },
                    { 8, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159), 8, 2, 8, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159) },
                    { 9, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159), 9, 1, 9, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159) },
                    { 10, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159), 10, 2, 10, new DateTime(2025, 4, 24, 14, 21, 19, 136, DateTimeKind.Local).AddTicks(5159) }
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
