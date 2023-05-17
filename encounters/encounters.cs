using heros_journey_text_RPG.character;
using heros_journey_text_RPG.encounters;
using heros_journey_text_RPG.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heros_journey_text_RPG.encounters
{
    public class Encounter
    {
        string situation { set; get; }
        string location { set; get; }
        Enemy Enemy = new Enemy();
        private Hero Hero;

        private Actions actions;
        public bool continueEncounter = false;

        public Encounter(Hero hero) {
            GenerateEncounter();
            Hero = hero;
            actions = new Actions(Hero, Enemy);
        }

        private void GenerateEncounter()
        {
            situation = Utils.GetRandomFileLine("..\\..\\..\\files\\situations.txt");
            location = Utils.GetRandomFileLine("..\\..\\..\\files\\locations.txt");
            Enemy.name = Utils.GetRandomFileLine("..\\..\\..\\files\\characters.txt");
        }

        private void PrintEncounter()
        {
            string characterPrefix = "aeiouAEIOU".IndexOf(Enemy.name[0]) >= 0 ? "an" : "a";
            Console.WriteLine("You found {0} {1} in {2} {3}\n", characterPrefix, Enemy.name, location, situation);
        }

        private bool GetEncounterOtpions()
        {
            Console.WriteLine("1 - Attack\n2 - Run\n3 - Talk");

            Console.Write("Choose your action: ");
            var UserInput = Console.ReadLine();
            if (UserInput == "1") return actions.AttackAction();
            if (UserInput == "2") return actions.RunAction();
            if (UserInput == "3") return actions.TalkAction();
            else
            {
                Console.Clear();
                GetEncounterOtpions();
                return false;
            }

        }

        public void runNewEncounter()
        {
            Console.Clear();
            Enemy.ResetAttributes();
            GenerateEncounter();
            do
            {
                PrintEncounter();
                continueEncounter = GetEncounterOtpions();
            } while (continueEncounter);
        }
    }
}