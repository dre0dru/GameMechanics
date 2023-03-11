using System;
using UnityEngine;

namespace Dre0Dru.SpawnPoints
{
    [Serializable]
    public struct WorldPoint
    {
        public Vector3 Position;
        public Quaternion Rotation;

        public static implicit operator WorldPoint(Transform transform)
        {
            return new WorldPoint()
            {
                Position = transform.position,
                Rotation = transform.rotation
            };
        }
    }
    
    [Serializable]
    public struct WorldPoint<TMetadata>
    {
        public TMetadata Metadata;
        public WorldPoint Point;
    }
}
