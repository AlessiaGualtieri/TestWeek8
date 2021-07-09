using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalFantasy.RepositoriesEF.Migrations
{
    public partial class AddedWeapons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Weapon",
                columns: new[] { "Name", "Category", "Damage" },
                values: new object[,]
                {
                    { "Ascia", "Soldier", 8 },
                    { "Mazza", "Soldier", 5 },
                    { "Spada", "Soldier", 10 },
                    { "Arco e frecce", "Wizard", 8 },
                    { "Bacchetta", "Wizard", 5 },
                    { "Bastone magico", "Wizard", 10 },
                    { "Arco", "Ghost", 7 },
                    { "Clava", "Ghost", 5 },
                    { "Divinazione", "Lucifer", 15 },
                    { "Fulmine", "Lucifer", 10 },
                    { "Tempesta", "Lucifer", 8 },
                    { "Tempesta oscura", "Lucifer", 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Arco");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Arco e frecce");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Ascia");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Bacchetta");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Bastone magico");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Clava");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Divinazione");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Fulmine");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Mazza");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Spada");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Tempesta");

            migrationBuilder.DeleteData(
                table: "Weapon",
                keyColumn: "Name",
                keyValue: "Tempesta oscura");
        }
    }
}
