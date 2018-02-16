using System;
using Emprevo.Coding.Test.Rates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emprevo.Coding.Test.UnitTests
{
    [TestClass]
    public class CalculateEngineTests
    {
        [TestMethod]
        public void CalculateParkingFee_Given_EntryAndExitTime_Should_Return_EarlyBirdRate()
        {
            //Arrange
            var calculateEngine = new CarParkCalculateEngine();

            //17/2/2018 645am
            var entryDateTime = new DateTime(2018, 2, 17, 8, 45, 20, DateTimeKind.Local);

            //17/2/2018 1115pm
            var exitDateTime = new DateTime(2018, 2, 17, 23, 15, 30, DateTimeKind.Local);

            //Act
            var parkingPriceDetails=calculateEngine.GetCarParkingPriceDetails(entryDateTime, exitDateTime);

            //Assert
            Assert.IsNotNull(parkingPriceDetails);
            Assert.IsInstanceOfType(parkingPriceDetails,typeof(CarParkingFeeDetails));
            Assert.IsNotNull(parkingPriceDetails.Rate);
            Assert.IsInstanceOfType(parkingPriceDetails.Rate, typeof(EarlyBirdRate));
            Assert.AreEqual(parkingPriceDetails.TotalParkingFee, 13.00m);
        }

        [TestMethod]
        public void CalculateParkingFee_Given_EntryAndExitTime_Should_Not_Return_EarlyBirdRate()
        {
            //Arrange
            var calculateEngine = new CarParkCalculateEngine();

            //17/2/2018 645am
            var entryDateTime = new DateTime(2018, 2, 16, 6, 45, 20, DateTimeKind.Local);

            //17/2/2018 1131pm
            var exitDateTime = new DateTime(2018, 2, 16, 15, 29, 30, DateTimeKind.Local);

            //Act
            var parkingPriceDetails = calculateEngine.GetCarParkingPriceDetails(entryDateTime, exitDateTime);

            //Assert
            Assert.IsNotNull(parkingPriceDetails);
            Assert.IsInstanceOfType(parkingPriceDetails, typeof(CarParkingFeeDetails));
            Assert.IsNotNull(parkingPriceDetails.Rate);
            Assert.IsNotInstanceOfType(parkingPriceDetails.Rate, typeof(EarlyBirdRate));
            Assert.AreEqual(parkingPriceDetails.TotalParkingFee, 20.00m);
        }

        [TestMethod]
        public void CalculateParkingFee_Given_EntryAndExitTime_Should_Return_NightRate_Scenario1()
        {
            //Arrange
            var calculateEngine = new CarParkCalculateEngine();

            //17/2/2018 645am
            var entryDateTime = new DateTime(2018, 2, 16, 18, 45, 20, DateTimeKind.Local);

            //17/2/2018 1115pm
            var exitDateTime = new DateTime(2018, 2, 17, 5, 59, 30, DateTimeKind.Local);

            //Act
            var parkingPriceDetails = calculateEngine.GetCarParkingPriceDetails(entryDateTime, exitDateTime);

            //Assert
            Assert.IsNotNull(parkingPriceDetails);
            Assert.IsInstanceOfType(parkingPriceDetails, typeof(CarParkingFeeDetails));
            Assert.IsNotNull(parkingPriceDetails.Rate);
            Assert.IsInstanceOfType(parkingPriceDetails.Rate, typeof(NightRate));
            Assert.AreEqual(parkingPriceDetails.TotalParkingFee, 6.50m);
        }

        [TestMethod]
        public void CalculateParkingFee_Given_EntryAndExitTime_Should_Return_NightRate_Scenario2()
        {
            //Arrange
            var calculateEngine = new CarParkCalculateEngine();

            //17/2/2018 645am
            var entryDateTime = new DateTime(2018, 2, 15, 18, 45, 20, DateTimeKind.Local);

            //17/2/2018 1115pm
            var exitDateTime = new DateTime(2018, 2, 16, 5, 59, 30, DateTimeKind.Local);

            //Act
            var parkingPriceDetails = calculateEngine.GetCarParkingPriceDetails(entryDateTime, exitDateTime);

            //Assert
            Assert.IsNotNull(parkingPriceDetails);
            Assert.IsInstanceOfType(parkingPriceDetails, typeof(CarParkingFeeDetails));
            Assert.IsNotNull(parkingPriceDetails.Rate);
            Assert.IsInstanceOfType(parkingPriceDetails.Rate, typeof(NightRate));
            Assert.AreEqual(parkingPriceDetails.TotalParkingFee, 6.50m);
        }

        [TestMethod]
        public void CalculateParkingFee_Given_EntryAndExitTime_Should_Return_WeekendNightRate_Scenario1()
        {
            //Arrange
            var calculateEngine = new CarParkCalculateEngine();

            //17/2/2018 1100AM
            var entryDateTime = new DateTime(2018, 2, 17, 11, 00, 20, DateTimeKind.Local);

            //17/2/2018 1159pm
            var exitDateTime = new DateTime(2018, 2, 17, 23, 59,00, DateTimeKind.Local);

            //Act
            var parkingPriceDetails = calculateEngine.GetCarParkingPriceDetails(entryDateTime, exitDateTime);

            //Assert
            Assert.IsNotNull(parkingPriceDetails);
            Assert.IsInstanceOfType(parkingPriceDetails, typeof(CarParkingFeeDetails));
            Assert.IsNotNull(parkingPriceDetails.Rate);
            Assert.IsInstanceOfType(parkingPriceDetails.Rate, typeof(WeekendRate));
            Assert.AreEqual(parkingPriceDetails.TotalParkingFee, 10.00m);
        }

        [TestMethod]
        public void CalculateParkingFee_Given_EntryAndExitTime_Should_Return_WeekendNightRate_Scenario2()
        {
            //Arrange
            var calculateEngine = new CarParkCalculateEngine();

            //17/2/2018 1100am
            var entryDateTime = new DateTime(2018, 2, 17, 11, 00, 20, DateTimeKind.Local);

            //18/2/2018 1159pm
            var exitDateTime = new DateTime(2018, 2, 18, 23, 59, 00, DateTimeKind.Local);

            //Act
            var parkingPriceDetails = calculateEngine.GetCarParkingPriceDetails(entryDateTime, exitDateTime);

            //Assert
            Assert.IsNotNull(parkingPriceDetails);
            Assert.IsInstanceOfType(parkingPriceDetails, typeof(CarParkingFeeDetails));
            Assert.IsNotNull(parkingPriceDetails.Rate);
            Assert.IsInstanceOfType(parkingPriceDetails.Rate, typeof(WeekendRate));
            Assert.AreEqual(parkingPriceDetails.TotalParkingFee, 10.00m);
        }

        [TestMethod]
        public void CalculateParkingFee_Given_EntryAndExitTime_Should_Return_StandardRate_Scenario1()
        {
            //Arrange
            var calculateEngine = new CarParkCalculateEngine();

            //17/2/2018 1100am
            var entryDateTime = new DateTime(2018, 2, 12, 11, 00, 20, DateTimeKind.Local);

            //18/2/2018 1159pm
            var exitDateTime = new DateTime(2018, 2, 12, 23, 59, 00, DateTimeKind.Local);

            //Act
            var parkingPriceDetails = calculateEngine.GetCarParkingPriceDetails(entryDateTime, exitDateTime);

            //Assert
            Assert.IsNotNull(parkingPriceDetails);
            Assert.IsInstanceOfType(parkingPriceDetails, typeof(CarParkingFeeDetails));
            Assert.IsNotNull(parkingPriceDetails.Rate);
            Assert.IsInstanceOfType(parkingPriceDetails.Rate, typeof(StandardRate));
            Assert.AreEqual(parkingPriceDetails.TotalParkingFee, 20.00m);
        }

        [TestMethod]
        public void CalculateParkingFee_Given_EntryAndExitTime_Should_Return_StandardRate_Scenario2()
        {
            //Arrange
            var calculateEngine = new CarParkCalculateEngine();

            //17/2/2018 1100am
            var entryDateTime = new DateTime(2018, 2, 12, 11, 00, 20, DateTimeKind.Local);

            //18/2/2018 1359pm
            var exitDateTime = new DateTime(2018, 2, 12, 13, 59, 00, DateTimeKind.Local);

            //Act
            var parkingPriceDetails = calculateEngine.GetCarParkingPriceDetails(entryDateTime, exitDateTime);

            //Assert
            Assert.IsNotNull(parkingPriceDetails);
            Assert.IsInstanceOfType(parkingPriceDetails, typeof(CarParkingFeeDetails));
            Assert.IsNotNull(parkingPriceDetails.Rate);
            Assert.IsInstanceOfType(parkingPriceDetails.Rate, typeof(StandardRate));
            Assert.AreEqual(parkingPriceDetails.TotalParkingFee, 15.00m);
        }
    }
}
