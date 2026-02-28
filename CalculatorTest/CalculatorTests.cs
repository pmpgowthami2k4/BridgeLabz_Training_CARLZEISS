//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using CalculatorApp;
//namespace CalculatorTest
//{
//    [TestClass]
//    public class CalculatorTests
//    {
//        [TestMethod]
//        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
//        {
//            // Arrange
//            var calculator = new Calculator();   

//            // Act
//            int result = calculator.Add(10, 5);

//            // Assert
//            Assert.AreEqual(15, result);
//        }


//        [TestMethod]
//        public void Subtract_ValidInputs_ReturnsCorrectDifference()
//        {
//            var calculator = new Calculator();
//            int result = calculator.Subtract(10, 4);
//            Assert.AreEqual(6, result);
//        }

//        [TestMethod]
//        public void Subtract_WhenALessThanB_ThrowsArgumentException()
//        {
//            var calculator = new Calculator();

//            Assert.ThrowsException<ArgumentException>(() =>
//                calculator.Subtract(2, 5));
//        }

//        [TestMethod]
        
//        public void Divide_ByZero_ThrowsDivideByZeroException()
//        {
//            var calculator = new Calculator();

//            var ex = Assert.ThrowsException<DivideByZeroException>(() =>
//                //calculator.Divide(10, 0));

//            Assert.AreEqual("Denominator cannot be zero", ex.Message);
//        }
//    }
//}