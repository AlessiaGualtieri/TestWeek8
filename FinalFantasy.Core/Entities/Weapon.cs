using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Entities
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public string Category { get; set; }
        public ICollection<Creature> Creatures { get; set; } = new List<Creature>();

        public override string ToString()
        {
            return $"{Name} ({Damage} dmg)";
        }
    }
}
