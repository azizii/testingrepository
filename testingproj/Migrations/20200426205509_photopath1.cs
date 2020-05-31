using Microsoft.EntityFrameworkCore.Migrations;

namespace testingproj.Migrations
{
    public partial class photopath1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photopath11",
                table: "Myfoods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photopath11",
                table: "Myfoods");
        }
    }
}
