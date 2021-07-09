using FinalFantasy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Repositories
{
    public interface IRepositoryWeapon
    {
        public ICollection<Weapon> GetAll(string category);

        public void ShowHeroWeapons(string category);

        public bool AddWeaponToHero(int heroID, string weaponName);
    }
}
