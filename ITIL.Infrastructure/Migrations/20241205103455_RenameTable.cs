using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonDepartment_DepartmentList_DepartmentId",
                table: "PersonDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDepartment_PersonList_PersonId",
                table: "PersonDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonDepartment",
                table: "PersonDepartment");

            migrationBuilder.RenameTable(
                name: "PersonDepartment",
                newName: "PersonDepartmentList");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDepartment_PersonId",
                table: "PersonDepartmentList",
                newName: "IX_PersonDepartmentList_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDepartment_DepartmentId",
                table: "PersonDepartmentList",
                newName: "IX_PersonDepartmentList_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonDepartmentList",
                table: "PersonDepartmentList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDepartmentList_DepartmentList_DepartmentId",
                table: "PersonDepartmentList",
                column: "DepartmentId",
                principalTable: "DepartmentList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDepartmentList_PersonList_PersonId",
                table: "PersonDepartmentList",
                column: "PersonId",
                principalTable: "PersonList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonDepartmentList_DepartmentList_DepartmentId",
                table: "PersonDepartmentList");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDepartmentList_PersonList_PersonId",
                table: "PersonDepartmentList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonDepartmentList",
                table: "PersonDepartmentList");

            migrationBuilder.RenameTable(
                name: "PersonDepartmentList",
                newName: "PersonDepartment");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDepartmentList_PersonId",
                table: "PersonDepartment",
                newName: "IX_PersonDepartment_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDepartmentList_DepartmentId",
                table: "PersonDepartment",
                newName: "IX_PersonDepartment_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonDepartment",
                table: "PersonDepartment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDepartment_DepartmentList_DepartmentId",
                table: "PersonDepartment",
                column: "DepartmentId",
                principalTable: "DepartmentList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDepartment_PersonList_PersonId",
                table: "PersonDepartment",
                column: "PersonId",
                principalTable: "PersonList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
