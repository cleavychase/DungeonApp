using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Monster : Character
    {
        //fields
        private int _minDamage;

        //prop
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }//else
            }//set
        }//minDamage

        //ctor - default and fq
        public Monster() { }

        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            //set maxLife and maxDamage
            MaxLife = maxLife;
            MaxDamage = maxLife;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }//8 total

        //methods - ToString, CalcDamage
        public override string ToString()
        {
            return string.Format("\n**** MONSTER ****\n" +
                "{0}\n" +
                "Life: {1} of {2}\n" +
                "Damage: {3} to {4}\n" +
                "Block: {5}\n" +
                "Description:\n{6}\n",
                Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }//end ToString
        //we will override calcdamage to use min and max damage props
        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);//we add 1 here to account for the exclusive upper bound in the .Next()
        }
    }
}
