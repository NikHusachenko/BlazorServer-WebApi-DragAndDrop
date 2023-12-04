using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Organization.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationFk = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Organizations_OrganizationFk",
                        column: x => x.OrganizationFk,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Business units",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyFk = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business units_Companies_CompanyFk",
                        column: x => x.CompanyFk,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Index", "Name" },
                values: new object[,]
                {
                    { 1L, 0, "Organization 1" },
                    { 2L, 1, "Organization 2" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Index", "Name", "OrganizationFk" },
                values: new object[,]
                {
                    { 1L, 0, "Child 1", 1L },
                    { 2L, 1, "Child 2", 1L },
                    { 3L, 2, "Child 3", 1L },
                    { 4L, 0, "Child 1", 2L }
                });

            migrationBuilder.InsertData(
                table: "Business units",
                columns: new[] { "Id", "CompanyFk", "Index", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, 0, "1" },
                    { 2L, 1L, 1, "2" },
                    { 3L, 1L, 2, "3" },
                    { 4L, 1L, 3, "4" },
                    { 5L, 1L, 4, "5" },
                    { 6L, 2L, 0, "1" },
                    { 7L, 2L, 1, "2" },
                    { 8L, 2L, 2, "3" },
                    { 9L, 2L, 3, "4" },
                    { 10L, 2L, 4, "5" },
                    { 11L, 3L, 0, "1" },
                    { 12L, 3L, 1, "2" },
                    { 13L, 3L, 2, "3" },
                    { 14L, 3L, 3, "4" },
                    { 15L, 3L, 4, "5" },
                    { 16L, 3L, 5, "6" },
                    { 17L, 3L, 6, "7" },
                    { 18L, 4L, 0, "1" },
                    { 19L, 4L, 1, "2" },
                    { 20L, 4L, 2, "3" },
                    { 21L, 4L, 3, "4" },
                    { 22L, 4L, 4, "5" },
                    { 23L, 4L, 5, "6" },
                    { 24L, 4L, 6, "7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business units_CompanyFk",
                table: "Business units",
                column: "CompanyFk");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OrganizationFk",
                table: "Companies",
                column: "OrganizationFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business units");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
