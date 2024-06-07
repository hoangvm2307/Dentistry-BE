using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fc87da2-7359-4523-8db6-db4b21a66eff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62254194-a705-4027-85e9-2196a1b50435");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b1ef092-a3c1-4a13-8e97-bdbb1e1d9f63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7e63f06-41bf-4b8f-bdc1-dcaea2a98f9c");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Dentists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Clinics",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f75d18a-cba6-4b67-98be-711bc320ac98", null, "Admin", "ADMIN" },
                    { "95097e1c-3ffb-48c9-ab66-debc192cdf20", null, "ClinicOwner", "CLINICOWNER" },
                    { "a438550e-3629-47c9-8c2e-496a2ab329b2", null, "Customer", "CUSTOMER" },
                    { "e750832f-32f1-4d9d-89ba-ba63f249e90a", null, "Guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f75d18a-cba6-4b67-98be-711bc320ac98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95097e1c-3ffb-48c9-ab66-debc192cdf20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a438550e-3629-47c9-8c2e-496a2ab329b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e750832f-32f1-4d9d-89ba-ba63f249e90a");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Clinics");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5fc87da2-7359-4523-8db6-db4b21a66eff", null, "Customer", "CUSTOMER" },
                    { "62254194-a705-4027-85e9-2196a1b50435", null, "ClinicOwner", "CLINICOWNER" },
                    { "9b1ef092-a3c1-4a13-8e97-bdbb1e1d9f63", null, "Admin", "ADMIN" },
                    { "a7e63f06-41bf-4b8f-bdc1-dcaea2a98f9c", null, "Guest", "GUEST" }
                });
        }
    }
}
