namespace Dre0Dru.GameTime
{
    public interface ITimeControl
    {
        float DeltaTime { get; }
        float TimeScale { get; set; }
    }
}
