using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Mock.Repositories
{
    public class RepositoryGame : IRepositoryGame
    {
        private Game game = new Game();
        private Gamer gamer;

        public Gamer ActualGamer()
        {
            return gamer;
        }
        public bool Register(string nickname)
        {
            bool success = false;
            if (game.Users.FirstOrDefault(g => g.Nickname == nickname) == null)
            {
                Gamer g = new Gamer()
                {
                    Nickname = nickname
                };
                game.Users.Add(g);
                gamer = g;
                success = true;
            }
            return success;
        }

        public bool Login(string nickname)
        {
            bool success = false;
            Gamer g = game.Users.FirstOrDefault(g => g.Nickname == nickname);
            if (g != null)
            {
                success = true;
                gamer = g; 
            }
            return success;
        }
    }
}
