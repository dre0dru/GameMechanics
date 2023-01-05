using UnityEngine;

namespace Dre0Dru.GameGrids
{
    //TODO spawner extensions to spawn on grid
    //TODO hexagonal grid
    public interface IGameGrid2D<TGridObject>
    {
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
    }
}
