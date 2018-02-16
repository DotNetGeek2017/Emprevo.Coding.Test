using System;

namespace Emprevo.Coding.Test.Interface
{
    public interface IRate
    {
        string Name { get; }
        RateType Type { get; }
        decimal Price { get; }
     }
}
