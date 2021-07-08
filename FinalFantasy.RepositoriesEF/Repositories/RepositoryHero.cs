using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoriesEF.Repositories
{
    public class RepositoryHero : IRepositoryHero
    {
        public bool AddHero(string nicknameGamer, string nameHero, string category, string weaponName)
        {
            bool success = false;
            Gamer gamer;
            Weapon weapon;
            Hero hero = new Hero()
            {
                Name = nameHero,
                Category = category,
            };

            using (var ctx = new FinalFantasyContext())
            {
                gamer = ctx.Gamers.Find(nicknameGamer);
                weapon = ctx.Weapons.Find(weaponName);
            }

            if(gamer == null || weapon == null)
                return success;

            using(var ctx = new FinalFantasyContext())
            {
                try
                {
                    hero.Gamer = gamer;
                    hero.Weapon = weapon;
                    gamer.Heroes.Add(hero);
                    weapon.Creatures.Add(hero);
                    ctx.Heroes.Add(hero);
                    ctx.SaveChanges();

                    success = true;
                }
                catch (SqlException e )
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e )
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }

        public bool DeleteHero(Hero hero)
        {
            bool success = false;
            Hero heroToDelete;
            using (var ctx = new FinalFantasyContext())
            {
                heroToDelete = ctx.Heroes.Find(hero.Name);
            }
            if (heroToDelete == null)
                return success;
            using (var ctx = new FinalFantasyContext())
            {
                try
                {
                    ctx.Heroes.Remove(heroToDelete);
                    ctx.SaveChanges();

                    success = true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }

        public ICollection<Hero> GetHeroes()
        {
            ICollection<Hero> heroes = null;
            using(var ctx = new FinalFantasyContext())
            {
                heroes = ctx.Heroes.Include(h => h.Weapon).ToList();
            }
            return heroes;
        }
    }
}
