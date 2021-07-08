using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Entities
{
    public class Game
    {
        public ICollection<Gamer> Users { get; set; } = new List<Gamer>();


    }
}
