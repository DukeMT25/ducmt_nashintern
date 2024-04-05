using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fredperry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d4bd7f7-067e-4a5c-ad33-3c13c729c1e6", "AQAAAAIAAYagAAAAECcskC0zP/4zunnQEdysRvBcRmWpNqXqd/+uZ3G2tVVodT+/+zs7aNzJkv+1Pqm6ow==", "d7e5ad51-8dac-4a77-9c24-9bf114733334" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a71819f5-d7aa-44d5-8d97-dcd616eaac88", "AQAAAAIAAYagAAAAEHKTmKues8nozYiwUcTKZSVGGwYCn0WeTkv5I7c2sx+jw4+nwXl05+XaF5nl+OXchw==", "3f3d093c-265f-4bf0-88e5-56a780d008cf" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd984e0d-36aa-4b33-84e1-e31c598b5b99", "AQAAAAIAAYagAAAAEHk8ELYsUeuaEyu8/59Z8oH2AgaYgr5gN5yxPzEftwm9rcNEBx+7IXME2Y/xBcOveg==", "ccc60507-5855-4d58-acf9-1d408660be23" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b41ce70-4a61-4547-bf98-1877a2622db1", "AQAAAAIAAYagAAAAEDKHTI1fJBjcq92JKRnZjMurjIlIxKfZukmz5vuHKUSvNBOQcWIQ+zVPgb99tXwqRw==", "97c07605-9649-491b-ae63-bb44e2b67dc5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec5591f3-562c-4abb-b5c6-69d34b6c9b80", "AQAAAAIAAYagAAAAEIIiAs7AX2yh451sBB5SOUq5bSWbviwkRAVK0JYfMZxJhG4RwFuUJEKTUPb/BmV3sQ==", "4af501fa-0925-4876-add4-cbc47d50f938" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a4aeac1-cf73-433f-8d8c-5aff20bf65c3", "AQAAAAIAAYagAAAAENUGmalq84F/Qqwe6AwT3DTGHPhWpbXX0/X9rJvelPPuNjdb4WF99ortpLMHBSUQGg==", "74d2dda5-e7b4-401f-b1cc-2b4ae043db5e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Administrator", "Administrator" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52ddea1a-d033-4bea-a38c-e42d91165537", "AQAAAAIAAYagAAAAEFU5aJmpYd4nMhmUwjXTperNRoczbHqVJAdaD1SYRajz/gNro5ErEh3VRugHeVCIVw==", "66374e07-6832-4fd0-8111-f50ae64827f2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65269bab-ea80-444d-bf49-b0f5f684667d", "AQAAAAIAAYagAAAAEA+C73LbLAuNuL38i6LfJN6zdhZDT2XEWydTJ+WZvZboPBvr79+C9aQGmCJ6Ix6+Ww==", "b3bcafd2-5f89-4f53-bb44-021845479502" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89e0f3aa-d11a-41df-923b-1d72148064b7", "AQAAAAIAAYagAAAAEFbKAEBG5hfk4pm/vi90N4c+S9QXGHkKvcTuJMGWv9V25EXixbvysoPcq0wGx3UhzQ==", "bc9630e8-c3f2-43af-b31a-8fc1f27775fa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8533f6b-9fa5-4c73-9a36-814022afecb2", "AQAAAAIAAYagAAAAEENXVTicOxEU8EXMijBmyskTTP8PXFWCtv4cvRE8SJ9WHoSbN8E88lgLf9EyQU0r0A==", "cb5fb184-da77-49c7-b263-3204ca98938e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59a20c3e-1732-4dcb-9248-ae8525612915", "AQAAAAIAAYagAAAAECZJLaaL6zsQB3ruP06wG+XCV4gyIcF0uNjPmyGcqZySTOGEQ72S8sXsqZczak6COQ==", "4bd61e3b-f15d-4f41-ad3f-d62245d787dc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cac3921-d449-463e-996b-efa867b141de", "AQAAAAIAAYagAAAAECDWbXuQaXAv5lYZabVGb2i9J1EAaxt+d1EOBhSGzhLtgZGhfXw0YErrpXV/0eBo4Q==", "abb06350-2d3d-4bde-900f-9014d8cfae7f" });
        }
    }
}
