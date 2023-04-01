using heros_journey_text_RPG.character;
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

        public void GenerateEncounter()
        {
            situation = GetRandomFileLine("..\\..\\..\\files\\situations.txt");
            location = GetRandomFileLine("..\\..\\..\\files\\locations.txt");
            character.name = GetRandomFileLine("..\\..\\..\\files\\characters.txt");
        }

        public void PrintEncounter()
        {
            string characterPrefix = "aeiouAEIOU".IndexOf(character.name[0]) >= 0 ? "an" : "a";
            Console.WriteLine("You found {0} {1} in {2} {3}", characterPrefix, character.name, location, situation);
        }

        private string GetRandomFileLine(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            Random rnd = new Random();
            int choosen_line = rnd.Next(1, int.Parse(lines[0]));

            return lines[choosen_line];
        }
    }
}