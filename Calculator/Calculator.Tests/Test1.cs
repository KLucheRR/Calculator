

namespace Calculator.Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestInitialize]
        public void TestInit()
        {
            // This method is called before each test method.
        }

        [TestMethod]
        public void TestSum()
        {
            double[] args = [5, 6];
            var sum = CalculatorCore.Calculator.Sum(args);
            Assert.AreEqual(11, sum);
            Assert.AreNotEqual(12, sum);
        }

        [TestMethod]
        public void TestSubstract()
        {
            double[] args = [12, 5, 12];
            var substract = CalculatorCore.Calculator.Substract(args);
            Assert.AreEqual(-5, substract);
            Assert.AreNotEqual(0, substract);
        }

        [TestMethod]
        public void TestMultiply()
        {
            double[] args = [2, 5];
            var multiply = CalculatorCore.Calculator.Multiply(args);
            Assert.AreEqual(10, multiply);
            Assert.AreNotEqual(25, multiply);
        }

        [TestMethod]
        public void TestDivide()
        {
            double[] args = [2, 5];
            var divide = CalculatorCore.Calculator.Divide(args);
            Assert.AreEqual(0.4, divide);
            Assert.AreNotEqual(25, divide);
        }

        [TestMethod]
        public void TestZeroDivision()
        {
            try
            {
                double[] args = [2, 0];
                var divide = CalculatorCore.Calculator.Divide(args);               
            }
            catch (Exception ex)
            {
                Assert.AreEqual(CalculatorCore.Calculator.ZERO_DIVISION_EXEPTION, ex.Message);
                return;
            }
            Assert.Fail(CalculatorCore.Calculator.ZERO_DIVISION_EXEPTION);
        }
    }
}
