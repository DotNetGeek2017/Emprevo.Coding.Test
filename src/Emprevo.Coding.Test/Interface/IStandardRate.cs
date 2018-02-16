
namespace Emprevo.Coding.Test.Interface
{
    public interface IStandardRate: IRate
    {
        decimal TotalPrice(double minutes);

        decimal MaxRate { get; }
    }
}
