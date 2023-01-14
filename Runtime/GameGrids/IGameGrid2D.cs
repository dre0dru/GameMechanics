using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.GameGrids
{
    //TODO spawner extensions to spawn on grid
    //TODO hexagonal grid
    public interface IGameGrid2D<TGridObject>
    {
        public struct GridPositionEnumerator : IEnumerator<Vector2Int>
        {
            private readonly Vector2Int _gridSize;
            private int _idx;

            public Vector2Int Current
            {
                get
                {
                    if (_idx == 0)
                    {
                        return Vector2Int.zero;
                    }

                    var y = _idx / _gridSize.y;
                    var x = _idx - y * _gridSize.y;
                    
                    return new Vector2Int(x, y);
                }
            }

            object IEnumerator.Current => Current;
            
            public GridPositionEnumerator(Vector2Int gridSize)
            {
                _gridSize = gridSize;
                _idx = -1;
            }

            public bool MoveNext()
            {
                _idx++;

                return _idx < _gridSize.x * _gridSize.y;
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
