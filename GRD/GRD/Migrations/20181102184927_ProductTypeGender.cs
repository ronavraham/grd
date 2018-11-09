using Microsoft.EntityFrameworkCore.Migrations;

namespace GRD.Migrations
{
    public partial class ProductTypeGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "ProductTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "ProductTypes");
        }
    }
}
