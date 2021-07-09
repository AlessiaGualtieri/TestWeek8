using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalFantasy.RepositoriesEF.Migrations
{
    public partial class ThrdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "Monster");

            migrationBuilder.AddColumn<string>(
                name: "GamerNickname",
                table: "Creature",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Creature",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Creature",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Creature_GamerNickname",
                table: "Creature",
                column: "GamerNickname");

            migrationBuilder.AddForeignKey(
                name: "FK_Creature_Gamer_GamerNickname",
                table: "Creature",
                column: "GamerNickname",
                principalTable: "Gamer",
                principalColumn: "Nickname",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creature_Gamer_GamerNickname",
                table: "Creature");

            migrationBuilder.DropIndex(
                name: "IX_Creature_GamerNickname",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "GamerNickname",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Creature");

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GamerNickname = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Hero_Creature_Name",
                        column: x => x.Name,
                        principalTable: "Creature",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hero_Gamer_GamerNickname",
                        column: x => x.GamerNickname,
                        principalTable: "Gamer",
                        principalColumn: "Nickname",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Monster",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monster", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Monster_Creature_Name",
                        column: x => x.Name,
                        principalTable: "Creature",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hero_GamerNickname",
                table: "Hero",
                column: "GamerNickname");
        }
    }
}
