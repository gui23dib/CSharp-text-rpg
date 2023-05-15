using System;
using System.Collections.Generic;
using System.Linq;
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
        
    
    }
}
