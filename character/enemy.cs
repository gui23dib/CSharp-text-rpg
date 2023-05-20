using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace heros_journey_text_RPG.character
{
    public class Enemy : Character
    {
        static public int enemies_defetead { private set; get; }

        public Enemy()
        {
            enemies_defetead = 0;
            base.att = new Attributes();
        }


        public int? npcId { set; get; }

        public void checkDefeatedEnemiesInteraction()
        {
            if(enemies_defetead % 10 == 0)
            {
                //LEVEL UP INTERACTION
                if(enemies_defetead % 50 == 0)
                {
                    //BOSS BATTLE
                }
            }
        }
        public void ResetAttributes()
        {
            att.str = constants.BaseAttNum;
            att.dex = constants.BaseAttNum;
            att.cons = constants.BaseAttNum;
            att.cha = constants.BaseAttNum;
        }

        public void PrintEnemyMainStats()
        {

            Console.WriteLine("{0} - {1}", name, char_class);
        }

        public bool IsEnemyDefeated()
        {
            if (att.IsAnyAttributeEmpty())
            {
                enemies_defetead++;
                return true;
            }
            return false;
        }

    }
}
