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
        //private IRepositoryGame repositoryGame;
        private IRepositoryGamer repositoryGamer;
        private IRepositoryHero repositoryHero;

        public MainBusinessLayer()
        {
            //repositoryGame = new RepositoryGame();
            repositoryGamer = new RepositoryGamer();
            repositoryHero = new RepositoryHero();
        }

        public bool AddHero(string nicknameGamer, string nameHero, string category, string weaponName)
        {
            return repositoryHero.AddHero(nicknameGamer,nameHero,category,weaponName);
        }

        public bool DeleteHero(Hero hero)
        {
            return repositoryHero.DeleteHero(hero);
        }

        public ICollection<Hero> GetHeroes()
        {
            return repositoryHero.GetHeroes();
        }

        public bool Login(string nickname)
        {
            return repositoryGamer.Login(nickname);
        }

        public bool Register(string nickname)
        {
            return repositoryGamer.Register(nickname);
        }
    }
}
