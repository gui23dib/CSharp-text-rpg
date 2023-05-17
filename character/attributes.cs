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
        public int wis { set; get; } //wisdowm
        public int inte { set; get; } // intelligence
        public int cha { set; get; } //charisma

        public Attributes()
        {
            str = constants.BaseAttNum;
            dex = constants.BaseAttNum;
            cons = constants.BaseAttNum;
            cha = constants.BaseAttNum;
            inte = constants.BaseAttNum;
            wis = constants.BaseAttNum;
        }

        public void PrintAttributes()
        {
            Console.WriteLine("<{0}> strength", str);
            Console.WriteLine("<{0}> dexterity", dex);
            Console.WriteLine("<{0}> constitution", cons);
            Console.WriteLine("<{0}> charisma", cha);
            Console.WriteLine("<{0}> intelligence", inte);
            Console.WriteLine("<{0}> wisdom", wis);
        }

        public bool IsAnyAttributeEmpty()
        {
            if (str <= 0) return true;
            if (dex <= 0) return true;
            if (cons <= 0) return true;
            if (cha <= 0) return true;
            if (inte <= 0) return true;
            if (wis <= 0) return true;
            return false;
        }
    }
}
