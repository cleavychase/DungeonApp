using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class Character
    {
        //Character is goin to serve as the base class for Player and Monster. It will have the general props that will be common between both classes.
        
        
            //The abstract modifyier indicates that the thing being created is an incomplete implementation. The abstract modifyer can be used with classes methods and properties. Using abstract we are saying that you cannot create an object of the type character, but will have to build a complete implementation in the child classes to be used in the program.

            //fields
            private int _life;

            //properties
            public string Name { get; set; }
            public int HitChance { get; set; }
            public int Block { get; set; }
            public int MaxLife { get; set; }
            //Bc we have a biz rule for life we place it AFTER maxLife
            public int Life
            {
                get { return _life; }
                set
                {
                    if (value <= MaxLife)
                    {
                        _life = value;
                    }
                    else
                    {
                        _life = MaxLife;
                    }
                }
            }
            //ctors -- Since we don't inherit constructors, we will not create a constructor

            //methods -- No ToString as we will handle in Player and Monstger but we will have some methods that we want to handle specific functionality in the player and monster classes
            public virtual int CalcBlock()
            {
                //We use the vertual keyword in this to allow child classes to override this method
                return Block;
            }//end calcblock

            public virtual int CalcHitChance()
            {
                return HitChance;
            }

            public virtual int CalcDamage()
            {
                return 0;//starting this with returning 0. we will ovverride this in Monster and player
            }

        
    }
}
