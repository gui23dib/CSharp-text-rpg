using System;
using System.Reflection.PortableExecutable;
using heros_journey_text_RPG.character;
using heros_journey_text_RPG.encounters;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            hero.InitHeroCharacter();

            Encounter encounter = new Encounter(hero);
            while (true) { 
                encounter.runNewEncounter();
                Console.ReadLine();
            }
        }
    }
}
