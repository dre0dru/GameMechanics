using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.GameGrids
{
    //TODO spawner extensions to spawn on grid
    //TODO hexagonal grid
    //TODO varied grid object sizes
    //TODO XY/XZ planes
    public interface IGameGrid2D<TGridObject>
    {
        public struct GridPositionEnumerator : IEnumerator<GridPositionedObject<TGridObject>>
        {
            private readonly IGameGrid2D<TGridObject> _gameGrid;
            private int _idx;

            public GridPositionedObject<TGridObject> Current
            {
                get
                {
                    var y = _idx / _gameGrid.GridSize.y;
                    var x = _idx - y * _gameGrid.GridSize.y;
                    var gridPos = new Vector2Int(x, y);

                    return _gameGrid.GetGridPositionedObject(gridPos);
                }
            }

            object IEnumerator.Current => Current;
            
            public GridPositionEnumerator(IGameGrid2D<TGridObject> gameGrid)
            {
                _gameGrid = gameGrid;
                _idx = -1;
            }

            public bool MoveNext()
            {
                _idx++;

                return _idx < _gameGrid.GridSize.x * _gameGrid.GridSize.y;
            }

            public void Reset()
            {
                _idx = -1;
            }
            
            public void Dispose()
            {
                
            }
        }
        
        float CellSize { get; }
        Vector2Int GridSize { get; }
        Vector3 Center { get; }
        Vector3 Origin { get; }

        Vector2Int WorldToGrid(Vector3 worldPos);
        Vector3 GridToWorld(Vector2Int gridPos);
        Vector3 GridToWorldCentered(Vector2Int gridPos);
        void SetGridObject(Vector2Int gridPos, TGridObject gridObject);
        bool RemoveGridObject(Vector2Int gridPos);
        bool HasGridObject(Vector2Int gridPos);
        bool IsGridPositionValid(Vector2Int gridPos);
        TGridObject GetGridObject(Vector2Int gridPos);
        public GridPositionEnumerator GetEnumerator();
    }
}
