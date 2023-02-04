using System;
using UnityEngine;

namespace Dre0Dru.SpawnPoints
{
    [Serializable]
    public struct PositionRotationSpawnPoint : ISpawnPoint<PositionRotationSpawnData>
    {
        [SerializeField]
        private PositionRotationSpawnData _positionRotation;

        public PositionRotationSpawnPoint(PositionRotationSpawnData positionRotation)
        {
            _positionRotation = positionRotation;
        }

        public PositionRotationSpawnData Data => _positionRotation;
    }
}
