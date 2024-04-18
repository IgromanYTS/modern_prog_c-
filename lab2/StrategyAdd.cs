using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class StrategyAdd : Strategy
    {
        public int execute(int a, int b)
        {
            return a + b;
        }
    }
}
