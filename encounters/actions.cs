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
            int EnemyDie = rnd.Next(1, 10);
            int HeroDie = rnd.Next(1, 10);

            int CriticalHitInteractions(int die, string name, int att)
            {
                if (die == 10)
                {
                    Console.WriteLine($"{name} rolled critical! and got double the stats!");
                    return att;
                } else
                {
                    return 0;
                }
            }

            int HeroSum = HeroDie + HeroAtt + CriticalHitInteractions(HeroDie, "You've", HeroAtt);
            int EnemySum = EnemyDie + EnemyAtt + CriticalHitInteractions(EnemyDie, $"The {Enemy.name}", EnemyAtt);

            Console.WriteLine($"You \"{Hero.name}\" rolled {HeroDie} + {HeroAtt} = {HeroSum} \t Enemy \"{Enemy.name}\" rolled {EnemyDie} + {EnemyAtt} = {EnemySum}");
            return (HeroSum) - (EnemySum);
        }

        private void GetFileInfo(string action, string status)
        {
            Console.WriteLine(Utils.GetRandomFileLine($"..\\..\\..\\files\\actions\\{action.ToLower()}\\{status}.txt") + "\n");   
        }

        private void EnemyDebuffMessage(int HeroAtt, int EnemyAtt, string att)
        {
            Console.WriteLine("The enemy lost {0} {2}, it's currently at {1}...", HeroAtt, EnemyAtt, att);
        }
        private void HeroDebuffMessage(int HeroAtt, int EnemyAtt, string att)
        {
            Console.WriteLine("You lost {0} {2}, you're currently at {1}...", HeroAtt, EnemyAtt, att);
        }

        public bool AttackAction()
        {
            var die = InitiateNewAction("ATTACK", Hero.att.str, Enemy.att.str);
            if (die > 0)
            {
                GetFileInfo("ATTACK", "good");
                Enemy.att.cons--;
                Enemy.att.str -= Hero.att.str;
                EnemyDebuffMessage(1, Enemy.att.cons, "constitution");
                EnemyDebuffMessage(Hero.att.str, Enemy.att.str, "strength");
            }
            else if (die < 0)
            {
                GetFileInfo("ATTACK", "bad");
                Hero.att.cons--;
                Hero.att.str -= Enemy.att.str;
                HeroDebuffMessage(1, Hero.att.str, "constitution");
                HeroDebuffMessage(Enemy.att.str, Hero.att.str, "strength");

            }
            else
            {
                GetFileInfo("ATTACK", "neutral");
                Hero.att.str--;
                Enemy.att.str--;
                EnemyDebuffMessage(1, Enemy.att.str, "strength");
                HeroDebuffMessage(1, Hero.att.str, "strength");
            }
            Console.ReadLine();
            Console.Clear();
            return !Enemy.IsEnemyDefeated();
        }

        public bool RunAction()
        {
            bool isPositiveDie = InitiateNewAction("RUN", Hero.att.dex, Enemy.att.dex) > 0;
            GetFileInfo("RUN", isPositiveDie ? "good" : "bad");
            Hero.att.dex--;
            if (isPositiveDie)
            {
                EnemyDebuffMessage(1, Enemy.att.dex, "dexterity");
                HeroDebuffMessage(1, Hero.att.cha, "dexterity");
                //IMPLEMENTAR DADO DE REDUCAO
            }
            Console.ReadLine();
            Console.Clear();
            return isPositiveDie ? !Enemy.IsEnemyDefeated() : true;
        }

        public bool TalkAction()
        {
            var die = InitiateNewAction("TALK", Hero.att.cha, Enemy.att.cha);
            if (die > 0)
            {
                GetFileInfo("TALK", "good");
                Enemy.att.cha--;
                EnemyDebuffMessage(1, Enemy.att.cha, "charisma");
            }
            else if (die < 0)
            {
                GetFileInfo("TALK", "bad");
                Hero.att.cha--;
                HeroDebuffMessage(1, Hero.att.cha, "charisma");
            }
            else
            {
                GetFileInfo("TALK", "neutral");
                Hero.att.cha--;
                Enemy.att.cha--;
                EnemyDebuffMessage(1, Enemy.att.cha, "charisma");
                HeroDebuffMessage(1, Hero.att.cha, "charisma");
            }
            Console.ReadLine();
            Console.Clear();
            return !Enemy.IsEnemyDefeated();
        }
    }
}
