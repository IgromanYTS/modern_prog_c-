using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class StrategyMul : Strategy
    {
        public int execute(int a, int b)
        {
            return a * b;
        }
    }
}
