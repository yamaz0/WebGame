using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Domain.Common
{
    static public class Utils
    {
        static public int CalculateExpRequirement(int lvl)
        {
            return lvl * 10;
        }
    }
}
