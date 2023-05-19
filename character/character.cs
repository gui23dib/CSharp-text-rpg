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
    public abstract class Character
    {

        public string name { set; get; }

        public Classes char_class { set; get; }
        public enum Classes { Warrior, Barbarian, Wizard, Rogue }
        public Attributes att { set; get; } = new Attributes();

        public bool DefineClass(string n)
        {
            switch (n)
            {
                case "1":
                    char_class = Classes.Wizard;
                    att.DefineWizardClass();
                    return true;
                case "2":
                    char_class = Classes.Warrior;
                    att.DefineWarriorClass();
                    return true;
                case "3":
                    char_class = Classes.Barbarian;
                    att.DefineBarbarianClass();
                    return true;
                case "4":
                    char_class = Classes.Rogue;
                    att.DefineRogueClass();
                    return true;
                default: return false;
            }

        }
    }
}