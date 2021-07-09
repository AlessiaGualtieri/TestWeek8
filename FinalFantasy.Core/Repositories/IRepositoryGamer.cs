using FinalFantasy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Repositories
{
    public interface IRepositoryGamer
    {

        public bool Register(string nickname);

        public bool Login(string nickname);
    }
}
