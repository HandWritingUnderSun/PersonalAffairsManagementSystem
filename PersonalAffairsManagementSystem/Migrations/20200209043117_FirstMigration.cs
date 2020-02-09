using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalAffairsManagementSystem.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "s_Constants",
                columns: table => new
                {
                    CName = table.Column<string>(nullable: false),
                    CValue = table.Column<string>(nullable: true),
                    CDscp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_s_Constants", x => x.CName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "s_Constants");
        }
    }
}
