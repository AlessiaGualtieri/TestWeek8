using FinalFantasy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoriesEF.Configurations
{
    public class WeaponConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.ToTable("Weapon").HasKey(w => w.Name);
            builder.Property(w => w.Damage).IsRequired();
            builder.Property(w => w.Category).IsRequired();

            builder.HasData(
                new Weapon()
                {
                    Name = "Ascia",
                    Category = "Soldier",
                    Damage = 8
                },
                new Weapon()
                {
                    Name = "Mazza",
                    Category = "Soldier",
                    Damage = 5
                },
                new Weapon()
                {
                    Name = "Spada",
                    Category = "Soldier",
                    Damage = 10
                },
                new Weapon()
                {
                    Name = "Arco e frecce",
                    Category = "Wizard",
                    Damage = 8
                },
                new Weapon()
                {
                    Name = "Bacchetta",
                    Category = "Wizard",
                    Damage = 5
                },
                new Weapon()
                {
                    Name = "Bastone magico",
                    Category = "Wizard",
                    Damage = 10
                },
                new Weapon()
                {
                    Name = "Arco",
                    Category = "Ghost",
                    Damage = 7
                },
                new Weapon()
                {
                    Name = "Clava",
                    Category = "Ghost",
                    Damage = 5
                },
                new Weapon()
                {
                    Name = "Divinazione",
                    Category = "Lucifer",
                    Damage = 15
                },
                new Weapon()
                {
                    Name = "Fulmine",
                    Category = "Lucifer",
                    Damage = 10
                },
                new Weapon()
                {
                    Name = "Tempesta",
                    Category = "Lucifer",
                    Damage = 8
                },
                new Weapon()
                {
                    Name = "Tempesta oscura",
                    Category = "Lucifer",
                    Damage = 15
                }
                );          

        }
    }
}
