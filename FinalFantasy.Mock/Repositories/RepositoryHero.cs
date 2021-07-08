using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Mock.Repositories
{
    public class RepositoryHero : IRepositoryHero
    {
        private Gamer gamer;
        public RepositoryHero(IRepositoryGame repositoryGame)
        {
            gamer = repositoryGame.ActualGamer();
        }
        public void AddHero(string name, string category, string weapon)
        {
            Hero hero = new Hero()
            {
                Name = name,
                Experience = 0,
                Gamer = gamer,
                Level = 1,
                Category = category,
            };
        }
    }
}
