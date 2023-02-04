using System;
using UnityEngine;

namespace Dre0Dru.SpawnPoints
{
    [Serializable]
    public struct PrefabSpawnPoint<TPrefab> : ISpawnPoint<TPrefab, PositionRotationSpawnData>
    {
        [SerializeField]
        private TPrefab _prefab;

        [SerializeField]
        private PositionRotationSpawnData _positionRotation;

        public PrefabSpawnPoint(TPrefab prefab, PositionRotationSpawnData positionRotation)
        {
            _prefab = prefab;
            _positionRotation = positionRotation;
        }

        public TPrefab SpawnedObject => _prefab;
        public PositionRotationSpawnData Data => _positionRotation;

        public static implicit operator PrefabSpawnPoint<TPrefab>(PrefabSpawnPointComponent<TPrefab> spawnPoint)
        {
            return new PrefabSpawnPoint<TPrefab>(spawnPoint.SpawnedObject, spawnPoint.Data);
        }

        public static implicit operator PositionRotationSpawnPoint(PrefabSpawnPoint<TPrefab> spawnPoint)
        {
            return new PositionRotationSpawnPoint(spawnPoint.Data);
        }
    }
}
