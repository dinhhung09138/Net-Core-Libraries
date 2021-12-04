using Microsoft.EntityFrameworkCore.Migrations;

namespace Sql.Database.Migrations
{
    public partial class db_design : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_ManagerId",
                table: "Department");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employee",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Department",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "dbo",
                table: "Employee",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Employee",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Department",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Department",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                schema: "dbo",
                table: "Department",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_EmployeeId",
                schema: "dbo",
                table: "Department",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_EmployeeId",
                schema: "dbo",
                table: "Department",
                column: "EmployeeId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_ManagerId",
                schema: "dbo",
                table: "Department",
                column: "ManagerId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_EmployeeId",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_ManagerId",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_EmployeeId",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "dbo",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Employee",
                schema: "dbo",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Department",
                schema: "dbo",
                newName: "Department");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_ManagerId",
                table: "Department",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
