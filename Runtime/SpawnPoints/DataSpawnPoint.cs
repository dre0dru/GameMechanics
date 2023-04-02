using System;

namespace Dre0Dru.SpawnPoints
{
    [Serializable]
    public struct DataSpawnPoint<TData> : ISpawnPoint<TData>
    {
        public TData _data;

        public DataSpawnPoint(TData data)
        {
            _data = data;
        }

        public TData Data => _data;
        
        public static implicit operator DataSpawnPoint<TData>(DataSpawnPointComponent<TData> spawnPoint)
        {
            return new DataSpawnPoint<TData>(spawnPoint.Data);
        }
    }
}
