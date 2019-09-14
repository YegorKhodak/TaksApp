using Microsoft.EntityFrameworkCore.Migrations;

namespace Task2.Migrations
{
    public partial class changedboolfieldtoenuminorderorderstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }
    }
}
