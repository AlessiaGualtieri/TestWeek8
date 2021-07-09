using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Entities
{
    public class Hero : Creature
    {
        private int _experience = 0;
        public int Experience { get {return _experience; } }
        public int Level
        {
            get { return CalculateLvl(); }
        }
        public Gamer Gamer { get; set; }
        public string GamerNickname { get; set; }

        public void IncrementExperience(int exp)
        {
            _experience += exp;
        }

        protected override int CalculateLvl()
        {
            int thresholdExp = 0;
            switch (_level)
            {
                case 1:
                    if (_experience > 29)
                        thresholdExp = 29;
                    break;
                case 2:
                    if (_experience > 59)
                        thresholdExp = 59;
                    break;
                case 3:
                    if (_experience > 89)
                        thresholdExp = 89;
                    break;
                case 4:
                    if (_experience > 119)
                        thresholdExp = 119;
                    break;
            }
            if(thresholdExp != 0)
            {
                _level++;
                _experience -= thresholdExp;
            }
            return _level;
        }

        public override string ToString()
        {
            return $"******************************\n" +
                $"Name : {Name}\n" +
                $"Category : {Category}\n" +
                $"Weapon : {Weapon}\n" +
                $"-----" +
                $"Level : {Level}\n" +
                $"Total HP : {HP}\n" +
                $"Exp : {Experience}\n" +
                $"******************************\n";
        }
    }
}
