using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab2.Tests
{
    public class StrategyAddi
    {
        [DataTestMethod]
        [DataRow(2, 2, 4)]
        [DataRow(2, -3, -1)]
        [DataRow(-4, 2, -2)]
        [DataRow(-10, -2, -12)]
        [DataRow(0, int.MaxValue, int.MaxValue)]
        [DataRow(0, int.MinValue, int.MinValue)]

        public void Test1(int a, int b, int expected)
        {
            Context context = new Context();
            context.setStrategy(new StrategyAdd());
            int result = context.executeStrategy(a, b);
            Assert.AreEqual(expected, result);

        }
    }
}
