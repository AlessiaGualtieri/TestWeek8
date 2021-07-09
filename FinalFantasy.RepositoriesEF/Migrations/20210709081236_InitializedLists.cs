using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalFantasy.RepositoriesEF.Migrations
{
    public partial class InitializedLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Creature",
                table: "Creature");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Creature",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Creature",
                table: "Creature",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Creature_Name_GamerNickname",
                table: "Creature",
                columns: new[] { "Name", "GamerNickname" },
                unique: true,
                filter: "[GamerNickname] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Creature",
                table: "Creature");

            migrationBuilder.DropIndex(
                name: "IX_Creature_Name_GamerNickname",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Creature");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Creature",
                table: "Creature",
                column: "Name");
        }
    }
}
