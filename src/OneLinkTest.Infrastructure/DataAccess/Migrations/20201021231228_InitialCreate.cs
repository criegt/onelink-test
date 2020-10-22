using Microsoft.EntityFrameworkCore.Migrations;

namespace OneLinkTest.Infrastructure.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "Subareas",
                columns: table => new
                {
                    SubareaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subareas", x => x.SubareaId);
                    table.ForeignKey(
                        name: "FK_Subareas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<long>(nullable: false),
                    DocumentType = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SubareaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Subareas_SubareaId",
                        column: x => x.SubareaId,
                        principalTable: "Subareas",
                        principalColumn: "SubareaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "Name" },
                values: new object[] { 1, "Area1" });

            migrationBuilder.InsertData(
                table: "Subareas",
                columns: new[] { "SubareaId", "AreaId", "Name" },
                values: new object[] { 1, 1, "Subarea1" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SubareaId",
                table: "Employees",
                column: "SubareaId");

            migrationBuilder.CreateIndex(
                name: "IX_Subareas_AreaId",
                table: "Subareas",
                column: "AreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Subareas");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
