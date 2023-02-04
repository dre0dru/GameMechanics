namespace Dre0Dru.SpawnPoints
{
    public interface ISpawnPoint<out TData>
    {
        TData Data { get; }
    }
    
    public interface ISpawnPoint<out TSpawnedObject, out TData> : ISpawnPoint<TData>
    {
        TSpawnedObject SpawnedObject { get; }
    }
}
