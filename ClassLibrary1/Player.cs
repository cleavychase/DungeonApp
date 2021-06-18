using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public sealed class Player : Character
    {
        //fields - n/a

        //properties
        
        public Weapon EquippedWeapon { get; set; }

        //ctor - FQ
        public Player(string name, int hitChance, int block, int life, int maxLife, Weapon equippedWeapon)
        {
            //Prop = param
            MaxLife = maxLife;//Maxlife is listed first bc other values depend on this on to set properly.
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            EquippedWeapon = equippedWeapon;
        }//end fqctor

        //methods
        public override string ToString()
        {
            return string.Format("-=-= {0} =-=-\n" +
                "Life: {1} of {2}\n" +
                "Hit Chance: {3}%\n" +
                "Weapon:\n{4}\n" +
                "Block: {5}\n",
                Name, Life, MaxLife, HitChance, EquippedWeapon, Block);
        }//end ToString

        //Build 2 method overrides below which are inherited from the Character class
        public override int CalcDamage()
        {
            //create random object
            Random rand = new Random();
            //determine damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            //return damage
            return damage;

        }//end CalcDamage

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }//end CalcHitChance
    }
}
