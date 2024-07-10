using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class FieldClinicScheduleID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ClinicScheduleID",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "204fb827-51dc-49b6-a590-9614bf6732d1", null, "Dentist", "DENTIST" },
                    { "24575d25-0512-4c47-9a2c-0d64d1de277b", null, "Admin", "ADMIN" },
                    { "692704f1-1c5a-4985-8fca-c6c40eafd325", null, "ClinicOwner", "CLINICOWNER" },
                    { "795ab94b-0441-45bd-89f4-f7277792a90f", null, "Customer", "CUSTOMER" },
                    { "a690cd85-c231-4c04-8c08-3d791203c618", null, "Guest", "GUEST" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClinicScheduleID",
                table: "Appointments",
                column: "ClinicScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ClinicSchedules_ClinicScheduleID",
                table: "Appointments",
                column: "ClinicScheduleID",
                principalTable: "ClinicSchedules",
                principalColumn: "ScheduleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ClinicSchedules_ClinicScheduleID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ClinicScheduleID",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "204fb827-51dc-49b6-a590-9614bf6732d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24575d25-0512-4c47-9a2c-0d64d1de277b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "692704f1-1c5a-4985-8fca-c6c40eafd325");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "795ab94b-0441-45bd-89f4-f7277792a90f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a690cd85-c231-4c04-8c08-3d791203c618");

            migrationBuilder.DropColumn(
                name: "ClinicScheduleID",
                table: "Appointments");

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
    }
}
