using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace Testing
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Add(10, 5);

            // Assert
            Assert.AreEqual(15, result);
        }
    

    [TestMethod]
        public void Subtract_ValidInputs_ReturnsCorrectDifference()
        {
            var calculator = new Calculator();

            int result = calculator.Subtract(10, 4);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Subtract_WhenALessThanB_ThrowsArgumentException()
        {
            var calculator = new Calculator();

            Assert.Throws<ArgumentException>(() =>
                calculator.Subtract(2, 5));
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            var calculator = new Calculator();

            var ex = Assert.Throws<DivideByZeroException>(() =>
                calculator.Divide(10, 0));

            Assert.AreEqual("Denominator cannot be zero", ex.Message);
        }

        [TestMethod]
        public void Divide_ValidInputs_ReturnsCorrectQuotient()
        {
            var calculator = new Calculator();

            int result = calculator.Divide(10, 2);

            Assert.AreEqual(5, result);
        }

        //DDT
        [TestMethod]
        [DataRow(4, true)]
        [DataRow(5, false)]
        [DataRow(0, true)]
        [DataRow(-2, true)]
        [DataRow(-3, false)]
        public void IsEven_VariousNumbers_ReturnsExpectedResult(int number, bool expected)
        {
            var calculator = new Calculator();

            bool result = calculator.IsEven(number);

            Assert.AreEqual(expected, result);
        }
    }
}