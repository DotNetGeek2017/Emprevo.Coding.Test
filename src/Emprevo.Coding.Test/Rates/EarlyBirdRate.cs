using Emprevo.Coding.Test.Interface;

namespace Emprevo.Coding.Test.Rates
{
    public class EarlyBirdRate : IRate
    {
        public string Name { get => "Early Bird"; }
        public RateType Type { get => RateType.FlatRate; }
        public decimal Price => 13.00m;
    }
}
