using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Entities
{
    public class Monster : Creature
    {
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
    }
}
