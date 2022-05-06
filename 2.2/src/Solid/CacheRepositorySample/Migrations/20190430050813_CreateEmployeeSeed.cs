using Microsoft.EntityFrameworkCore.Migrations;

namespace CacheRepositorySample.Migrations
{
    public partial class CreateEmployeeSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeID", "Name" },
                values: new object[] { 1, "employee1" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeID", "Name" },
                values: new object[] { 2, "employee2" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeID", "Name" },
                values: new object[] { 3, "employee3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 3);
        }
    }
}
