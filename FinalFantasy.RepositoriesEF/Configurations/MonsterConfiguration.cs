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
    public class MonsterConfiguration : IEntityTypeConfiguration<Monster>
    {
        public void Configure(EntityTypeBuilder<Monster> builder)
        {
            builder.HasData(
                new Monster()
                {
                    ID = 1,
                    Name = "Ragnor",
                    Category = "Ghost",
                    WeaponName = "Arco"
                }, 
                new Monster()
                {
                    ID = 6,
                    Name = "Settre",
                    Category = "Ghost",
                    WeaponName = "Clava"
                }, 
                new Monster()
                {
                    ID = 2,
                    Name = "Dvalin",
                    Category = "Lucifer",
                    WeaponName = "Divinazione"
                }, 
                new Monster()
                {
                    ID = 3,
                    Name = "Struck",
                    Category = "Lucifer",
                    WeaponName = "Fulmine"
                }, 
                new Monster()
                {
                    ID = 4,
                    Name = "Zadon",
                    Category = "Lucifer",
                    WeaponName = "Tempesta"
                }, 
                new Monster()
                {
                    ID = 5,
                    Name = "Trekkert",
                    Category = "Lucifer",
                    WeaponName = "Tempesta oscura"
                }
                );
        }
    }
}
