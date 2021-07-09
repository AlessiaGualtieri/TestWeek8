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
    public class CreatureConfiguration : IEntityTypeConfiguration<Creature>
    {
        public void Configure(EntityTypeBuilder<Creature> builder)
        {
            builder.ToTable("Creature").HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd()/*.UseIdentityColumn()*/;
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Category).IsRequired();

            builder.HasDiscriminator<string>("Type")
                .HasValue<Hero>("Hero")
                .HasValue<Monster>("Monster");
        }
    }
}
