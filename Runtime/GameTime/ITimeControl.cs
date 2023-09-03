namespace Dre0Dru.GameTime
{
    public interface IGameTime
    {
        float DeltaTime { get; }
        float DeltaTimeUnscaled { get; }
        float TimeScale { get; }
    }
    
    public interface ITimeControl : IGameTime
    {
        void SetTimeScale(float timeScale);
    }
}
