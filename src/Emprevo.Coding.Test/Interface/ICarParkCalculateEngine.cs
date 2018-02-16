using System;

namespace Emprevo.Coding.Test.Interface
{
    public interface ICarParkCalculateEngine
    {
        CarParkingFeeDetails GetCarParkingPriceDetails (DateTime EntryDateTime, DateTime ExitDateTime);
    }
}
