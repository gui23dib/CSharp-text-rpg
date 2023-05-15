using heros_journey_text_RPG.encounters;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace heros_journey_text_RPG.character
{
    public abstract class Character { 
    
        public string name { set; get; }
        public int action_points { set; get; }
        public int health_points { set; get; }
        public enum Classes { Warrior, Barbarian, Wizard }
        public Classes char_class { set; get; }
        public Attributes att { set; get; } = new Attributes();

        public double checkClassInteractionsNum(Character entity)
        {
            if (char_class == entity.char_class) return 1;
            try
            {
                if (char_class == entity.char_class--) return 2;
                if (char_class == entity.char_class++) return 0.5;
            } catch(Exception ex)
            {
                return 0;
            }
            return 1;
        }
    }
}