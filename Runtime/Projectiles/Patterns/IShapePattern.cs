namespace Dre0Dru.Projectiles.Patterns
{
    public interface IShapePattern
    {
        int Count { get; }
        float Delay { get; }
    }

    public interface IShapePattern<out TOutput> : IShapePattern
    {
        TOutput CalculateOutput(int index);
    }
}
