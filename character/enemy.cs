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
        static private int enemies_defetead;

        public Enemy()
        {
            base.action_points = 1;
            base.health_points = 10;
            base.att = new Attributes();
        }

        public int? npcId { set; get; }

        public void ResetAttributes()
        {
            att.cha = constants.BaseAttNum;
            att.str = constants.BaseAttNum;
            att.dex = constants.BaseAttNum;
            att.cons = constants.BaseAttNum;
            att.cha = constants.BaseAttNum;
            att.inte = constants.BaseAttNum;
        }

        public void PrintEnemyMainStats()
        {

            Console.WriteLine("{0} - {1}", name, char_class);
            Console.WriteLine("HP: {0}", health_points);
        }

        public bool IsEnemyDefeated()
        {
            if (att.IsAnyAttributeEmpty()) return true;
            if(health_points == 0) return false;
            return false;
        }

    }
}
