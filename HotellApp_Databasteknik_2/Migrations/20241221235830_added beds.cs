using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotellApp_Databasteknik_2.Migrations
{
    /// <inheritdoc />
    public partial class addedbeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bed",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bed",
                table: "Room");
        }
    }
}
