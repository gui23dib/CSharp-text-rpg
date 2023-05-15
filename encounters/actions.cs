using heros_journey_text_RPG.character;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int CompareDieAction()
        {
            int EnemyDie = rnd.Next(6) + Enemy.att.cha;
            int HeroDie = rnd.Next(6) + Hero.att.cha;
            return HeroDie - EnemyDie;
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
            var t = CompareDieAction();
            if (t >= 0)
            {
                Console.Clear();
                Console.WriteLine($"GANHOU POR {t}");
            } else
            {
                Console.Clear();
                Console.WriteLine($"PERDEU POR {Math.Abs(t)}");
            }
            return false;
        }
    }
}
