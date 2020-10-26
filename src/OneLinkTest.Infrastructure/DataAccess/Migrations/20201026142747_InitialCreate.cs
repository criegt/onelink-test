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
                values: new object[] { 1, "Comercialización" });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "Name" },
                values: new object[] { 2, "Administración" });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "Name" },
                values: new object[] { 3, "Administración del Personal" });

            migrationBuilder.InsertData(
                table: "Subareas",
                columns: new[] { "SubareaId", "AreaId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Investigación de mercado" },
                    { 2, 1, "Publicidad" },
                    { 3, 1, "Promoción" },
                    { 4, 1, "Ventas" },
                    { 5, 1, "Distribución" },
                    { 6, 2, "Finanzas" },
                    { 7, 2, "Control" },
                    { 8, 3, "Selección y distribución" },
                    { 9, 3, "Relaciones Industriales" },
                    { 10, 3, "Servicios Sociales" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Document", "DocumentType", "FirstName", "LastName", "SubareaId" },
                values: new object[] { 1L, 1040049214L, 1, "Cristian", "García", 7 });

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
