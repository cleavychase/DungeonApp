using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Weapon
    {
        //fields
        private int _minDamage;

        //properties
        //minDamage will be based off of MaxDamage, so we will set that first.
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public bool IsTwoHanded { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //cannot be more than MaxDamage or less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }
        //ctors
        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded)
        {
            //if you have any properties that have business rules that are based on other properties
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }
        //methods
        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} Damage\n" +
                "Bonus Hit: {3}%\t{4}",
                Name, MinDamage, MaxDamage, BonusHitChance, IsTwoHanded ? "Two Handed" : "One Handed");
        }//end ToString()
    }
}
