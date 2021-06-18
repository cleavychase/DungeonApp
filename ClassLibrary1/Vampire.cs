using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Vampire : Monster
    {
        //prop


        //ctor
        //Extra functionallity is built into constuctor.
        //public Vampire() { }
        //public Vampire(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description);
     //fqctor
     //default ctor - set some values hardcoded into the rabbit object so we don't have to explicitly list all of the values associated a Rabbit
        public Vampire()
        { 
        MaxLife = 8;//set max values first
        MaxDamage = 4;
        Name = "Nosferatu";
        Life = 6;
        HitChance = 20;
        Block = 20;
        MinDamage = 1;
        Description = "His long, clammy finger reach out to you like claws, trying to draw you in.";
        }//end default ctor



}
}
