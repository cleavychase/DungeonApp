using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MadMonk : Monster
    {
        public MadMonk()
        {
            MaxLife = 8;//set max values first
            MaxDamage = 4;
            Name = "Rasputin";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "His yellow eyes burn like cigarettes and dead skin hangs off his bones. Poisoned, shot, and drowned: he wants revenge at any cost. Good luck convincing him you aren't Yusupov's decendant.";
        }//end default ctor
    }
}
