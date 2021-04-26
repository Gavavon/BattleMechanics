/*
 * Creator: Gavin O'Hanlon
 * Created Date: 11/22/2020
 * Revised Date: 4/26/2021
 * Github: https://github.com/Gavavon
 * LinkedIn: https://www.linkedin.com/in/gavinlohanlon/
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
        //Create participants
        static CharCreator attacker = new CharCreator();
        static CharCreator defender = new CharCreator();

        static List<CharCreator> participants = new List<CharCreator>();
        static void Main(string[] args)
        {
            var types = new List<CharCreator>
{
                new Assassin(),
                new Tank(),
                new Fighter(),
                new Healer()
            };

            participants.Add(attacker);
            participants.Add(defender);

            //--- this for loop and while are made for the user to decide what classes they want to use
            Console.WriteLine("Please input the class you want your first participant to be");
            Console.WriteLine("0 for Assassin");
            Console.WriteLine("1 for Tank");
            Console.WriteLine("2 for Fighter");
            Console.WriteLine("3 for Healer");
            Console.WriteLine("4 for all class info");
            Boolean cleared = true;
            for (int j = 0; j < participants.Count; j++)
            {
                Console.WriteLine("Please Input the next participant");
                cleared = true;
                do
                {
                    string hold = Console.ReadLine();
                    int answer = Convert.ToInt32(hold);

                    if (answer >= 0 && answer <= 3)
                    {
                        types[answer].defineChar(participants[j]);
                        cleared = false;
                    }
                    if (answer == 4) 
                    {
                        Console.WriteLine("Assassin has high attack and speed but low defense and health");
                        Console.WriteLine("Tank has high defense and health but low attack and speed");
                        Console.WriteLine("Fighter has mid attack, defense, speed, health");
                        Console.WriteLine("Healer has high speed and health but low attack and defense");
                        Console.WriteLine("");
                        Console.WriteLine("Please Input the next participant");
                        cleared = true;
                    }
                } while (cleared) ;

            }
            //---

            Console.WriteLine("");
            showParticipants(0);


            //--- this do while is for the user to decide what they want to do with the characters
            cleared = true;
            do
            {
                string[] options = new string[3] { "fight", "check duration", "stop" };
                Console.WriteLine("");
                Console.WriteLine("Would you like to: ");
                Console.WriteLine("Have the participants: " + options[0]);
                Console.WriteLine("Check average duration of combat: " + options[1]);
                Console.WriteLine("End Program: " + options[2]);
                Console.WriteLine("");
                Console.WriteLine("Please input your answer: ");
                string response = Console.ReadLine();

                if (response.ToLower() == options[0])
                {
                    Console.WriteLine("");
                    fight(participants[0], participants[1]);
                    cleared = false;
                }
                if (response.ToLower() == options[1])
                {
                    duration(participants[0], participants[1]);
                    cleared = false;
                }
                if (response.ToLower() == options[2])
                {
                    cleared = false;
                }

            } while (cleared);
            //---
            //---Program Ends---
        }
        /// <summary>
        /// this shows a list of participants by taking in count which should be 0 when first used
        /// this uses recursion so if the list of participants ever grows past 2 than this will 
        /// easily still show all information
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int showParticipants(int count) 
        {
            if (count >= participants.Count)
            {
                return 0;
            }
            else 
            {
                Console.WriteLine("Participant " + (count + 1) + " Info:");
                info(participants[count]);
                count += 1;
                return showParticipants(count);
            }
            

            
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
        /// this reorders the list of characters dependant on their speed.
        /// this can only be done for a list of two however and would need 
        /// to be adapted for larger lists and groups
        /// </summary>
        public static List<CharCreator> checkFirst(List<CharCreator> parts)
        {
            CharCreator hold = new CharCreator();
            int temp = parts[0].Speed.CompareTo(parts[1].Speed);
            switch (temp)
            {
                case 1:
                    return parts;
                case -1:
                    hold = parts[0];
                    parts.RemoveAt(0);
                    parts.Add(hold);
                    return parts;
                default:
                    Random rand = new Random();
                    if (rand.Next(0, 2) == 0)
                    {
                        return parts;
                    }
                    else
                    {
                        hold = parts[0];
                        parts.RemoveAt(0);
                        parts.Add(hold);
                        return parts;
                    }
            }
        }
        /// <summary>
        /// this method checks the average duration of battles
        /// it takes in the (part1)participant 1 and (part2)participant 2
        /// this will than have them attack each other until one of them dies to complete a battle
        /// they will battle 1000 times and keep track of how many turns per battle happen
        /// </summary>
        /// <param name="part1"></param>
        /// <param name="part2"></param>
        public static void duration(CharCreator part1, CharCreator part2)
        {
            Console.WriteLine("");
            List<CharCreator> fighters = checkFirst(participants);
            int p1Health;
            part1 = fighters[0];
            p1Health = part1.Health;
            int p2Health;
            part2 = fighters[1];
            p2Health = part2.Health;
            int turn = 0;
            int averageTurns = 0;
            int battles = 1000;

            for (int i = 0; i < battles; i++)
            {
                while (part1.Health > 0 && part2.Health > 0)
                {
                    turn += 1;
                    part2.Health = part1.attackAction(part1, part2, false);
                    if (part1.Health > 0 && part2.Health > 0)
                    {
                        turn += 1;
                        part1.Health = part2.attackAction(part2, part1, false);
                    }
                }
                averageTurns += turn;
                turn = 0;
                part1.Health = p1Health;
                part2.Health = p2Health;
            }
            averageTurns = averageTurns / battles;
            Console.WriteLine("");
            Console.WriteLine("We had these two character battle " + battles + " times");
            Console.WriteLine("The average turn count per battle is " + averageTurns);
        }
        /// <summary>
        /// This method runs the fighting between two characters
        /// it takes in the (part1)participant 1 and (part2)participant 2
        /// this will than have them attack each other until one of them dies
        /// </summary>
        /// <param name="part1"></param>
        /// <param name="part2"></param>
        public static void fight(CharCreator part1, CharCreator part2) 
        {
            Console.WriteLine("");
            List<CharCreator> fighters = checkFirst(participants);
            part1 = fighters[0];
            part2 = fighters[1];
            while (part1.Health > 0 && part2.Health > 0)
            {
                Console.WriteLine("Fighter 1 attacks");
                part2.Health = part1.attackAction(part1, part2, true);
                if (part1.Health > 0 && part2.Health > 0) 
                {
                    Console.WriteLine("Fighter 2 attacks");
                    part1.Health = part2.attackAction(part2, part1, true);
                }
            }
            if (part1.Health <= 0)
            {
                Console.WriteLine("Fighter 1 lost");
                Console.WriteLine("Fighter 2 is at " + part2.Health + " Health");
            }
            else
            {
                Console.WriteLine("Fighter 2 lost");
                Console.WriteLine("Fighter 1 is at " + part1.Health + " Health");
            }
        }
    }
}
