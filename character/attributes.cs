using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heros_journey_text_RPG.character
{
    public class Attributes
    {
        public int dex { private set; get; } //dexterity
        public int str { private set; get; } //strentgh
        public int cons { private set; get; } //constitution
        public int wis { private set; get; } //wisdowm
        public int inte { private set; get; } // intelligence
        public int cha { private set; get; } //charisma

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

    }
}
