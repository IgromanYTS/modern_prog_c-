using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calc.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void expression_sum2and2_returned_PostfixForm_plus()
        {
            string expression = "2+2";
            string expected = "2 2 +";
            string result = Program.InfixToPostfix(expression);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void expression_sum2and2_returned_PostfixForm_multiply()
        {
            string expression = "2*2";
            string expected = "2 2 *";
            string result = Program.InfixToPostfix(expression);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void expression_sum2and2_returned4()
        {
            string expression = "2*2";
            int expected = 4;
            int result = Program.Evaluate(Program.InfixToPostfix(expression));
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void expression_brack_sum2and2_brack_andmultiply_returned8()
        {
            string expression = "(2+2)*2";
            int expected = 8;
            int result = Program.Evaluate(Program.InfixToPostfix(expression));
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void expression_sum2and2_andmultiply_returned6()
        {
            string expression = "2+2*2";
            int expected = 6;
            int result = Program.Evaluate(Program.InfixToPostfix(expression));
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void expression_brack_sum2and2_multiply2_brack_andmultiply_returned12()
        {
            string expression = "(2+2*2)*2";
            int expected = 12;
            int result = Program.Evaluate(Program.InfixToPostfix(expression));
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void expression_brack_sum2and2_brack_andmultiply_returnedERROR()
        {
            string expression = "(2+2)*2";
            int expected = 8;
            int result = Program.Evaluate(Program.InfixToPostfix(expression));
            if (expected != result)
            {
                Assert.Fail();
            }

        }
        [TestMethod]
        public void expression_brack_min2and2_brack_andmultiply2_returned0()
        {
            string expression = "(2-2)*2";
            int expected = 0;
            int result = Program.Evaluate(Program.InfixToPostfix(expression));
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void expression_sum2and3_returnedIsNotNull()
        {
            string expression = "2+3";
            int result = Program.Evaluate(Program.InfixToPostfix(expression));
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void expression_sum2and3_returnedAreNotEqual()
        {
            string expression = "2+3";
            int test = 3;
            int result = Program.Evaluate(Program.InfixToPostfix(expression));
            Assert.AreNotEqual(test, result);
        }
        [DataTestMethod]
        [DataRow("(2+2)*2", 8)]
        [DataRow("2+2*2", 6)]
        [DataRow("(2+2)", 4)]
        [DataRow("(2+3)*2", 10)]
        [DataRow("(2-2)*2", 0)]
        public void Test(string expression, int expected)
        {
            int result = Program.Evaluate(Program.InfixToPostfix(expression));
            Assert.AreEqual(expected, result);

        }
    }
}