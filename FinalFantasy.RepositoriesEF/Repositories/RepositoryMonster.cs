using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoriesEF.Repositories
{
    public class RepositoryMonster : IRepositoryMonster
    {
        public Monster RandomMonster(int maxLvl)
        {
            IList<Monster> monsters;
            Monster monster;
            using (var ctx = new FinalFantasyContext())
            {
                monsters = ctx.Monsters.Include(m => m.Weapon).ToList(); 
            }
            Random random = new System.Random();
            monster = monsters[random.Next(1, monsters.Count)];
            monster.Level = random.Next(1, maxLvl);
            return monster;
        }
    }
}
