using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Mock.Repositories
{
    public class RepositoryGamer : IRepositoryGamer
    {
        private Gamer gamer;
        public RepositoryGamer(IRepositoryGame repositoryGame)
        {
            this.gamer = repositoryGame.ActualGamer();
        }

        public void AddHero(Hero hero)
        {
            gamer.Heroes.Add(hero);
        }

        public bool DeleteHero(Hero hero)
        {
            return gamer.Heroes.Remove(hero);
        }

        public ICollection<Hero> GetHeroes()
        {
            return gamer.Heroes;
        }
    }
}
