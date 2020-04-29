using Microsoft.EntityFrameworkCore.Migrations;

namespace yd.Migrations
{
    public partial class AddedRowSpanandColumnSpan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColumnSpan",
                table: "Tables",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RowSpan",
                table: "Tables",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnSpan",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "RowSpan",
                table: "Tables");
        }
    }
}
