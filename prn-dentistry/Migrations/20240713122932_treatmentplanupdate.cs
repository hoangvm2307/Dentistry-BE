using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
  /// <inheritdoc />
  public partial class treatmentplanupdate : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {

      migrationBuilder.RenameColumn(
          name: "Frequency",
          table: "TreatmentPlans",
          newName: "Description");

      migrationBuilder.AlterColumn<DateTime>(
          name: "NextAppointmentDate",
          table: "TreatmentPlans",
          type: "timestamp without time zone",
          nullable: true,
          oldClrType: typeof(DateTime),
          oldType: "timestamp without time zone");

      migrationBuilder.AlterColumn<DateTime>(
          name: "EndDate",
          table: "TreatmentPlans",
          type: "timestamp without time zone",
          nullable: true,
          oldClrType: typeof(DateTime),
          oldType: "timestamp without time zone");


    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {

      migrationBuilder.RenameColumn(
          name: "Description",
          table: "TreatmentPlans",
          newName: "Frequency");

      migrationBuilder.AlterColumn<DateTime>(
          name: "NextAppointmentDate",
          table: "TreatmentPlans",
          type: "timestamp without time zone",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
          oldClrType: typeof(DateTime),
          oldType: "timestamp without time zone",
          oldNullable: true);

      migrationBuilder.AlterColumn<DateTime>(
          name: "EndDate",
          table: "TreatmentPlans",
          type: "timestamp without time zone",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
          oldClrType: typeof(DateTime),
          oldType: "timestamp without time zone",
          oldNullable: true);


    }
  }
}
