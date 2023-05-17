using heros_journey_text_RPG.character;
using heros_journey_text_RPG.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace heros_journey_text_RPG.encounters
{
    public class Actions
    {
        private Random rnd = new Random();
        private Hero Hero { get; set; }
        private Enemy Enemy { get; set; }
        public Actions(Hero hero, Enemy enemy)
        { 
            Enemy = enemy;
            Hero = hero;
        }

        private void PrintEncounterInterface()
        {
            Console.WriteLine("{0} - lvl {1} {2} \t\t {3} - {4}", Hero.name, Hero.level, Hero.char_class, Enemy.name, Enemy.char_class);
            Console.WriteLine("HP: {0} \t EXP: {1} \t\t HP: {2}", Hero.health_points, Hero.exp_points, Enemy.health_points);
        }

        private void InitiateNewAction(string action)
        {
            Console.Clear();
            Console.WriteLine($"RESOLVING {action} ACTION...\n");
            PrintEncounterInterface();
            Console.WriteLine($"============================================================================\n\n");

        }

        private int CompareDieAction()
        {
            int EnemyDie = rnd.Next(1, 6);
            int HeroDie = rnd.Next(1, 6);
            Console.WriteLine($"You \"{Hero.name}\" rolled {HeroDie} + {Hero.att.cha} \t Enemy \"{Enemy.name}\" rolled {EnemyDie} + {Enemy.att.cha}");
            return (HeroDie + Hero.att.cha) - (EnemyDie + Enemy.att.cha);
        }

        private void GetFileInfo(string action, string status)
        {
            Console.WriteLine(Utils.GetRandomFileLine($"..\\..\\..\\files\\actions\\{action.ToLower()}\\{status}.txt"));
            
        }

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
            InitiateNewAction("TALK");
            var die = CompareDieAction();
            if (die > 0) GetFileInfo("TALK", "good");
            else if (die < 0) GetFileInfo("TALK", "bad");
            else GetFileInfo("TALK", "neutral");

            return false;
        }
    }
}
