using heros_journey_text_RPG.encounters;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace heros_journey_text_RPG.character
{
    public class Attributes
    {
        int dex; //dexterity
        int str; //strentgh
        int cons; //constitution
        int wis; //wisdowm
        int inte; // intelligence
        int cha; //charisma

        public void InitAllAttributtes()
        {
            str = constants.BaseAttNum;
            dex = constants.BaseAttNum;
            cons = constants.BaseAttNum;
            cha = constants.BaseAttNum;
            inte = constants.BaseAttNum;
            wis = constants.BaseAttNum;

            PrintAttributes();
        }

        public void PrintAttributes()
        {
            Console.WriteLine("<{0}> strength", str);
            Console.WriteLine("<{0}> dexterity", dex);
            Console.WriteLine("<{0}> constitution", cons);
            Console.WriteLine("<{0}> charisma", cha);
            Console.WriteLine("<{0}> intelligence", inte);
            Console.WriteLine("<{0}> wisdom", wis);
        }

    }
    public class Character
    {
        public int? npcId;
        public string name;
        public int health_points;
        int exp_points;
        int action_points;
        int level;
        string char_class;
        public Attributes att = new Attributes();

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

            action_points = 1;
            level = 1;
            exp_points = 0;
            health_points = 12;

            Console.WriteLine("{0} - lvl {1} {2}", name, level, char_class);
            Console.WriteLine("HP: {0} \t EXP: {1}\n", health_points, exp_points);

            att.InitAllAttributtes();

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
                    char_class = "Wizard";
                    break;
                case "2":
                    char_class = "Warrior";
                    break;
                case "3":
                    char_class = "Barbarian";
                    break;
                default:
                    Console.WriteLine("ops! choosen number does not correspond to any classes, try again!\n\n");
                    HeroClassSelection();
                    break;
            }
        }
    }
}