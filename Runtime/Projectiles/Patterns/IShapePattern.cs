namespace Dre0Dru.Projectiles.Patterns
{
    public interface IShapePattern
    {
        int Count { get; }
        float Delay { get; }

        PatternOutput CalculateOutput(int index);
    }
}
