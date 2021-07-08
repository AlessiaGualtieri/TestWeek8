using FinalFantasy.Core.Entities;
using FinalFantasy.RepositoriesEF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoriesEF
{
    public class FinalFantasyContext : DbContext
    {
        public DbSet<Gamer> Gamers;
        public DbSet<Hero> Heroes;
        public DbSet<Monster> Monsters;
        public DbSet<Weapon> Weapons;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False; 
                                    Integrated Security = true; 
                                    Initial Catalog = FinalFantasy; 
                                    Server = .\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Gamer>(new GamerConfiguration());
            modelBuilder.ApplyConfiguration<Hero>(new HeroConfiguration());
            modelBuilder.ApplyConfiguration<Weapon>(new WeaponConfiguration());
            modelBuilder.ApplyConfiguration<Monster>(new MonsterConfiguration());

            modelBuilder.Entity<Gamer>().HasMany(g => g.Heroes).WithOne(h => h.Gamer)
                .HasForeignKey(h => h.GamerNickname);
            modelBuilder.Entity<Creature>().HasOne(c => c.Weapon).WithMany(w => w.Creatures)
                .HasForeignKey(c => c.WeaponName);
        }
    }
}
