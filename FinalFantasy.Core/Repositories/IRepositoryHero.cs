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
        public ICollection<Hero> GetHeroes();
        public bool DeleteHero(Hero hero);
    }
}
