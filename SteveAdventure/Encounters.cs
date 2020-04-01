using System;

namespace SteveAdventure
{
    public class Encounters
    {
       static Random rand = new Random();
        //encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("you see a rusty sword at your feet, you grab it and charge the unexpecting skeleton");
            Console.WriteLine("The skeleton turns ...");
            Console.ReadKey();
            Combat(false, "Skeleton", 3, 5);
        }

        public static void BasicEncounter()
        {
            Console.Clear();
            Console.WriteLine("you turn turn the corner and you find another enemy...");
            Console.ReadKey();
            Combat(true, "",0,0);
        }

        public static void WizardEncounter()
        {
            Console.Clear();
            Console.WriteLine("some purple smoke appears, you hear a deep laugh and an evil wizard emerges");
            Console.ReadKey();
            Combat(false, "Dark Wizard", 4,7);
        }
        
        //encounter tools

        public static void RandomEncounter()
        {
            if (Program.currentPlayer.amountDefeated < 3)
            {
                BasicEncounter();
            }
            else
            {
                WizardEncounter();
            }
            
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            
            if (random)
            {
                n = GetName();
                p = rand.Next(1, 4);
                h = rand.Next(5, 10);
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }

            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine("power " + p + " / " + " health "+ h);
                Console.WriteLine("======================");
                Console.WriteLine("|    (A)tk (D)ef     |");
                Console.WriteLine("|    (R)un (H)eal    |");
                Console.WriteLine("======================");
                Console.WriteLine("Potions: "+Program.currentPlayer.potion+ "  Health: "+ Program.currentPlayer.health );
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack"|| input.ToLower() == "atk")
                {
                    int damage = p - Program.currentPlayer.armorvalue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(1, Program.currentPlayer.weaponValue) + rand.Next(1,4);
                    //attack
                    Console.WriteLine("You prepare to attack the enemy! The "+n+" strikes first!");
                    Console.WriteLine(" you lose "+ damage +" health, your attack deals "+ attack +" damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
              
                else if (input.ToLower() == "d" || input.ToLower() == "defend"|| input.ToLower() == "def")
                {
                    //defend
                    int damage = (p/4) - Program.currentPlayer.armorvalue;
                    if (damage < 0)
                    {
                        damage = rand.Next(0, 2);
                    }
                    int attack = rand.Next(1, Program.currentPlayer.weaponValue)/2;
                    if (attack <1)
                    {
                        attack = rand.Next(0, 2);
                    }
                    //attack
                    Console.WriteLine("the " + n + " strikes, you go into a defensive stance with your sword");
                    Console.WriteLine(" you lose "+ damage +" health, your attack deals "+ attack +" damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("you fail to run away. The" + n + " strikes you");
                        int damage = p- Program.currentPlayer.armorvalue;
                        if (damage < 0)
                        {
                            damage = rand.Next(0, 2);
                        }
                        Console.WriteLine("you take " + damage + " damage");
                        Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You sprint away, you escape succesfully! ");
                        Console.ReadKey();
                        //go to store
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    
                    //heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You don't have any potions left! The "+ n + " strikes you");
                        int damage = p - Program.currentPlayer.armorvalue;
                        if (damage < 0)
                        {
                            damage = rand.Next(0, 2);
                        }
                        Console.WriteLine("you take " + damage + " damage");
                        Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You drink a health potion ");
                        int potion = 10;
                        Console.WriteLine("You gain " + potion + " health");
                        Program.currentPlayer.health += potion;
                        if (Program.currentPlayer.health > Program.currentPlayer.maxhealth)
                        {
                            Program.currentPlayer.health = Program.currentPlayer.maxhealth;
                        }
                        Program.currentPlayer.potion--;
                        Console.WriteLine("The " +n+ " strikes while you drink");
                        int damage = p- Program.currentPlayer.armorvalue;
                        if (damage < 0)
                        {
                            damage = rand.Next(0, 2);
                        }
                        Console.WriteLine("you take " + damage + "damage");
                        Program.currentPlayer.health -= damage;
                    }

                    Console.ReadKey();
                }

                if (Program.currentPlayer.health<=0)
                {
                    //death
                    Console.WriteLine("You are defeated by " +n+", you die ");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();

            }

            int c = rand.Next(10, 50);
            Console.WriteLine("You loot the defeated " + n + " you gain " +c +" gold coins!");
            Program.currentPlayer.coins += c;
            Program.currentPlayer.amountDefeated++;
            Console.WriteLine("you now have " + Program.currentPlayer.coins + " coins");
            Console.WriteLine("you now have defeated " + Program.currentPlayer.amountDefeated +" enemies");
            Console.ReadKey();
        }

        public static string GetName()
        {
            switch (rand.Next(0, 4))
            {
                //no break cuz return statement
                case 0:
                    return "zombie";
                case 1:
                    return "goblin";
                case 2:
                    return "robber";
                case 3:
                    return "boar";

            }

            return "skeleton";
        }
    }
}