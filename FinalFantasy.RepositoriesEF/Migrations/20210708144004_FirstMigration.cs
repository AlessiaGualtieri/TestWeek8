using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalFantasy.RepositoriesEF.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gamer",
                columns: table => new
                {
                    Nickname = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamer", x => x.Nickname);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaponName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Creature_Weapon_WeaponName",
                        column: x => x.WeaponName,
                        principalTable: "Weapon",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Creature_WeaponName",
                table: "Creature",
                column: "WeaponName");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_GamerNickname",
                table: "Hero",
                column: "GamerNickname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "Monster");

            migrationBuilder.DropTable(
                name: "Gamer");

            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
