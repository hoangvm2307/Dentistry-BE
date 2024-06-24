using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class clinicId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32975604-3eb1-4f5e-8f0f-afad218676c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49702fa7-578b-4314-a30c-c9b587981cbe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fcc1117-3e98-4f04-bda2-d41fff078e2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9faaba1a-a6c7-4b5a-b5be-444fd383d89c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8d58b9b-56cb-4703-abec-b35a32ee0807");

            migrationBuilder.AddColumn<int>(
                name: "ClinicID",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3090f373-9267-4bd5-98b3-05e50cca8f83", null, "ClinicOwner", "CLINICOWNER" },
                    { "33f9f243-8d3e-42a0-ba35-d79c859b051c", null, "Customer", "CUSTOMER" },
                    { "6ba1807d-28e4-4e9b-a4b3-77957e3660f9", null, "Guest", "GUEST" },
                    { "997f59bb-3212-4c62-a86b-0f39e7ee3c6e", null, "Admin", "ADMIN" },
                    { "cdbaac27-8527-4e65-90fe-e9521baecb70", null, "Dentist", "DENTIST" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_ClinicID",
                table: "Services",
                column: "ClinicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Clinics_ClinicID",
                table: "Services",
                column: "ClinicID",
                principalTable: "Clinics",
                principalColumn: "ClinicID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Clinics_ClinicID",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ClinicID",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3090f373-9267-4bd5-98b3-05e50cca8f83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33f9f243-8d3e-42a0-ba35-d79c859b051c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ba1807d-28e4-4e9b-a4b3-77957e3660f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "997f59bb-3212-4c62-a86b-0f39e7ee3c6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdbaac27-8527-4e65-90fe-e9521baecb70");

            migrationBuilder.DropColumn(
                name: "ClinicID",
                table: "Services");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32975604-3eb1-4f5e-8f0f-afad218676c5", null, "Dentist", "DENTIST" },
                    { "49702fa7-578b-4314-a30c-c9b587981cbe", null, "Admin", "ADMIN" },
                    { "4fcc1117-3e98-4f04-bda2-d41fff078e2f", null, "ClinicOwner", "CLINICOWNER" },
                    { "9faaba1a-a6c7-4b5a-b5be-444fd383d89c", null, "Guest", "GUEST" },
                    { "c8d58b9b-56cb-4703-abec-b35a32ee0807", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
