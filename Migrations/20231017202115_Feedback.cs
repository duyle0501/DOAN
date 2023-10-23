using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopAoQuan.Migrations
{
    /// <inheritdoc />
    public partial class Feedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactStatusId",
                table: "tHoaDonBan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactStatusId",
                table: "tHoaDonBan");
        }
    }
}
