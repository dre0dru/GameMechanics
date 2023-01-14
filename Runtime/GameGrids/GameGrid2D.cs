using System;
using System.Collections;
using System.Collections.Generic;
using Dre0Dru.Collections;
using UnityEngine;

namespace Dre0Dru.GameGrids
{
    //TODO grid plane to raycast against
    //TODO GridReference<T> as grid object, but it also has reference to grid itself?
    //TODO and then extensions to work with it instead of separate implementation
    public class GameGrid2D<TGridObject> : IGameGrid2D<TGridObject>
    {
        private readonly GameGridSettings _settings;
        private readonly Vector3 _origin;
        private readonly FlattenedArray<TGridObject> _gridObjects;

        public float CellSize => _settings.CellSize;
        public Vector2Int GridSize => _settings.GridSize;
        public Vector3 Center => Origin + new Vector3(GridSize.x * 0.5f, 0, GridSize.y * 0.5f) * CellSize;
        public Vector3 Origin => _origin;

        public GameGrid2D(GameGridSettings settings, Vector3 origin)
        {
            _settings = settings;
            _origin = origin;
            _gridObjects = new FlattenedArray<TGridObject>(_settings.GridSize.x, _settings.GridSize.y);
        }

        public void SetGridObject(Vector2Int gridPos, TGridObject gridObject)
        {
            _gridObjects[gridPos] = gridObject;
        }

        public TGridObject GetGridObject(Vector2Int gridPos)
        {
            return _gridObjects[gridPos];
        }
        
        public bool RemoveGridObject(Vector2Int gridPos)
        {
            var hasObject = HasGridObject(gridPos);

            _gridObjects[gridPos] = default;
            
            return hasObject;
        }
        
        public bool HasGridObject(Vector2Int gridPos)
        {
            return _gridObjects[gridPos] != null;
        }

        public bool IsGridPositionValid(Vector2Int gridPos)
        {
            return _gridObjects.IsIndexValid(gridPos.x, gridPos.y);
        }
        
        public Vector2Int WorldToGrid(Vector3 worldPos)
        {
            var x = Mathf.FloorToInt((worldPos - Origin).x / _settings.CellSize);
            var y = Mathf.FloorToInt((worldPos - Origin).z / _settings.CellSize);
            return new Vector2Int(x, y);
        }

        public Vector3 GridToWorld(Vector2Int gridPos)
        {
            return new Vector3(gridPos.x, Origin.y, gridPos.y) * _settings.CellSize + Origin;
        }

        public Vector3 GridToWorldCentered(Vector2Int gridPos)
        {
            var halfSize = _settings.CellSize * 0.5f;
            return GridToWorld(gridPos) + new Vector3(halfSize, 0, halfSize);
        }

        public IGameGrid2D<TGridObject>.GridPositionEnumerator GetEnumerator()
        {
            return new IGameGrid2D<TGridObject>.GridPositionEnumerator(GridSize);
        }
    }
}
