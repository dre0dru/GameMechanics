using System;
using UnityEngine;

namespace Dre0Dru.GameGrids
{
    [Serializable]
    public struct GameGridSettings
    {
        public float CellSize;

        public Vector2Int GridSize;

        public Vector3 Origin;
    }
}
