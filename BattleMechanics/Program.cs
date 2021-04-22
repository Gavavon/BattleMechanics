/*
 * Creator: Gavin O'Hanlon
 * Created Date: 11/22/2020
 * Revised Date: 04/16/2021 - 04/17/2021
 * Github: https://github.com/Gavavon
 * 
 */

/* Explination of Code
 * This code is meant to be a prof of concept and a damage calculator experiment
 * In the program class it allows the user to check duration of battles and have classes battle each other for testing purposes
 * Character are randomly created via other classes and the characters are designed to be balance
 * I designed this for use in another more complex project but this is my starting point.
 * 
 * This code was also a way for me to show off coding skills and try to do it as effciently as possible and up to best practices
 * 
 * Additionally feel free to use the damage caluclation and stat ideas
 * currently i removed the ability to make custom characters in favor of balance however 
 * dont hesitate to clone the repo and mess around with these ideas
 */

using BattleMechanics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FightingCombatTest
{
    /// <summary>
    /// Program class holds main and minimal declarations
    /// Program runs all the core code for the program
    /// </summary>
    class Program
    {
        //Declares all characters and creates them using appropriate class
        static CharCreator assassin1 = new Assassin();
        static CharCreator assassin2 = new Assassin();
        static CharCreator assassin3 = new Assassin();

        static CharCreator tank1 = new Tank();
        static CharCreator tank2 = new Tank();
        static CharCreator tank3 = new Tank();

        static CharCreator fighter1 = new Fighter();
        static CharCreator fighter2 = new Fighter();
        static CharCreator fighter3 = new Fighter();


        //Create participants
        static CharCreator attacker = new CharCreator();
        static CharCreator defender = new CharCreator();
        static void Main(string[] args)
        {

            //Heroes list to access all the heroes from one list
            List<CharCreator> heroes = new List<CharCreator>();
            heroes.Add(assassin1);
            heroes.Add(assassin2);
            heroes.Add(assassin3);
            heroes.Add(tank1);
            heroes.Add(tank2);
            heroes.Add(tank3);
            heroes.Add(fighter1);
            heroes.Add(fighter2);
            heroes.Add(fighter3);


            //List all heros by their class and ID to be referenced by user
            Console.WriteLine("Here is a list of Hero IDs: ");
            for (int i = 0; i < (heroes.Count); i++)
            {
                Console.WriteLine("Class: " + heroes[i].Class + " ID: " + heroes[i].ID);
            }



            //forces the user to input IDs of two heros that while be utilized in the code later
            Boolean cleared = true;
            Console.WriteLine("Please input the Attacker and Defender by inputing an ID: ");
            //creates a list of participants and allows the player to choose the participants
            List<CharCreator> participants = new List<CharCreator>();
            participants.Add(attacker);
            participants.Add(defender);
            for (int j = 0; j < participants.Count; j++)
            {
                do
                {
                    if (j == 0){Console.WriteLine("Please input the Attacker: ");}
                    else {Console.WriteLine("Please input the Defender: ");}
                    string participantsID = Console.ReadLine();
                    //check if the hero id is in the list
                    for (int i = 0; i < heroes.Count; i++)
                    {
                        if (participantsID.Equals(heroes[i].ID))
                        {
                            participants[j].ID = (heroes[i].ID);
                            participants[j].Attack = (heroes[i].Attack);
                            participants[j].Defense = (heroes[i].Defense);
                            participants[j].Health = (heroes[i].Health);
                            participants[j].Speed = (heroes[i].Speed);
                            participants[j].Class = (heroes[i].Class);
                            cleared = false;
                            break;
                        }
                    }
                } while (cleared);//if the hero id wasn't in the list than redo
            }

            //this created an attacker and a defender to work with

            Console.WriteLine("");
            Console.WriteLine("attacker's Info:");
            info(attacker);
            Console.WriteLine("Defender's Info:");
            info(defender);
            //below is a do while statement that allows the user to simulate one of two options
            //CheckDur will have the attacker attack the defender until the defender is out of health and will return the number of turns
            //Battle will have the participants attack each other until one has died
            cleared = true;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Would you like to: ");
                Console.WriteLine("Check Combat Duration: CheckDur");
                Console.WriteLine("Have the Heroes Battle: Battle");
                Console.WriteLine("End Program: Stop");
                Console.WriteLine("");
                Console.WriteLine("Please input your answer: ");
                string response = Console.ReadLine();

                if (response.Equals("CheckDur"))
                {
                    Console.WriteLine("");
                    int counter = 0;
                    counter = checkDur(defender.Health, counter);
                    Console.WriteLine("After " + counter + " turns the Defender now has 0 health");
                    cleared = false;
                }
                if (response.Equals("Battle"))
                {
                    Console.WriteLine("");
                    fight();
                    cleared = false;
                }
                if (response.Equals("Stop"))
                {
                    cleared = false;
                }

            } while (cleared);//an input is invalid redo

            //---Program Ends---
        }

        /// <summary>
        /// Info is a simple method that takes in infoHolder a CharCreator Object
        /// it prints out all the information associated with a CharCreator Object
        /// </summary>
        /// <param name="infoHolder"></param>
        public static void info(CharCreator infoHolder)
        {
            
            Console.WriteLine("ID: " + infoHolder.ID);
            Console.WriteLine("Class: " + infoHolder.Class);
            Console.WriteLine("Health: " + infoHolder.Health);
            Console.WriteLine("Attack: " + infoHolder.Attack);
            Console.WriteLine("Defense: " + infoHolder.Defense);
            Console.WriteLine("Speed: " + infoHolder.Speed);
            Console.WriteLine("");
        }

        /// <summary>
        /// The Fight method decides who goes first it has a compareTo that compares speeds
        /// and a switch statement that based on the compare to sends the particip[ants to the battle method
        /// if the speeds are equal it randomly decides who goes first
        /// </summary>
        public static void fight()
        {
            int temp = defender.Speed.CompareTo(attacker.Speed);
            switch (temp)
            {
                case 1:
                    Console.WriteLine("The Defender goes first");
                    battle(defender, attacker);
                    break;
                case 0:
                    Random rand = new Random();
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("The Defender goes first");
                        battle(defender, attacker);
                    }
                    else
                    {
                        Console.WriteLine("The Attacker goes first");
                        battle(attacker, defender);
                    }
                    break;
                case -1:
                    Console.WriteLine("The Attacker goes first");
                    battle(attacker, defender);
                    break;
            }

        }

        /// <summary>
        /// The Battle method takes in two CharCreator objects
        /// it is designed to be used in the fight method to commence the fighting based on who has the higher speed
        /// the params are first and second characters based on the speeds decided in the prevous method
        /// the battle method also decides who wins if they fight based on health and using the runDamage method
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public static void battle(CharCreator first, CharCreator second)
        {
            //---This method runs the damage mechanic based on who goes first---
            while (first.Health > 0 && second.Health > 0)
            {
                //---This uses the RunDamage method to calculate the damage per turn and alters health based on damage done---
                first.Health = (runDamage(second.Attack, first.Defense, first.Health, 1));
                if (first.Health > 0 && second.Health > 0)
                {
                    second.Health = (runDamage(first.Attack, second.Defense, second.Health, 1));
                }
            }

            if (defender.Health > 0)
            {
                Console.WriteLine("The Defender Won the battle ");
                Console.WriteLine("Defender's current health: " + defender.Health);
                Console.WriteLine("Attacker's current health: " + attacker.Health);
            }
            else
            {
                Console.WriteLine("The Attacker Won the battle ");
                Console.WriteLine("Defender's current health: " + defender.Health);
                Console.WriteLine("Attacker's current health: " + attacker.Health);
            }
        }

        /// <summary>
        /// The checkDur has the attacker attack the defender to test combat duration
        /// This method utilizes recursion to return counter instead of a simple wh
        /// the point is to test how long combat would last and how many hits it would take against different classes
        /// </summary>
        public static int checkDur(int health, int counter)
        {
            if (health <= 0)
            {
                return counter;
            }
            else 
            {
                Console.WriteLine("Defender's current health: " + health);
                counter += 1;
                health = (runDamage(attacker.Attack, defender.Defense, health, 1));
                return checkDur(health, counter);
            }
        }

        /// <summary>
        /// The runDamage method takes in params that a CharCreator Object have particularly
        /// the attack stat of the attacking object
        /// the defense stat of the defending object
        /// the health stat of the defending object
        /// and the Modifer of the attacking object
        /// The method will return the health of the defending object after the damage has been done via the equation in the method
        /// currently no class has a special modifier so it defualts to 1 however that can change
        /// </summary>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        /// <param name="hp"></param>
        /// <param name="MOD"></param>
        /// <returns></returns>
        public static int runDamage(int atk, int def, int hp, double MOD)
        {
            //Damage = (((attacker's attack - Targets Def) * 5) * Any modifiers)
            int dmg = (int)(((atk - def) * 5) * MOD);
            //---this isn't needed but generally its nice to see the damage done
            Console.WriteLine("Total Damage Done: " + dmg);
            hp = hp - dmg;
            return hp;
        }
    }
}
