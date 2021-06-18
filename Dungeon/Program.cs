using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeon of Doom";
            Console.WriteLine("You have just been startled awake by a clap of thunder. Your clock shows it is 3am on the dot. You try to settle back into sleep but you can't help feeling unsettled. Trying to clear your sleepy fog, you turn on the bedside lamp. You are startled to see your mother kneeling in your closet digging through your dirty clothes. ");
            Console.WriteLine("'Mom?' you call out. She doesn't turn around. She leans in further, frantically digging. You get out of bed and approach her. Reaching out to touch her shoulder you bend down. Just as your hand approaches her, you feel a sudden rush of wind. It feels like two hands have shoved you from behind very hard. You tumble into the closet and hear the door slam shut behind you. You pull the string on the naked bulb above you and realize you are alone. You turn to open the door behind you. As your hand touches the knob you feel a snap of static. That the strange wind picks back up...");

            //score running total variable
            int score = 0;

            // create the player
            //need to learn custom classes for this
            //Creating a weapon & creating the player with the weapon included.
            Weapon sword = new Weapon(1, 8, "Sword", 10, false);
            //this is the place where you could give the user interaction to choose what Race or Weapon they use in the game.
            Player player = new Player("Sam", 70, 5, 40, 40, sword);
            bool exit = false;

            do
            {
                //Create a monster array
                Spider s1 = new Spider();//uses the default ctor to make a baby rabbit.. see rabit class
                Spider s2 = new Spider("Cat Spider", 25, 25, 50, 20, 2, 8, "That's no ordinary spider...", true);
                Vampire v1 = new Vampire();
                MadMonk m1 = new MadMonk();


                //since all of our child monsters are all of the type monster, we can store them in an array of Monster. This is polymorphism at it's best.
                Monster[] monsters = { s1, s2, v1, m1 };
                //- load a room
                Console.WriteLine(GetRoom());
                //randomly select a monster to fight
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                //show the monster in room
                Console.WriteLine("\nIn this room: " + monster.Name);
                //Inner loop for menu
                bool reload = false;

                do
                {
                    //create a menu
                    #region Menu
                    Console.WriteLine("\nPlease choose an Action:\n" +
                        "A)ttack\n" +
                        "R)un\n" +
                        "Player Info\n" +
                        "M)onster Info\n" +
                        "X) EXIT\n");

                    //catch the user choice
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    //clear console after choice
                    Console.Clear();

                    //Build your menu functionality
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Attack");
                            // handle attack functionality
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //monster is dead... you cuold put logic here to have the player get bonus, loot, or something similar due to defeating the monster.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}\n", monster.Name);
                                Console.ResetColor();
                                //reload new room and monster
                                reload = true;
                                //add to player score
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("You try to escape the monster");
                            Console.WriteLine($"You run in the oposite direction, {monster.Name} attacks you as you go");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;//load
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player info");
                            //TODO handle showing player info
                            Console.WriteLine(player);
                            Console.WriteLine("Monsters defeated: " + score);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster info");
                            // - Handle showing monster info
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("You wake up in a cold sweat. Was it all a dream?");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("You must still be quite sleepy, please try a valid response.");
                            break;
                    }//end switch
                    #endregion

                    //check player life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You died.");
                        Console.WriteLine($"You defeated {score} monsters during your game.");
                    }
                } while (!exit && !reload);

            } while (!exit);
            //this will display the score to the user when exiting program
            Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s."));
        }//end main
         //Create a GetRoom() & plug this in the appropriate ToDo above
        private static string GetRoom()
        {
            //Create a collection of different rooms.
            string[] rooms =
            {
                "The clothing hanging from the racks around you seems to somehow simultaniously harden and liquify before your eyes. The naked bulb above you begins to flicker. As you look up you realize that the bulb is no longer that at all. It is now a flickering lantern which seems to be low on fuel. The wood floor has warped and turned to stone. What were once small piles of old clothes at the edges of the closet are now stalagmites that reach the height of your waist. The air is damp and cool and unmoving. At the lowest range of your hearing you hear (feel?) a deep, reverberating echo. You sense you are not alone.",
                "The walls around you begin to spread. The light above seems to pull away, casting devious shadows of the clothes hanging. You look up to see that the light bulb has gone completely. You see now that the only light comes from a sliver of moonlight which eeks in from great, ornate windows. In the dim light you can see that the popcorn ceiling has been replaced by a vaulted cathedral like roof. You feel that the floor below you is now cold marble. There is something echoing within these walls. Is that chanting?",
                "The walls begin to pull in around you. The light above you blinks out. You feel a stange sensation of your center of gravity changing. The wall behind you butts up to your back as you realize you are now laying down agianst it. You try to sit up but knock your head against wood. Feeling around you realize that you are surrounded by boards with only half a foot of clearence in any direction. The air is stale and, is there less oxygen than a minute ago? You feel a weight against your legs and realize there is something heavy shimmying up your body",
            };
            //Generate a random object
            Random rand = new Random();
            //generate a random index number in the next()
            int indexNbr = rand.Next(rooms.Length);
            //create a string for the dsingle room that will be returned 
            string room = rooms[indexNbr];
            //return the room
            return room;
        }
    }
}
