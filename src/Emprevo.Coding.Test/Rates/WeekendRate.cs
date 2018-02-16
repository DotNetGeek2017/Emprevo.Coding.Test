using Emprevo.Coding.Test.Interface;

namespace Emprevo.Coding.Test.Rates
{
    public class WeekendRate:IRate
    {
        public string Name { get => "Weekend Rate"; }
        public RateType Type { get => RateType.FlatRate; }
        public decimal Price => 10.00m;
    }
}
