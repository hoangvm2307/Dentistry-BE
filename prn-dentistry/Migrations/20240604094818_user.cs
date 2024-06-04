using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Dentists",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Dentists_Id",
                table: "Dentists",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dentist",
                table: "Dentists",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentist",
                table: "Dentists");

            migrationBuilder.DropIndex(
                name: "IX_Dentists_Id",
                table: "Dentists");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Dentists");

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
    }
}
