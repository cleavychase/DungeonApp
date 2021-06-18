using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Spider : Monster
    {
        //fields/props
        public bool IsLarge { get; set; }

        //ctors
        //fqctor - used to make the boss bunny in our app
        public Spider(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isLarge) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            //just handle the unique prop assignment
            IsLarge = isLarge;
        }//fqctor
        //default ctor - set some values hardcoded into the rabbit object so we don't have to explicitly list all of the values associated a Rabbit
        public Spider()
        {
            MaxLife = 6;//set max values first
            MaxDamage = 3;
            Name = "Cat Spider";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "A spider the size of your average house cat.";
            IsLarge = false;
        }//end default ctor

        //methods - ToString, CalcBlock
        public override string ToString()
        {
            return base.ToString() + (IsLarge? "Large." : "Not so large...");

        }//end tostrong override
        //if buny is fluffy, we will give 50% bonus to block value
        public override int CalcBlock()
        {
            //typically when dealing with a method that has a return type, youll want to create a variable of the type you need to return with some default value, then write the return line and then write the code in between.
            int calculatedBlock = Block;
            if (IsLarge)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock = Block;
        }
    }
}
