// <auto-generated />
using FinalFantasy.RepositoriesEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalFantasy.RepositoriesEF.Migrations
{
    [DbContext(typeof(FinalFantasyContext))]
    [Migration("20210708144004_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalFantasy.Core.Entities.Creature", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeaponName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.HasIndex("WeaponName");

                    b.ToTable("Creature");
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Gamer", b =>
                {
                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Nickname");

                    b.ToTable("Gamer");
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Weapon", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Weapon");
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Hero", b =>
                {
                    b.HasBaseType("FinalFantasy.Core.Entities.Creature");

                    b.Property<string>("GamerNickname")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("GamerNickname");

                    b.ToTable("Hero");
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Monster", b =>
                {
                    b.HasBaseType("FinalFantasy.Core.Entities.Creature");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.ToTable("Monster");
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Creature", b =>
                {
                    b.HasOne("FinalFantasy.Core.Entities.Weapon", "Weapon")
                        .WithMany("Creatures")
                        .HasForeignKey("WeaponName");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Hero", b =>
                {
                    b.HasOne("FinalFantasy.Core.Entities.Gamer", "Gamer")
                        .WithMany("Heroes")
                        .HasForeignKey("GamerNickname");

                    b.HasOne("FinalFantasy.Core.Entities.Creature", null)
                        .WithOne()
                        .HasForeignKey("FinalFantasy.Core.Entities.Hero", "Name")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Gamer");
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Monster", b =>
                {
                    b.HasOne("FinalFantasy.Core.Entities.Creature", null)
                        .WithOne()
                        .HasForeignKey("FinalFantasy.Core.Entities.Monster", "Name")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Gamer", b =>
                {
                    b.Navigation("Heroes");
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Weapon", b =>
                {
                    b.Navigation("Creatures");
                });
#pragma warning restore 612, 618
        }
    }
}
