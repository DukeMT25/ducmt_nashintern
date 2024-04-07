using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fredperry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsNewRelease = table.Column<bool>(type: "bit", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "EntryDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, "Man", null },
                    { 2, null, "Women", null },
                    { 3, null, "The Fred Perry Shirt", null },
                    { 4, null, "Coats & Jackets", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "Description", "EntryDate", "IsActive", "IsNewRelease", "Name", "PictureUrl", "Price", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "P001", null, null, true, true, "M3600", "https://www.fredperry.com/media/catalog/product/cache/5df3cd12867f42fc0f0630ded205ccd9/M/3/M3600_V35_V2_Q224_MOD1_FRONT.JPG", 75f, null },
                    { 2, "P002", null, null, true, true, "M6000", "https://www.fredperry.com/media/catalog/product/cache/03133f2281aec8ae153eeb0f3a984db2/M/6/M6000_V08_V2_Q124_MOD1_FRONT.JPG", 75f, null },
                    { 3, "P003", null, null, true, true, "M12", "https://www.fredperry.com/media/catalog/product/cache/f07b9be9a45c76d3fe7a961404ccc563/M/1/M12_V46_V2_Q124_MOD1_FRONT.JPG", 100f, null },
                    { 4, "P004", null, null, true, true, "Osaka M12", "https://www.fredperry.com/media/catalog/product/cache/7cad0ca5918f66422087e7e308d335a6/M/7/M7731_V96_V2_Q323_FLATFRONT.JPG", 120f, null },
                    { 5, "P005", null, null, true, true, "Tokyo M12", "https://www.fredperry.com/media/catalog/product/cache/29d42814455ec359ef500d1a7ad11576/M/7/M7731_V95_V2_Q323_FLATFRONT.JPG", 120f, null },
                    { 6, "P006", null, null, true, true, "Shanghai M12", "https://www.fredperry.com/media/catalog/product/cache/1b0781da275362d653cecdd8081faaa3/M/7/M7731_V97_V2_Q323_FLATFRONT.JPG", 75f, null },
                    { 7, "P007", null, null, true, true, "Makati M12", "https://www.fredperry.com/media/catalog/product/cache/e3573bf7eceeff94844f3e3868878ca8/M/7/M7731_V98_V2_Q323_FLATFRONT.JPG", 75f, null },
                    { 8, "P008", null, null, true, true, "Brentham Jacket", "https://www.fredperry.com/media/catalog/product/cache/9767c4bb32c5ba031d4c817202f720e4/J/2/J2660_102_1.JPG", 160f, null },
                    { 9, "P009", null, null, true, true, "Harrington Jacket M", "https://www.fredperry.com/media/catalog/product/cache/f87c8868c51a0f5a50fcd1e2ac9f34d1/J/7/J7320_102_V2_Q323_MOD1_FRONT.JPG", 275f, null },
                    { 10, "P010", null, null, true, true, "Textured Zip-Through Overshirt", "https://www.fredperry.com/media/catalog/product/cache/9f25655e4e417091766f035488a014a4/M/5/M5684_608_V2_Q124_MOD1_FRONT.JPG", 140f, null },
                    { 11, "P011", null, null, true, true, "Shell Mac", "https://www.fredperry.com/media/catalog/product/cache/eacaf148ef918b278e70b12c65a357ea/J/7/J7811_638_V2_Q124_MOD1_FRONT.JPG", 250f, null },
                    { 12, "P012", null, null, true, true, "Insulated Gilet", "https://www.fredperry.com/media/catalog/product/cache/f2684b259bf5bd84e98b92febd804bbf/J/4/J4566_297_V2_Q124_MOD1_FRONT.JPG", 140f, null },
                    { 13, "P013", null, null, true, true, "G3600", "https://www.fredperry.com/media/catalog/product/cache/db241c40e38d9e113075984e50f341bb/G/3/G3600_R30_V2_Q224_MOD1_FRONT.JPG", 75f, null },
                    { 14, "P014", null, null, true, true, "G6000", "https://www.fredperry.com/media/catalog/product/cache/c684c76afbeec429a9b7f5deae566f0a/G/6/G6000_B34_V2_Q224_MOD1_FRONT.JPG", 75f, null },
                    { 15, "P015", null, null, true, true, "G3636", "https://www.fredperry.com/media/catalog/product/cache/943d29fb9141199f8ad71607593909c3/G/3/G3636_S51_V2_Q124_MOD1_FRONT.JPG", 90f, null },
                    { 16, "P016", null, null, true, true, "G12", "https://www.fredperry.com/media/catalog/product/cache/5c26e2b4d30bab0caebee4e8876d59fd/G/1/G12_301_1.JPG", 100f, null },
                    { 17, "P017", null, null, true, true, "G7200", "https://www.fredperry.com/media/catalog/product/cache/e88a0615aea85b799c321277b3042aa2/G/7/G7200_129_V2_Q224_ED2.JPG", 65f, null },
                    { 18, "P018", null, null, true, true, "Laurel Wreath Zip-Through Jacket", "https://www.fredperry.com/media/catalog/product/cache/5aa51f239f594747b4af572c697e331d/S/J/SJ7111_102_V2_Q124_MOD1_FRONT.JPG", 190f, null },
                    { 19, "P019", null, null, true, true, "Harrington Jacket G", "https://www.fredperry.com/media/catalog/product/cache/bb1d54160fa477a81956aceefcd03d16/J/7/J7412_102_1.JPG", 275f, null },
                    { 20, "P020", null, null, true, true, "Cropped Taped Track Jacket", "https://www.fredperry.com/media/catalog/product/cache/52cfad5dcd5998e8b333b2acef65bb7c/J/5/J5157_102_1.JPG", 100f, null },
                    { 21, "P021", null, null, true, true, "Sheer Overlay Jacket", "https://www.fredperry.com/media/catalog/product/cache/b70fc93a9fb1019080662b959b1ece58/J/7/J7118_102_V2_Q124_MOD1_FRONT.JPG", 200f, null },
                    { 22, "P022", null, null, true, true, "Metallic Knitted Bomber Jacket", "https://www.fredperry.com/media/catalog/product/cache/3bc570d7624851b832c2d24ccff944e7/S/K/SK6559_926_V2_Q423_MOD1_FRONT.JPG", 175f, null },
                    { 23, "P023", null, null, true, true, "Quilted Jacket", "https://www.fredperry.com/media/catalog/product/cache/cf54d35707f51b903032dd92405427c3/J/6/J6110_560_V2_Q423_MOD1_FRONT.JPG", 225f, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "Admin" },
                    { "2", null, "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "0225d1b0-1e95-48dd-b65d-91697d9560cd", "admin1@gmail.com", false, false, null, null, "admin1@gmail.com", "AQAAAAIAAYagAAAAEIwggmfnyWImIAPvsC6GAMziCxMLvmW395ZlEzQH+Biz+NcB1hP6oJFzoA7nk0QuPQ==", null, false, "13fe9acc-cbdf-41b4-befa-2129230836db", false, "admin1" },
                    { "2", 0, "a614d55e-5f86-41c1-8826-981ddbc33040", "admin2@gmail.com", false, false, null, null, "admin2@gmail.com", "AQAAAAIAAYagAAAAELuZW0X5gmGVho5pg/EP9Ay790Wf7Hu5JSXTXUZtMYOmBMAQimBancKkYHQbDL5Lqg==", null, false, "88a9ff18-8bc7-4eac-8f6d-b9ef6bd0f04a", false, "admin2" },
                    { "3", 0, "5072ae2b-6bc3-49b7-bb0f-60837cfca6cb", "admin3@gmail.com", false, false, null, null, "admin3@gmail.com", "AQAAAAIAAYagAAAAEIKqZ/J83kslkK7ZIeKhpflbHyUEYJfH6t0j9MmUdsGG3gj+BNgbIw1iECLFLgk1IQ==", null, false, "279d2564-e3af-4bfe-908f-f328ce7b0b52", false, "admin3" },
                    { "4", 0, "0cb53c47-43fe-4817-8bd6-d8e1d8c06677", "customer1@gmail.com", false, false, null, null, "customer1@gmail.com", "AQAAAAIAAYagAAAAEGk/lmbk/YuWlFdtx85/GvmoBf4sMjjREk7zRBUXJZhzuR7Ls6qlTStGlbcM5I7Lbg==", null, false, "6d4a3f2a-7ef2-403a-8731-bc3af2eeae46", false, "customer1" },
                    { "5", 0, "cb9b2c4d-f6e4-46d3-95d2-311e251950a0", "customer2@gmail.com", false, false, null, null, "customer2@gmail.com", "AQAAAAIAAYagAAAAEMFVP5XZ9lAGAeU86OmC5En9kBTIdDJeqSwY1L4cbWareRZY0eVz5tWUqQkeR5dc6g==", null, false, "321c4111-6242-4932-9d12-982a79b03161", false, "customer2" },
                    { "6", 0, "3fd3975b-f0d2-4b0d-a8d3-cefd0c3e40d3", "customer3@gmail.com", false, false, null, null, "customer3@gmail.com", "AQAAAAIAAYagAAAAEF1y0fgmYoogiiAYJcHVyVOYwsmeMljMnth7fh2Q+4lPOCJMejTC0gLdLhq1CepZ/A==", null, false, "79ef75e3-0825-41da-8ed8-774a96a82f2a", false, "customer3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "1", "2" },
                    { "1", "3" },
                    { "2", "4" },
                    { "2", "5" },
                    { "2", "6" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "EntryDate", "ProductId", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, null, 1, null },
                    { 2, 3, null, 1, null },
                    { 3, 1, null, 2, null },
                    { 4, 3, null, 2, null },
                    { 5, 1, null, 3, null },
                    { 6, 3, null, 3, null },
                    { 7, 1, null, 4, null },
                    { 8, 3, null, 4, null },
                    { 9, 1, null, 5, null },
                    { 10, 3, null, 5, null },
                    { 11, 1, null, 6, null },
                    { 12, 3, null, 6, null },
                    { 13, 1, null, 7, null },
                    { 14, 3, null, 7, null },
                    { 15, 1, null, 8, null },
                    { 16, 4, null, 8, null },
                    { 17, 1, null, 9, null },
                    { 18, 4, null, 9, null },
                    { 19, 1, null, 10, null },
                    { 20, 4, null, 10, null },
                    { 21, 1, null, 11, null },
                    { 22, 4, null, 11, null },
                    { 23, 1, null, 12, null },
                    { 24, 4, null, 12, null },
                    { 25, 2, null, 13, null },
                    { 26, 3, null, 13, null },
                    { 27, 2, null, 14, null },
                    { 28, 3, null, 14, null },
                    { 29, 2, null, 15, null },
                    { 30, 3, null, 15, null },
                    { 31, 2, null, 16, null },
                    { 32, 3, null, 16, null },
                    { 33, 2, null, 17, null },
                    { 34, 3, null, 17, null },
                    { 35, 2, null, 18, null },
                    { 36, 4, null, 18, null },
                    { 37, 2, null, 19, null },
                    { 38, 4, null, 19, null },
                    { 39, 2, null, 20, null },
                    { 40, 4, null, 20, null },
                    { 41, 2, null, 21, null },
                    { 42, 4, null, 21, null },
                    { 43, 2, null, 22, null },
                    { 44, 4, null, 22, null },
                    { 45, 2, null, 23, null },
                    { 46, 4, null, 23, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
