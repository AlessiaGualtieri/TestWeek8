using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Entities
{
    public abstract class Creature
    {
        protected int _level = 1;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Weapon Weapon { get; set; }
        public string WeaponName { get; set; }
        //public virtual int Level {
        //    get { return CalculateLvl(); }
        //    set { _level = value; }
        //}
        public int HP { get { return _level * 20; } }


        protected virtual int CalculateLvl()
        {
            return _level;
        }
    }
}
