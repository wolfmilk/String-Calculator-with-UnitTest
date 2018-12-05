using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1;

namespace UnitTestProject2
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
          StringCalculator calculator= new StringCalculator();
          var result = calculator.Add("");

            Assert.AreEqual(0, result);
        }

       

        [TestMethod]
        public void Add_SingleNumber_ReturnsNumber()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.Add("12,4");

            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void Add_MultipleNumbers_ReturnsSum()

        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.Add("1,2,3");

            Assert.AreEqual(6, result);
           
        }

       
        

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_NegativeValue_ThrowsException()

        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.Add("-1");

            
        }

        [TestMethod]
        public void Add_NumbersLargerThan1000_ReturnsSum()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.Add("2,1001");

            Assert.AreEqual(2, result);
            

    
        }

        

       
       
    }
}
