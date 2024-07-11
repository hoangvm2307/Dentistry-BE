using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prn_dentistry.Migrations
{
    /// <inheritdoc />
    public partial class chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_Customers_SenderID",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_Dentists_ReceiverID",
                table: "ChatMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage");

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

            migrationBuilder.RenameTable(
                name: "ChatMessage",
                newName: "ChatMessages");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_SenderID",
                table: "ChatMessages",
                newName: "IX_ChatMessages_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_ReceiverID",
                table: "ChatMessages",
                newName: "IX_ChatMessages_ReceiverID");

            migrationBuilder.AlterColumn<string>(
                name: "SenderID",
                table: "ChatMessages",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverID",
                table: "ChatMessages",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "ChatMessages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DentistID",
                table: "ChatMessages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages",
                column: "MessageID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "019f30e8-0144-49cc-a072-6eafbececc3a", null, "Guest", "GUEST" },
                    { "2fd385e9-b695-4a1d-9b9f-ebb247ce81b0", null, "ClinicOwner", "CLINICOWNER" },
                    { "3e10a518-67ea-4eb5-b00c-5df93265c2e5", null, "Customer", "CUSTOMER" },
                    { "d53350bb-eb15-41d4-991b-498ed5679c03", null, "Dentist", "DENTIST" },
                    { "f3d2e1ae-078d-4cd9-a2fa-a93526bab794", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_CustomerID",
                table: "ChatMessages",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_DentistID",
                table: "ChatMessages",
                column: "DentistID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_ReceiverID",
                table: "ChatMessages",
                column: "ReceiverID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_SenderID",
                table: "ChatMessages",
                column: "SenderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Customers_CustomerID",
                table: "ChatMessages",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Dentists_DentistID",
                table: "ChatMessages",
                column: "DentistID",
                principalTable: "Dentists",
                principalColumn: "DentistID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_ReceiverID",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_SenderID",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Customers_CustomerID",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Dentists_DentistID",
                table: "ChatMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_CustomerID",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_DentistID",
                table: "ChatMessages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "019f30e8-0144-49cc-a072-6eafbececc3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fd385e9-b695-4a1d-9b9f-ebb247ce81b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e10a518-67ea-4eb5-b00c-5df93265c2e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d53350bb-eb15-41d4-991b-498ed5679c03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3d2e1ae-078d-4cd9-a2fa-a93526bab794");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "DentistID",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                newName: "ChatMessage");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_SenderID",
                table: "ChatMessage",
                newName: "IX_ChatMessage_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_ReceiverID",
                table: "ChatMessage",
                newName: "IX_ChatMessage_ReceiverID");

            migrationBuilder.AlterColumn<int>(
                name: "SenderID",
                table: "ChatMessage",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverID",
                table: "ChatMessage",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage",
                column: "MessageID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_Customers_SenderID",
                table: "ChatMessage",
                column: "SenderID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_Dentists_ReceiverID",
                table: "ChatMessage",
                column: "ReceiverID",
                principalTable: "Dentists",
                principalColumn: "DentistID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
