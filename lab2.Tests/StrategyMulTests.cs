using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace lab2.Tests
{
    [TestClass]
    public class UnitTest1
    {
        
        [DataTestMethod]
        [DataRow(2, 2, 4)]
        [DataRow(2, -3, -6)]
        [DataRow(-2, 4, -8)]
        [DataRow(-12, -2, 24)]
        [DataRow(1, int.MaxValue, int.MaxValue)]
        [DataRow(1, int.MinValue, int.MinValue)]
        public void Test3(int a, int b, int expected) 
        {
            Context context = new Context();
            context.setStrategy(new StrategyMul());
            int result = context.executeStrategy(a, b);
            Assert.AreEqual(expected, result);
        }
        
    }
}
