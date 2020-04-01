using System;

namespace SteveAdventure
{
    //resume 11.54
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
            
        }

        static void Start()
        {
            Console.WriteLine(("Steve's Dungeon!"));
            Console.WriteLine("Name:");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("you wake up in a chilly dark dungeon. You don't know how you got here");
            if (currentPlayer.name == "")
            {
                Console.WriteLine("You can't even remember your name");
            }
            else
            {
                Console.WriteLine("All you remember is your name " + currentPlayer.name);
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("you feel around in the darkness, you find a door");
            Console.WriteLine("you turn the handle and see it opens quite easily, you find a skeleton outside");
            Console.WriteLine("its back is turned to you");

        }
    }
}