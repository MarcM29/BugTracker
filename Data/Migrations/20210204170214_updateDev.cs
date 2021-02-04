using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Data.Migrations
{
    public partial class updateDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Dev_DevId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Dev_DevId1",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_DevId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_DevId1",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DevId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DevId1",
                table: "Ticket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DevId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevId1",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DevId",
                table: "Ticket",
                column: "DevId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DevId1",
                table: "Ticket",
                column: "DevId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Dev_DevId",
                table: "Ticket",
                column: "DevId",
                principalTable: "Dev",
                principalColumn: "DevId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Dev_DevId1",
                table: "Ticket",
                column: "DevId1",
                principalTable: "Dev",
                principalColumn: "DevId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
