using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infera_WebApi.Migrations
{
    public partial class AddControllerColumnToPermissionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Controller",
                table: "Permissions");
        }
    }
}
