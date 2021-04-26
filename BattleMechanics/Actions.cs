using System;
using System.Collections.Generic;
using System.Text;

namespace BattleMechanics
{
    /// <summary>
    /// this is the action class that hold actions any character can preform such as attacking
    /// it holds all relivant methods to whats need for doing actions
    /// </summary>
    class Actions
    {
        private Random rnd = new Random();
        /// <summary>
        /// This is the attack action that is called whenever a character wants to attack
        /// it takes in the attacker object
        /// it takes in the defender object
        /// it also take in prints which is a bool that determines if you want the console print to be printed or not
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="target"></param>
        /// <param name="prints"></param>
        /// <returns></returns>
        public int attackAction(CharCreator attacker, CharCreator target, bool prints) 
        {
            int hitChance = 80;// input percent chances
            int chance = rnd.Next(1, 101);
            if (chance < hitChance)
            {
                target.Health = runDamage(attacker.Attack, target.Defense, target.Health, 1, prints);
            }
            else 
            {
                if (prints) { Console.WriteLine("Your attack has missed"); }
            }
            return target.Health;
        }
        /// <summary>
        /// this is the damage calculator that will take in the following params
        /// Attacker's attack stat
        /// Target's defense stat
        /// Target's health stat
        /// Modifier that is added to the equation and should be set to 1
        /// it also take in prints which is a bool that determines if you want the console print to be printed or not
        /// </summary>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <param name="hp"></param>
        /// <param name="MOD"></param>
        /// <param name="prints"></param>
        /// <returns></returns>
        private int runDamage(int atk, int def, int hp, double MOD, bool prints)
        {
            //Damage = (((attacker's attack - Targets Def) * 5) * Any modifiers)
            int dmg = (int)(((atk - def) * 5) * MOD);
            //---this isn't needed but generally its nice to see the damage done
            if (prints) { Console.WriteLine("Total Damage Done: " + dmg); }
            hp = hp - dmg;
            return hp;
        }
    }
}
