﻿// <auto-generated />
using FinalFantasy.RepositoriesEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalFantasy.RepositoriesEF.Migrations
{
    [DbContext(typeof(FinalFantasyContext))]
    [Migration("20210709095149_AddedMonsters3")]
    partial class AddedMonsters3
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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeaponName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("WeaponName");

                    b.ToTable("Creature");

                    b.HasDiscriminator<string>("Type").HasValue("Creature");
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

                    b.HasData(
                        new
                        {
                            Name = "Ascia",
                            Category = "Soldier",
                            Damage = 8
                        },
                        new
                        {
                            Name = "Mazza",
                            Category = "Soldier",
                            Damage = 5
                        },
                        new
                        {
                            Name = "Spada",
                            Category = "Soldier",
                            Damage = 10
                        },
                        new
                        {
                            Name = "Arco e frecce",
                            Category = "Wizard",
                            Damage = 8
                        },
                        new
                        {
                            Name = "Bacchetta",
                            Category = "Wizard",
                            Damage = 5
                        },
                        new
                        {
                            Name = "Bastone magico",
                            Category = "Wizard",
                            Damage = 10
                        },
                        new
                        {
                            Name = "Arco",
                            Category = "Ghost",
                            Damage = 7
                        },
                        new
                        {
                            Name = "Clava",
                            Category = "Ghost",
                            Damage = 5
                        },
                        new
                        {
                            Name = "Divinazione",
                            Category = "Lucifer",
                            Damage = 15
                        },
                        new
                        {
                            Name = "Fulmine",
                            Category = "Lucifer",
                            Damage = 10
                        },
                        new
                        {
                            Name = "Tempesta",
                            Category = "Lucifer",
                            Damage = 8
                        },
                        new
                        {
                            Name = "Tempesta oscura",
                            Category = "Lucifer",
                            Damage = 15
                        });
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Hero", b =>
                {
                    b.HasBaseType("FinalFantasy.Core.Entities.Creature");

                    b.Property<string>("GamerNickname")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("GamerNickname");

                    b.HasIndex("Name", "GamerNickname")
                        .IsUnique()
                        .HasFilter("[GamerNickname] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Hero");
                });

            modelBuilder.Entity("FinalFantasy.Core.Entities.Monster", b =>
                {
                    b.HasBaseType("FinalFantasy.Core.Entities.Creature");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Monster");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Category = "Ghost",
                            Name = "Ragnor",
                            WeaponName = "Arco",
                            Level = 1
                        },
                        new
                        {
                            ID = 6,
                            Category = "Ghost",
                            Name = "Settre",
                            WeaponName = "Clava",
                            Level = 1
                        },
                        new
                        {
                            ID = 2,
                            Category = "Lucifer",
                            Name = "Dvalin",
                            WeaponName = "Divinazione",
                            Level = 1
                        },
                        new
                        {
                            ID = 3,
                            Category = "Lucifer",
                            Name = "Struck",
                            WeaponName = "Fulmine",
                            Level = 1
                        },
                        new
                        {
                            ID = 4,
                            Category = "Lucifer",
                            Name = "Zadon",
                            WeaponName = "Tempesta",
                            Level = 1
                        },
                        new
                        {
                            ID = 5,
                            Category = "Lucifer",
                            Name = "Trekkert",
                            WeaponName = "Tempesta oscura",
                            Level = 1
                        });
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

                    b.Navigation("Gamer");
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
