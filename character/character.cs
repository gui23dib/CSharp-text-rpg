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
        public enum Classes { Warrior, Barbarian, Wizard }
        public Classes char_class { set; get; }
        public Attributes att { set; get; } = new Attributes();

    }
}