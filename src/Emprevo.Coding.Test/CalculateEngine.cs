using System;
using Emprevo.Coding.Test.Interface;
using Emprevo.Coding.Test.Rates;

namespace Emprevo.Coding.Test
{
    public class CarParkCalculateEngine : ICarParkCalculateEngine
    {
        public CarParkingFeeDetails GetCarParkingPriceDetails(DateTime EntryDateTime, DateTime ExitDateTime)
        {
            //Early bird rate
            //Entry: 6-9Am
            //Exit: 330-1130PM
            if ((EntryDateTime.TimeOfDay.TotalMinutes >= 360 && EntryDateTime.TimeOfDay.TotalMinutes <= 540) && (ExitDateTime.TimeOfDay.TotalMinutes >= 930 && ExitDateTime.TimeOfDay.TotalMinutes <= 1410))
                return new CarParkingFeeDetails { Rate = new EarlyBirdRate() };

            //Night rate
            //Entry: 6-12PM
            //Exit: 6AM Next day
            if ((EntryDateTime.TimeOfDay.TotalMinutes >= 1080 && EntryDateTime.TimeOfDay.TotalMinutes <= 1440 && (EntryDateTime.DayOfWeek != DayOfWeek.Saturday || EntryDateTime.DayOfWeek != DayOfWeek.Sunday)) && (ExitDateTime.TimeOfDay.TotalMinutes <= 360 && ExitDateTime.Day == EntryDateTime.Day + 1))
                return new CarParkingFeeDetails { Rate = new NightRate() };

            //Weekend rate
            //Entry: Anytime after Friday Midnight
            //Exit: Anytime before Sunday Midnight
            if ((EntryDateTime.TimeOfDay.TotalMinutes>=1 && (EntryDateTime.DayOfWeek==DayOfWeek.Saturday || EntryDateTime.DayOfWeek == DayOfWeek.Sunday)) && (ExitDateTime.TimeOfDay.TotalMinutes<=1440 && (ExitDateTime.DayOfWeek == DayOfWeek.Sunday || ExitDateTime.DayOfWeek == DayOfWeek.Saturday)))
                return new CarParkingFeeDetails { Rate = new WeekendRate() };

            var totalMinutes = ExitDateTime.TimeOfDay.TotalMinutes - EntryDateTime.TimeOfDay.TotalMinutes;
            var standardRate = new StandardRate();

            return new CarParkingFeeDetails { Rate = standardRate, TotalParkingFee = standardRate.TotalPrice(totalMinutes) };
        }
    }
}

