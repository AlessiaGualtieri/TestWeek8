using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using FinalFantasy.RepositoriesEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private IRepositoryGamer repositoryGamer;
        private IRepositoryHero repositoryHero;
        private IRepositoryWeapon repositoryWeapon;
        private IRepositoryMonster repositoryMonster;

        public MainBusinessLayer()
        {
            repositoryGamer = new RepositoryGamer();
            repositoryHero = new RepositoryHero();
            repositoryWeapon = new RepositoryWeapon();
            repositoryMonster = new RepositoryMonster();
        }

        //HERO

        public bool AddHero(string nicknameGamer, string nameHero, string category, string weaponName)
        {
            return repositoryHero.AddHero(nicknameGamer,nameHero,category,weaponName);
        }

        public bool DeleteHero(string nicknameGamer, string nameHero)
        {
            int? heroID = repositoryHero.FindHeroByName(nicknameGamer, nameHero);
            if (heroID == null)
                return false;
            int hID = (int)heroID;
            return repositoryHero.DeleteHero(hID);
        }


        public void ShowHeroes(string nickname)
        {
            ICollection<Hero> heroes = repositoryHero.GetHeroes(nickname);
            foreach (Hero h in heroes)
            {
                Console.WriteLine(h);
            }
        }

        // GAMER


        public bool Login(string nickname)
        {
            return repositoryGamer.Login(nickname);
        }

        public bool Register(string nickname)
        {
            return repositoryGamer.Register(nickname);
        }
        public bool GetHeroInfo(string nicknameGamer, string nameHero, ref int lvl,
            ref int hp, ref int dmg)
        {
            Hero hero = repositoryHero.GetHeroes(nicknameGamer).FirstOrDefault(h => h.Name.Equals(nameHero));
            if (hero == null)
                return false;
            lvl = hero.Level;
            hp = hero.HP;
            dmg = hero.Weapon.Damage;
            return true;
        }
        //public int? GetHeroLevel(string nicknameGamer, string nameHero)
        //{
        //    Hero hero = repositoryHero.GetHeroes(nicknameGamer).FirstOrDefault(h => h.Name.Equals(nameHero));
        //    if (hero == null)
        //        return null;
        //    return hero.Level;
        //}


        //Weapon
        public void ShowHeroWeapons(string category)
        {
            repositoryWeapon.ShowHeroWeapons(category);
        }
        public bool AddWeaponToHero(string nicknameGamer, string nameHero, string weaponName)
        {
            int? heroID = repositoryHero.FindHeroByName(nicknameGamer, nameHero);
            if (heroID == null)
                return false;
            int hID = (int)heroID;
            return repositoryWeapon.AddWeaponToHero(hID,weaponName);
        }

        public void SelectMonster(int maxLvl, ref string name, ref string weaponName, ref int damage,
            ref int monsterLvl, ref int monsterHP)
        {
            Monster monster = repositoryMonster.RandomMonster(maxLvl);
            name = monster.Name;
            weaponName = monster.WeaponName;
            damage = monster.Weapon.Damage;
            monsterLvl = monster.Level;
            monsterHP = monster.HP;
        }

        public bool ChangeHeroExp(string nicknameGamer, string nameHero, int exp)
        {
            int? heroID = repositoryHero.FindHeroByName(nicknameGamer, nameHero);
            if (heroID == null)
                return false;
            int hID = (int)heroID;
            return repositoryHero.ChangeHeroExp(hID, exp);
        }
    }
}
