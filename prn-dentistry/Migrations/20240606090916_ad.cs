using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class ad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f47e4c7-1571-43f5-9881-dcbdb774d140");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3756f43e-c404-414c-989a-cfc978bfd6d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c368a73b-cd6b-4063-84a9-adadc16e5841");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc569961-5085-444c-89a8-c4ff72d60bcd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a46856a-bf80-449b-8ecd-89b39d36a19e", null, "Admin", "ADMIN" },
                    { "8aa1c2a2-be10-47da-978e-e574cafa0b50", null, "Customer", "CUSTOMER" },
                    { "8dde1af4-7210-4e46-925a-dc5b7c0077ca", null, "Guest", "GUEST" },
                    { "9fc26733-cec1-4ea3-99f8-fd21a5196562", null, "ClinicOwner", "CLINICOWNER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a46856a-bf80-449b-8ecd-89b39d36a19e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aa1c2a2-be10-47da-978e-e574cafa0b50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dde1af4-7210-4e46-925a-dc5b7c0077ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fc26733-cec1-4ea3-99f8-fd21a5196562");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f47e4c7-1571-43f5-9881-dcbdb774d140", null, "Guest", "GUEST" },
                    { "3756f43e-c404-414c-989a-cfc978bfd6d4", null, "Admin", "ADMIN" },
                    { "c368a73b-cd6b-4063-84a9-adadc16e5841", null, "Customer", "CUSTOMER" },
                    { "cc569961-5085-444c-89a8-c4ff72d60bcd", null, "ClinicOwner", "CLINICOWNER" }
                });
        }
    }
}
