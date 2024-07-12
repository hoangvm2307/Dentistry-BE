using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class removeTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Clinics");
 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Clinics",
                type: "text",
                nullable: false,
                defaultValue: "");

          
        }
    }
}
