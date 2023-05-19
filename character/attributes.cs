using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heros_journey_text_RPG.character
{
    public class Attributes
    {
        public int dex { set; get; } //dexterity
        public int str { set; get; } //strentgh
        public int cons { set; get; } //constitution
        public int cha { set; get; } //charisma

        public Attributes()
        {
            str = constants.BaseAttNum;
            dex = constants.BaseAttNum;
            cons = constants.BaseAttNum;
            cha = constants.BaseAttNum;
        }

        public void PrintAttributes()
        {
            Console.WriteLine("<{0}> strength", str);
            Console.WriteLine("<{0}> dexterity", dex);
            Console.WriteLine("<{0}> constitution", cons);
            Console.WriteLine("<{0}> charisma", cha);
        }

        public bool IsAnyAttributeEmpty()
        {
            if (str <= 0) return true;
            if (dex <= 0) return true;
            if (cons <= 0) return true;
            if (cha <= 0) return true;
            return false;
        }

        public void DefineBarbarianClass()
        {
            str = 10;
            dex = 3;
            cons = 5;
            cha = 2;
        }

        public void DefineWarriorClass()
        {
            str = 5;
            dex = 7;
            cons = 3;
            cha = 5;
        }

        public void DefineWizardClass()
        {
            str = 2;
            dex = 5;
            cons = 3;
            cha = 10;
        }
    }
}
