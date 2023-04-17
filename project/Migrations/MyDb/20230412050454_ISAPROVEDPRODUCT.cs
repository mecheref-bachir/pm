using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations.MyDb
{
    public partial class ISAPROVEDPRODUCT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAproved",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAproved",
                table: "Products");
        }
    }
}
