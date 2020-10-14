using Microsoft.EntityFrameworkCore.Migrations;

namespace CroweContacts.Data.Migrations
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Contact_ContactVmContactId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Phone_ContactVmContactId",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "ContactVmContactId",
                table: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_ContactId",
                table: "Phone",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Contact_ContactId",
                table: "Phone",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Contact_ContactId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Phone_ContactId",
                table: "Phone");

            migrationBuilder.AddColumn<int>(
                name: "ContactVmContactId",
                table: "Phone",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phone_ContactVmContactId",
                table: "Phone",
                column: "ContactVmContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Contact_ContactVmContactId",
                table: "Phone",
                column: "ContactVmContactId",
                principalTable: "Contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
