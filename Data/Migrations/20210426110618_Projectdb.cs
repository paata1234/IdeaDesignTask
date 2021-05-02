using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeaDesignTask.Migrations
{
    public partial class Projectdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    business = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Physicalusers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personalid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "Date", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physicalusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPhysicalusers",
                columns: table => new
                {
                    Companyid = table.Column<int>(type: "int", nullable: false),
                    Usersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPhysicalusers", x => new { x.Companyid, x.Usersid });
                    table.ForeignKey(
                        name: "FK_CompanyPhysicalusers_Company_Companyid",
                        column: x => x.Companyid,
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyPhysicalusers_Physicalusers_Usersid",
                        column: x => x.Usersid,
                        principalTable: "Physicalusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPhysicalusers_Usersid",
                table: "CompanyPhysicalusers",
                column: "Usersid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyPhysicalusers");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Physicalusers");
        }
    }
}
