using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab2.Tests
{
    class StrategySubs
    {
        [DataTestMethod]
        [DataRow(2, 2, 0)]
        [DataRow(12, -2, 14)]
        [DataRow(-2, 3, -5)]
        [DataRow(-12, -5, -7)]
        [DataRow(0, int.MaxValue, -int.MaxValue)]
        [DataRow(0, int.MinValue, int.MinValue)]
        public void Test2(int a, int b, int expected)
        {
            Context context = new Context();
            context.setStrategy(new StrategySub());
            int result = context.executeStrategy(a, b);
            Assert.AreEqual(expected, result);
        }
    }
}
