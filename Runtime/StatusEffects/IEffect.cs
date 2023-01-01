namespace Dre0Dru.StatusEffects
{
    public interface IEffect<in TTarget>
    {
        void Apply(TTarget target);
    }

    public interface ICancellableEffect
    {
        void Cancel();
    }

    public interface ITickEffect<in TDelta>
    {
        bool IsEnded { get; }

        void Tick(TDelta deltaTime);
    }

    public interface IRenewableEffect
    {
        void Renew();
    }
}
