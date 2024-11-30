using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentType = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentList_CityList_CityId",
                        column: x => x.CityId,
                        principalTable: "CityList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBossOffice = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDepartment_DepartmentList_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonDepartment_PersonList_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentList_CityId",
                table: "DepartmentList",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDepartment_DepartmentId",
                table: "PersonDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDepartment_PersonId",
                table: "PersonDepartment",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonDepartment");

            migrationBuilder.DropTable(
                name: "DepartmentList");

            migrationBuilder.DropTable(
                name: "PersonList");

            migrationBuilder.DropTable(
                name: "CityList");
        }
    }
}
