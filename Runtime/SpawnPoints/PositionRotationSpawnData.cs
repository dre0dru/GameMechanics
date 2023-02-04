using System;
using UnityEngine;

namespace Dre0Dru.SpawnPoints
{
    [Serializable]
    public struct PositionRotationSpawnData
    {
        public Vector3 Position;
        public Quaternion Rotation;

        public static implicit operator PositionRotationSpawnData(Transform transform)
        {
            return new PositionRotationSpawnData()
            {
                Position = transform.position,
                Rotation = transform.rotation
            };
        }
    }
}
