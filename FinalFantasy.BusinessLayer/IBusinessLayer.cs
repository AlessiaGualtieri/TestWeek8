using FinalFantasy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.BusinessLayer
{
    public interface IBusinessLayer
    {
        //Gamer
        public bool Register(string nickname);
        public bool Login(string nickname);

        //Hero
        public void ShowHeroes(string nickname);
        public bool AddHero(string nicknameGamer, string nameHero, string category, string weaponName);
        public bool DeleteHero(string nicknameGamer, string nameHero);
        //public int? GetHeroLevel(string nicknameGamer, string nameHero);
        public bool GetHeroInfo(string nicknameGamer, string nameHero, ref int lvl,
            ref int hp, ref int dmg);
        public bool ChangeHeroExp(string nicknameGamer, string nameHero, int exp);

        //Weapon
        public void ShowHeroWeapons(string category);
        public bool AddWeaponToHero(string nicknameGamer, string nameHero, string weaponName);

        //Monster
        public void SelectMonster(int maxLvl, ref string name, ref string weaponName, ref int damage,
            ref int monsterLvl, ref int monsterHP);

    }
}
