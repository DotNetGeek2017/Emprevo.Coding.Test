using Emprevo.Coding.Test.Interface;

namespace Emprevo.Coding.Test.Rates
{
    public class StandardRate : IStandardRate
    {
        public string Name { get => "Standard Rate"; }
        public RateType Type { get => RateType.HourlyRate; }
        public decimal Price => 5.00m;
        public decimal MaxRate => 20.00m;

        public decimal TotalPrice(double minutes)
        {
            if (minutes>0 && minutes <= 60) return Price;

            if (minutes > 60 && minutes <= 120) return Price * 2;

            if (minutes > 120 && minutes <= 180) return Price * 3;

            if (minutes > 180) return MaxRate;

            return 0.00m;
         }
    }
}
