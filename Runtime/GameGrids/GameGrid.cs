using System;
using Dre0Dru.Collections;
using UnityEngine;

namespace Dre0Dru.GameGrids
{
    //TODO grid plane to raycast against
    [Serializable]
    public class GameGrid : IGameGrid
    {
        [SerializeField]
        private GameGridSettings _settings;

        [SerializeField]
        private FlattenedArray<int> _array;

        public GameGrid(GameGridSettings settings)
        {
            _settings = settings;
            _array = new FlattenedArray<int>(_settings.GridSize.x, _settings.GridSize.y);
        }

        public Vector2Int WorldToGrid(Vector3 worldPos)
        {
            var x = Mathf.FloorToInt((worldPos - _settings.Origin).x / _settings.CellSize);
            var y = Mathf.FloorToInt((worldPos - _settings.Origin).z / _settings.CellSize);
            return new Vector2Int(x, y);
        }

        public Vector3 GridToWorld(Vector2Int gridPos)
        {
            return new Vector3(gridPos.x, _settings.Origin.y, gridPos.y) * _settings.CellSize + _settings.Origin;
        }

        public Vector3 GridToWorldCentered(Vector2Int gridPos)
        {
            var halfSize = _settings.CellSize * 0.5f;
            return GridToWorld(gridPos) + new Vector3(halfSize, 0, halfSize);
        }
    }
}
