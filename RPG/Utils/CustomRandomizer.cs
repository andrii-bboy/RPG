using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Utils
{
    
    public class CustomRandomizer
    {
        static Random random = new Random();
        public static int generateNumber (int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}
