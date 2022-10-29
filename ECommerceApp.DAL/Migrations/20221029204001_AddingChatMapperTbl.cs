using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApp.DAL.Migrations
{
    public partial class AddingChatMapperTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chatMapper",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConnectionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatMapper", x => new { x.UserId, x.ConnectionId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chatMapper");
        }
    }
}
