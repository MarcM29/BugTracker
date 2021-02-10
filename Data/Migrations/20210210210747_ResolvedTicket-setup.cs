using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Data.Migrations
{
    public partial class ResolvedTicketsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ResolvedTicket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RTicketTitle = table.Column<string>(nullable: false),
                    RTicketDescription = table.Column<string>(nullable: false),
                    RTicketPriority = table.Column<string>(nullable: false),
                    RTicketDate = table.Column<string>(nullable: true),
                    RUsersName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResolvedTicket", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
