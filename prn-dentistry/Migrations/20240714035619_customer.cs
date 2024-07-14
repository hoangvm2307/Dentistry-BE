using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
  /// <inheritdoc />
  public partial class customer : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<string>(
          name: "PhoneNumber",
          table: "Customers",
          type: "text",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "text");

      migrationBuilder.AlterColumn<string>(
          name: "Name",
          table: "Customers",
          type: "text",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "text");

      migrationBuilder.AlterColumn<string>(
          name: "Gender",
          table: "Customers",
          type: "text",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "text");

      migrationBuilder.AlterColumn<DateTime>(
          name: "DateOfBirth",
          table: "Customers",
          type: "timestamp without time zone",
          nullable: true,
          oldClrType: typeof(DateTime),
          oldType: "timestamp without time zone");

      migrationBuilder.AlterColumn<string>(
          name: "Address",
          table: "Customers",
          type: "text",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "text");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<string>(
          name: "PhoneNumber",
          table: "Customers",
          type: "text",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "text",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "Name",
          table: "Customers",
          type: "text",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "text",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "Gender",
          table: "Customers",
          type: "text",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "text",
          oldNullable: true);

      migrationBuilder.AlterColumn<DateTime>(
          name: "DateOfBirth",
          table: "Customers",
          type: "timestamp without time zone",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
          oldClrType: typeof(DateTime),
          oldType: "timestamp without time zone",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "Address",
          table: "Customers",
          type: "text",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "text",
          oldNullable: true);

    }
  }
}
