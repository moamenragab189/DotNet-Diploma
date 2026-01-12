using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity_Framework_Task.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "id", "isNew", "name" },
                values: new object[,]
                {
                    { 1, true, "HR" },
                    { 2, false, "IT" },
                    { 3, true, "Finance" },
                    { 4, false, "Operation" },
                    { 5, false, "Markting" }
                });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "id", "deadLine", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2012), "CRM" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2019), "HR" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2019), "ERP" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2016), "School Management " }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "id", "departmentId", "name", "projectId", "salary" },
                values: new object[,]
                {
                    { 101, 3, "named Ali Hassan", 1, 5000m },
                    { 102, 2, "Sameer Zaki", 1, 6200m },
                    { 103, 1, "Khaled Omar", 1, 4750m },
                    { 104, 4, "Karim Ahmed", 1, 5500m },
                    { 105, 3, "Youssef Nabil", 2, 7100m },
                    { 106, 2, "Loay Samir", 2, 4900m },
                    { 107, 2, "Omar Fathy", 2, 6000m },
                    { 108, 2, "Wael Magdy", 2, 5800m },
                    { 109, 2, "Ahmed Tarek", 2, 6750m },
                    { 110, 2, "Sameh Hany,", 3, 4300m },
                    { 111, 3, "Mahmoud Said", 3, 5600m },
                    { 112, 2, "Waleed Adel", 4, 6100m },
                    { 113, 4, "Bassel Hossam", 4, 5400m },
                    { 114, 1, "ALi Khalil", 4, 4850m },
                    { 115, 3, "Hussein Mostafa", 4, 6900m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "projects",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "projects",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "projects",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "projects",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
