namespace Dre0Dru.SpawnPoints
{
    public interface ISpawnPoint<out TData>
    {
        TData Data { get; }
    }
}
