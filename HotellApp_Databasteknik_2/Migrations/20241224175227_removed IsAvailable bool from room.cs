using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotellApp_Databasteknik_2.Migrations
{
    /// <inheritdoc />
    public partial class removedIsAvailableboolfromroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Room");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
