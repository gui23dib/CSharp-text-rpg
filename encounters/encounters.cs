using heros_journey_text_RPG.character;
using heros_journey_text_RPG.encounters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heros_journey_text_RPG.encounters
{
    public class Encounter
    {
        string situation;
        string location;
        Character character = new Character();

        private Actions actions = new Actions();

        private void GenerateEncounter()
        {
            situation = GetRandomFileLine("..\\..\\..\\files\\situations.txt");
            location = GetRandomFileLine("..\\..\\..\\files\\locations.txt");
            character.name = GetRandomFileLine("..\\..\\..\\files\\characters.txt");
        }

        private void PrintEncounter()
        {
            string characterPrefix = "aeiouAEIOU".IndexOf(character.name[0]) >= 0 ? "an" : "a";
            Console.WriteLine("You found {0} {1} in {2} {3}\n", characterPrefix, character.name, location, situation);
        }

        private string GetRandomFileLine(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            Random rnd = new Random();
            int choosen_line = rnd.Next(1, int.Parse(lines[0]));

            return lines[choosen_line];
        }

        private void GetEncounterOtpions()
        {
            Console.WriteLine("1 - Attack\n2 - Run\n3 - Talk");

            Dictionary<string, Func<bool>> actionDictionary = new Dictionary<string, Func<bool>>()
            {
                {"1", actions.AttackAction},
                {"2", actions.RunAction},
                {"3", actions.TalkAction},
            };

            Console.Write("Choose your action: ");
            _ = actionDictionary[Console.ReadLine()];
        }

        public void runNewEncounter()
        {
            Console.Clear();

            GenerateEncounter();
            PrintEncounter();
            GetEncounterOtpions();
        }
    }


    public class Actions
    {
        public bool AttackAction()
        {
            return false;
        }

        public bool RunAction()
        {
            return false;
        }

        public bool TalkAction()
        {
            return false;
        }
    }
}