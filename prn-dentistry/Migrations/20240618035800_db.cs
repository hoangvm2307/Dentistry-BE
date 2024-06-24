using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "141694b3-cf45-4c13-ab70-9c00ba7ea7c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47c08342-7938-4c40-88cf-56d7ad225ba8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c7334d9-508e-40cc-9de2-05913fe2e1a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "838a479b-acba-44c1-b404-51ff9092b89a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba87a9a5-8b6e-4d2f-a957-15b536c6dac8");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "TreatmentPlans",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NextAppointmentDate",
                table: "TreatmentPlans",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "TreatmentPlans",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningTime",
                table: "ClinicSchedules",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingTime",
                table: "ClinicSchedules",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningHours",
                table: "Clinics",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingHours",
                table: "Clinics",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ClinicOwners",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ClinicOwners",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "ChatMessage",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AppointmentTime",
                table: "Appointments",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AppointmentDate",
                table: "Appointments",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "TreatmentPlans",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NextAppointmentDate",
                table: "TreatmentPlans",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "TreatmentPlans",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningTime",
                table: "ClinicSchedules",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingTime",
                table: "ClinicSchedules",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningHours",
                table: "Clinics",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingHours",
                table: "Clinics",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ClinicOwners",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ClinicOwners",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "ChatMessage",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AppointmentTime",
                table: "Appointments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AppointmentDate",
                table: "Appointments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "141694b3-cf45-4c13-ab70-9c00ba7ea7c1", null, "Guest", "GUEST" },
                    { "47c08342-7938-4c40-88cf-56d7ad225ba8", null, "ClinicOwner", "CLINICOWNER" },
                    { "7c7334d9-508e-40cc-9de2-05913fe2e1a6", null, "Customer", "CUSTOMER" },
                    { "838a479b-acba-44c1-b404-51ff9092b89a", null, "Admin", "ADMIN" },
                    { "ba87a9a5-8b6e-4d2f-a957-15b536c6dac8", null, "Dentist", "DENTIST" }
                });
        }
    }
}
