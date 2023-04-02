using System;
using UnityEngine;

namespace Dre0Dru.SpawnPoints
{
    [Serializable]
    public struct WorldSpawnPoint : ISpawnPoint<WorldPoint>
    {
        [SerializeField]
        private WorldPoint _worldPoint;

        public WorldSpawnPoint(WorldPoint worldPoint)
        {
            _worldPoint = worldPoint;
        }

        public WorldPoint Data => _worldPoint;
    }
    
    [Serializable]
    public struct WorldSpawnPoint<TMetadata> : ISpawnPoint<WorldPoint<TMetadata>>
    {
        [SerializeField]
        private WorldPoint<TMetadata> _worldPoint;

        public WorldSpawnPoint(WorldPoint<TMetadata> worldPoint)
        {
            _worldPoint = worldPoint;
        }

        public WorldPoint<TMetadata> Data => _worldPoint;
    }
}
