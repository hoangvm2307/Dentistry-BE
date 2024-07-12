using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "019f30e8-0144-49cc-a072-6eafbececc3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fd385e9-b695-4a1d-9b9f-ebb247ce81b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e10a518-67ea-4eb5-b00c-5df93265c2e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d53350bb-eb15-41d4-991b-498ed5679c03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3d2e1ae-078d-4cd9-a2fa-a93526bab794");

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Clinics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38611cb2-a3f1-45bd-9562-1046c6d35996", null, "Admin", "ADMIN" },
                    { "49071a86-4c0e-4d03-ad4e-2362b8ad6161", null, "Customer", "CUSTOMER" },
                    { "73170607-2080-4fcb-a14c-c87c87f11e28", null, "ClinicOwner", "CLINICOWNER" },
                    { "852d0f07-1a2a-4206-bffb-020d4a18cac8", null, "Dentist", "DENTIST" },
                    { "d2a3fc39-3d30-4e6d-afaa-f73d66a038b8", null, "Guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38611cb2-a3f1-45bd-9562-1046c6d35996");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49071a86-4c0e-4d03-ad4e-2362b8ad6161");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73170607-2080-4fcb-a14c-c87c87f11e28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "852d0f07-1a2a-4206-bffb-020d4a18cac8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2a3fc39-3d30-4e6d-afaa-f73d66a038b8");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Clinics");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "019f30e8-0144-49cc-a072-6eafbececc3a", null, "Guest", "GUEST" },
                    { "2fd385e9-b695-4a1d-9b9f-ebb247ce81b0", null, "ClinicOwner", "CLINICOWNER" },
                    { "3e10a518-67ea-4eb5-b00c-5df93265c2e5", null, "Customer", "CUSTOMER" },
                    { "d53350bb-eb15-41d4-991b-498ed5679c03", null, "Dentist", "DENTIST" },
                    { "f3d2e1ae-078d-4cd9-a2fa-a93526bab794", null, "Admin", "ADMIN" }
                });
        }
    }
}
