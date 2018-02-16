using Emprevo.Coding.Test.Interface;

namespace Emprevo.Coding.Test
{
    public class CarParkingFeeDetails
    {
        decimal? totalParkingFee = null;
        public IRate Rate { get; set; }
        public decimal TotalParkingFee
        {
            get
            {
                if (totalParkingFee == null)
                    return Rate.Price;

                return totalParkingFee??0.00m;
            }
            set
            {
                this.totalParkingFee = value;
            }
        }
    }
}
