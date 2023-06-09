﻿using System;
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

        public void PrintAttributes(bool list = false)
        {
            Console.WriteLine("{1}<{0}> strength", str, list ? "1 - " : "");
            Console.WriteLine("{1}<{0}> dexterity", dex, list ? "2 - " : "");
            Console.WriteLine("{1}<{0}> constitution", cons, list ? "3 - " : "");
            Console.WriteLine("{1}<{0}> charisma", cha, list ? "4 - " : "");
        }

        public bool UpgradeAtt(string choice, int upgradeNum) 
        {
            switch (choice)
            {
                case "1":
                    str += upgradeNum;
                    break;
                case "2":
                    dex += upgradeNum;
                    break;
                case "3":
                    cons += upgradeNum;
                    break;
                case "4":
                    cha += upgradeNum;
                    break;
                default: return false;
            }
            return true;
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
            str = 6;
            dex = 2;
            cons = 3;
            cha = 1;
        }

        public void DefineRogueClass()
        {
            str = 2;
            dex = 6;
            cons = 1;
            cha = 3;
        }

        public void DefineWarriorClass()
        {
            str = 3;
            dex = 1;
            cons = 6;
            cha = 2;
        }

        public void DefineWizardClass()
        {
            str = 1;
            dex = 3;
            cons = 2;
            cha = 6;
        }
    }
}
