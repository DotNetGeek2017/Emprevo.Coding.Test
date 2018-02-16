using Emprevo.Coding.Test.Rates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emprevo.Coding.Test.UnitTests
{
    [TestClass]
    public class StandardRateTests
    {
        [TestMethod]
        public void Calculate_StandardRate_TotalPrice_Minutes_LessThan180()
        {
            //Arrange
            var standardRate = new StandardRate();
            //Act
            var result=standardRate.TotalPrice(150);
            //Assert
            Assert.AreEqual(result, 15.00m);
        }

        [TestMethod]
        public void Calculate_StandardRate_TotalPrice_Minutes_LessThan60()
        {
            //Arrange
            var standardRate = new StandardRate();
            //Act
            var result = standardRate.TotalPrice(50);
            //Assert
            Assert.AreEqual(result, 5.00m);
        }

        [TestMethod]
        public void Calculate_StandardRate_TotalPrice_Minutes_LessThan120()
        {
            //Arrange
            var standardRate = new StandardRate();
            //Act
            var result = standardRate.TotalPrice(100);
            //Assert
            Assert.AreEqual(result, 10.00m);
        }

        [TestMethod]
        public void Calculate_StandardRate_TotalPrice_Minutes_GreatherThan180()
        {
            //Arrange
            var standardRate = new StandardRate();
            //Act
            var result = standardRate.TotalPrice(200);
            //Assert
            Assert.AreEqual(result, 20.00m);
        }
    }
}
