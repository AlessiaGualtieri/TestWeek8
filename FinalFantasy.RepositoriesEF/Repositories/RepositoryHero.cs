using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

            using(var ctx = new FinalFantasyContext())
            {
                gamer = ctx.Gamers.Find(nicknameGamer);
                weapon = ctx.Weapons.Find(weaponName);
                if (gamer == null || weapon == null)
                    goto endUsing;
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
            endUsing:;
            }
            return success;
        }

        public bool ChangeHeroExp(int ID, int exp)
        {
            bool success = false;
            using (var ctx = new FinalFantasyContext())
            {
                try
                {
                    Hero hero = ctx.Heroes.Find(ID);
                    hero.IncrementExperience(exp);
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

        public bool DeleteHero(int heroID)
        {
            bool success = false;
            Hero heroToDelete;
            using (var ctx = new FinalFantasyContext())
            {
                heroToDelete = ctx.Heroes
                    .FirstOrDefault(h => h.ID == heroID);
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

        public int? FindHeroByName(string nicknameGamer, string nameHero)
        {
            int? heroID;
            using (var ctx = new FinalFantasyContext())
            {
                heroID = ctx.Heroes.Where(h => h.Name.Equals(nameHero))
                    .Where(h => h.GamerNickname.Equals(nicknameGamer))
                    .FirstOrDefault().ID;
            }
            return heroID;
        }

        public ICollection<Hero> GetHeroes(string nickname)
        {
            ICollection<Hero> heroes = null;
            using(var ctx = new FinalFantasyContext())
            {
                heroes = ctx.Heroes.Include(h => h.Weapon)
                    .Where(h => h.GamerNickname.Equals(nickname))
                    .ToList();
            }
            return heroes;
        }
    }
}
