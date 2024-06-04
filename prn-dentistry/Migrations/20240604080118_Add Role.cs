using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dc62630-a00f-426d-93d0-205f8231946f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84a8cc6f-65ce-4039-b7cb-a7017875ccea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02387c26-9b89-40f1-a4de-3902a17f35f9", null, "Customer", "CUSTOMER" },
                    { "3de63725-930e-424b-898d-e5d18aefd0b2", null, "ClinicOwner", "CLINICOWNER" },
                    { "590dddaf-f564-45a5-bf76-d7ace0c29b3e", null, "Admin", "ADMIN" },
                    { "697f31f5-3601-418a-865c-7e2a97bbca0c", null, "Guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02387c26-9b89-40f1-a4de-3902a17f35f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3de63725-930e-424b-898d-e5d18aefd0b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "590dddaf-f564-45a5-bf76-d7ace0c29b3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "697f31f5-3601-418a-865c-7e2a97bbca0c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7dc62630-a00f-426d-93d0-205f8231946f", null, "Admin", "ADMIN" },
                    { "84a8cc6f-65ce-4039-b7cb-a7017875ccea", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
