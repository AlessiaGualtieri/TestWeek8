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
        public bool Register(string nickname);
        public bool Login(string nickname);
        public ICollection<Hero> GetHeroes();
        public bool AddHero(string nicknameGamer, string nameHero, string category, string weaponName);
        public bool DeleteHero(Hero hero);
    }
}
