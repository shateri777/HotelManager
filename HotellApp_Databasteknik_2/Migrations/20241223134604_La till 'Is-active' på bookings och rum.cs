using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotellApp_Databasteknik_2.Migrations
{
    /// <inheritdoc />
    public partial class LatillIsactivepåbookingsochrum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Booking");
        }
    }
}
