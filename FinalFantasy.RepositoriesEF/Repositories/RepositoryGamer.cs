using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoriesEF.Repositories
{
    public class RepositoryGamer : IRepositoryGamer
    {
        public bool Login(string nickname)
        {
            bool success = false;

            using(var ctx = new FinalFantasyContext())
            {
                Gamer gamer = ctx.Gamers.Find(nickname);
                if (gamer != null)
                    success = true;
            }
            return success;
        }

        public bool Register(string nickname)
        {
            bool success = false;

            using (var ctx = new FinalFantasyContext())
            {
                Gamer gamer = ctx.Gamers.Find(nickname);
                if (gamer == null)
                {
                    try
                    {
                        ctx.Gamers.Add(new Gamer()
                        {
                            Nickname = nickname
                        }
                        );
                        ctx.SaveChanges();

                        success = true;
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e )
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return success;
        }
    }
}
