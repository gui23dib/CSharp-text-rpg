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
            Character hero = new Character();
            hero.InitHeroCharacter();

            Encounter encounter = new Encounter();
            encounter.GenerateEncounter();
            encounter.PrintEncounter();

        }
    }
}
