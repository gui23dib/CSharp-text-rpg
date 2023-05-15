using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace heros_journey_text_RPG.character
{
    public class Hero : Character
    {
        public string name { set; get; }
        int level { set; get; }
        int exp_points { set; get; }

        public void InitHeroCharacter()
        {
            Console.WriteLine("Hello! what do you want to be called?");
            Console.Write("Your name: ");
            name = Console.ReadLine();

            Console.WriteLine("Welcome {0}!\n", name);
            HeroClassSelection();

            //Sleep(1)

            Console.Clear();
            Console.WriteLine("The dark lord conquered all of the 5 nations and spread its evilness to the whole world, its your duty to stop him.\nAdventure calls...\n");

            base.action_points = 1;
            level = 1;
            exp_points = 0;
            health_points = 12;

            Console.WriteLine("{0} - lvl {1} {2}", name, level, char_class);
            Console.WriteLine("HP: {0} \t EXP: {1}\n", health_points, exp_points);

            base.att.PrintAttributes();

            Console.WriteLine("\nStart your adventure by presing any keys...");
            Console.ReadLine();
        }

        public void HeroClassSelection()
        {
            Console.Write("1 - Wizard\n2 - Warrior\n3 - Barbarian\n");
            Console.Write("Choose your class: ");
            switch (Console.ReadLine())
            {
                case "1":
                    char_class = Character.Classes.Wizard;
                    break;
                case "2":
                    char_class = Character.Classes.Warrior;
                    break;
                case "3":
                    char_class = Character.Classes.Barbarian;
                    break;
                default:
                    Console.WriteLine("ops! choosen number does not correspond to any classes, try again!\n\n");
                    HeroClassSelection();
                    break;
            }
        }
    }
}
