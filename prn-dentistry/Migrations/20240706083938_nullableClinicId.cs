using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class nullableClinicId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48b6cf7c-d3ca-4a18-9ab1-d5ecedf887b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f6c9e23-3be1-4e98-b878-1eca950f4baa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a6ab909-8e15-497b-8e44-eb6ab8a407bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a79708cb-b014-4397-b329-09bce3b91507");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a98ba60b-3370-4630-8873-8b4561064fef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3158049d-6c1c-417b-ba68-3849b2e9d3a3", null, "Dentist", "DENTIST" },
                    { "46cb672a-3c55-42d6-ac82-9ba954a955fd", null, "Guest", "GUEST" },
                    { "b5c0039a-cd32-48eb-be37-64ca62313f0e", null, "ClinicOwner", "CLINICOWNER" },
                    { "b7ccd124-b97d-48d0-88d0-4bbcf527a76c", null, "Customer", "CUSTOMER" },
                    { "d508333d-0258-4cf3-aeaf-8ca43f853483", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3158049d-6c1c-417b-ba68-3849b2e9d3a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46cb672a-3c55-42d6-ac82-9ba954a955fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5c0039a-cd32-48eb-be37-64ca62313f0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7ccd124-b97d-48d0-88d0-4bbcf527a76c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d508333d-0258-4cf3-aeaf-8ca43f853483");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48b6cf7c-d3ca-4a18-9ab1-d5ecedf887b6", null, "Customer", "CUSTOMER" },
                    { "4f6c9e23-3be1-4e98-b878-1eca950f4baa", null, "Dentist", "DENTIST" },
                    { "7a6ab909-8e15-497b-8e44-eb6ab8a407bd", null, "Guest", "GUEST" },
                    { "a79708cb-b014-4397-b329-09bce3b91507", null, "ClinicOwner", "CLINICOWNER" },
                    { "a98ba60b-3370-4630-8873-8b4561064fef", null, "Admin", "ADMIN" }
                });
        }
    }
}
