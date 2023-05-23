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
            Enemy enemy = new Enemy();
            hero.InitHeroCharacter();

            Encounter encounter = new Encounter(hero, enemy);
            while (true) { 
                encounter.runEncounters();
                encounter.checkDefeatedEnemiesInteraction();
            }
        }
    }
}
