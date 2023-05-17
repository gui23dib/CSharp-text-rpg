using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heros_journey_text_RPG.utils
{
    public static class Utils
    {
        public static string GetRandomFileLine(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            Random rnd = new Random();
            int choosen_line = rnd.Next(1, int.Parse(lines[0]));

            return lines[choosen_line];
        }
    }
}
