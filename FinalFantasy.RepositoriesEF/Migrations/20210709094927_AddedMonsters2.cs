using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalFantasy.RepositoriesEF.Migrations
{
    public partial class AddedMonsters2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Creature",
                columns: new[] { "ID", "Category", "Level", "Name", "Type", "WeaponName" },
                values: new object[,]
                {
                    { 1, "Ghost", 1, "Ragnor", "Monster", "Arco" },
                    { 2, "Lucifer", 1, "Dvalin", "Monster", "Divinazione" },
                    { 3, "Lucifer", 1, "Struck", "Monster", "Fulmine" },
                    { 4, "Lucifer", 1, "Zadon", "Monster", "Tempesta" },
                    { 5, "Lucifer", 1, "Trekkert", "Monster", "Tempesta oscura" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Creature",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Creature",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Creature",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Creature",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Creature",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
