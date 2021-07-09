using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoriesEF.Repositories
{
    public class RepositoryWeapon : IRepositoryWeapon
    {
        public bool AddWeaponToHero(int heroID, string weaponName)
        {
            bool success = false;
            Weapon weapon;
            Hero hero;
            using (var ctx = new FinalFantasyContext())
            {
                try
                {
                    hero = ctx.Heroes.Find(heroID);
                    weapon = ctx.Weapons.Find(weaponName);
                    if (hero == null || weapon == null)
                        goto endUsing;
                    hero.Weapon = weapon;
                    weapon.Creatures.Add(hero);
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
            endUsing:;
            }
            return success;
        }

        public ICollection<Weapon> GetAll(string category)
        {
            ICollection<Weapon> weapons;

            using(var ctx = new FinalFantasyContext())
            {
                weapons = ctx.Weapons
                    .Where(w => w.Category.Equals(category))
                    .ToList();
            }
            return weapons;
        }

        public void ShowHeroWeapons(string category)
        {
            ICollection<Weapon> weapons = GetAll(category);
            foreach (Weapon weapon in weapons)
            {
                Console.WriteLine(weapon);
            }
        }
    }
}
