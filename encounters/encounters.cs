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
        string situation { set; get; }
        string location { set; get; }
        Enemy character = new Enemy();

        private Actions actions;

        public Encounter(Hero hero) {
            GenerateEncounter();
            actions = new Actions(hero, character);
        }

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

            Console.Write("Choose your action: ");
            var UserInput = Console.ReadLine();
            if (UserInput == "1") actions.AttackAction();
            if (UserInput == "2") actions.RunAction();
            if (UserInput == "3") actions.TalkAction();
            else
            {

            }

        }

        public void runNewEncounter()
        {
            Console.Clear();

            GenerateEncounter();
            PrintEncounter();
            GetEncounterOtpions();
        }
    }
}