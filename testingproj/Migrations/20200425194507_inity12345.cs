using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testingproj.Migrations
{
    public partial class inity12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Myfoods",
                columns: table => new
                {
                    myfoodsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    myfoodsName = table.Column<string>(maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    foodCalories = table.Column<int>(maxLength: 3, nullable: false),
                    photopath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Myfoods", x => x.myfoodsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Myfoods");
        }
    }
}
