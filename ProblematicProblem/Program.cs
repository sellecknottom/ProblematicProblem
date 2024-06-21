using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ProblematicProblem
{
    class Program
    {
        private static Random rng = new Random();
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party",
        "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? true/false: ");
            bool.TryParse(Console.ReadLine().ToLower(), out cont);
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            if (int.TryParse(Console.ReadLine(), out int userAge))
                Console.WriteLine($"You are {userAge} years old.");
            else
                Console.WriteLine("Invalid input. It needs to be a nice, whole number. Don't try to be clever.");
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? true / false: ");
            bool.TryParse(Console.ReadLine().ToLower(), out bool seeList);
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? true / false: ");
                bool.TryParse(Console.ReadLine().ToLower(), out bool addToList);
                Console.WriteLine();
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.WriteLine($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? true/false: ");
                    bool.TryParse(Console.ReadLine().ToLower(), out bool userAddToList);
                    if (!userAddToList)
                    {
                        break;
                    }
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Do you want to grab another activity? true/false: ");
                Console.WriteLine();
                bool.TryParse(Console.ReadLine(), out cont);
            }
        }
    }
}