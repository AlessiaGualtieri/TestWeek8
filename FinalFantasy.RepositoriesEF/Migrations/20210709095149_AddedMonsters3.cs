using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalFantasy.RepositoriesEF.Migrations
{
    public partial class AddedMonsters3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Creature",
                columns: new[] { "ID", "Category", "Level", "Name", "Type", "WeaponName" },
                values: new object[] { 6, "Ghost", 1, "Settre", "Monster", "Clava" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Creature",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
