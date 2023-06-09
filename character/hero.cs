﻿using System;
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
        public int level { set; get; }
        public void InitHeroCharacter()
        {
            Console.WriteLine("Hello! what do you want to be called?");
            Console.Write("Your name: ");
            name = Console.ReadLine()!;

            Console.WriteLine("Welcome {0}!\n", name);
            HeroClassSelection();

            Console.Clear();
            Console.WriteLine("The dark lord conquered all of the 5 nations and spread its evilness to the whole world, its your duty to stop him.\nAdventure calls...\n");

            level = 1;

            PrintHeroMainStats();
            att.PrintAttributes();

            Console.WriteLine("\nStart your adventure by presing any keys...");
            Console.ReadLine();
        }

        public void GameLoss(int enemiesDefeated)
        {
            Console.Clear();
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Thanks for playing {0}!", name);
            Console.WriteLine("You've reached level {0} and defeated {1} enemies\n", level, enemiesDefeated);

        }

        private void MajorUp()
        {
            att.PrintAttributes(true);
            Console.Write("\nWhich attribute would you like to minor upgrade? ");
            if (!att.UpgradeAtt(Console.ReadLine()!, 4)) MajorUp();
        }

        private void MinorUp()
        {
            att.PrintAttributes(true);
            Console.Write("\nWhich attribute would you like to minor upgrade? ");
            if (!att.UpgradeAtt(Console.ReadLine()!, 2)) MinorUp();
        }


        public void LevelUp()
        {
            Console.Clear();
            Console.WriteLine("LEVEL UP!!!");
            Console.WriteLine($"You just reached level {level++}\n");
            
            MajorUp();
            MinorUp();

            Console.Clear();
            PrintHeroMainStats();
            att.PrintAttributes();

            Console.WriteLine("\nResume your adventure by presing any keys...");
            Console.ReadLine();
        }

        public void PrintHeroMainStats()
        {

            Console.WriteLine("{0} - lvl {1} {2}", name, level, char_class);
        }

        public void HeroClassSelection()
        {
            Console.Write("1 - Wizard (charisma focused)\n2 - Warrior (constitution focused)\n3 - Barbarian (strength focused)\n4 - Rogue (dexterity focused)\n");
            Console.Write("Choose your class: ");
            if (!base.DefineClass(Console.ReadLine()!))
            {
                Console.WriteLine("ops! choosen number does not correspond to any classes, try again!\n\n");
                HeroClassSelection();
            }
        }
    }
}
