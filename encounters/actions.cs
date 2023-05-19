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
        }

        private int InitiateNewAction(string action, int HeroAtt, int EnemyAtt)
        {
            Console.Clear();
            Console.WriteLine($"RESOLVING {action} ACTION...\n");
            PrintEncounterInterface();
            Console.WriteLine($"============================================================================\n");
            return CompareDieAction(HeroAtt, EnemyAtt);
        }

        private int CompareDieAction(int HeroAtt, int EnemyAtt)
        {
            int EnemyDie = rnd.Next(1, 6);
            int HeroDie = rnd.Next(1, 6);
            Console.WriteLine($"You \"{Hero.name}\" rolled {HeroDie} + {HeroAtt} \t Enemy \"{Enemy.name}\" rolled {EnemyDie} + {EnemyAtt}");
            return (HeroDie + HeroAtt) - (EnemyDie + EnemyAtt);
        }

        private void GetFileInfo(string action, string status)
        {
            Console.WriteLine(Utils.GetRandomFileLine($"..\\..\\..\\files\\actions\\{action.ToLower()}\\{status}.txt"));
            
        }

        public bool AttackAction()
        {
            var die = InitiateNewAction("ATTACK", Hero.att.str, Enemy.att.str);
            if (die > 0)
            {
                GetFileInfo("ATTACK", "good");
                Enemy.att.cons--;
                Enemy.att.str -= Hero.att.str;
            }
            else if (die < 0)
            {
                GetFileInfo("ATTACK", "bad");
                Hero.att.cons--;
                Hero.att.str -= Enemy.att.str;
            }
            else
            {
                GetFileInfo("ATTACK", "neutral");
                Hero.att.str--;
                Enemy.att.str--;
            }
            Console.ReadLine();
            Console.Clear();
            return !Enemy.IsEnemyDefeated();
        }

        public bool RunAction()
        {
            bool isPositiveDie = InitiateNewAction("RUN", Hero.att.dex, Enemy.att.dex) > 0;
            GetFileInfo("RUN", isPositiveDie ? "good" : "bad");
            if (!isPositiveDie) Hero.att.dex--;
            Console.ReadLine();
            Console.Clear();
            return isPositiveDie ? false : true;
        }

        public bool TalkAction()
        {
            var die = InitiateNewAction("TALK", Hero.att.cha, Enemy.att.cha);
            if (die > 0)
            {
                GetFileInfo("TALK", "good");
                Enemy.att.cha--;
            }
            else if (die < 0)
            {
                GetFileInfo("TALK", "bad");
                Hero.att.cha--;
            }
            else
            {
                GetFileInfo("TALK", "neutral");
                Hero.att.cha--;
                Enemy.att.cha--;
            }
            Console.ReadLine();
            Console.Clear();
            return !Enemy.IsEnemyDefeated();
        }
    }
}
