using FinalFantasy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Repositories
{
    public interface IRepositoryHero
    {
        public bool AddHero(string nicknameGamer, string nameHero, string category, string weaponName);
        public ICollection<Hero> GetHeroes(string nickname);
        public bool DeleteHero(int ID);
        public int? FindHeroByName(string nicknameGamer, string nameHero);
        public bool ChangeHeroExp(int ID, int exp);
    }
}
