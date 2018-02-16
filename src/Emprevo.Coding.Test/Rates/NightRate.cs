using Emprevo.Coding.Test.Interface;

namespace Emprevo.Coding.Test.Rates
{
    public class NightRate:IRate
    {
        public string Name { get => "Night Rate"; }
        public RateType Type { get => RateType.FlatRate; }
        public decimal Price => 6.50m;
    }
}
