using FinalFantasy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Repositories
{
    public interface IRepositoryMonster
    {
        public Monster RandomMonster(int maxLvl);
    }
}
