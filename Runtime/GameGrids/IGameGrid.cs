using UnityEngine;

namespace Dre0Dru.GameGrids
{
    //TODO spawner extensions to spawn on grid
    //TODO hexagonal grid
    public interface IGameGrid
    {
        Vector2Int WorldToGrid(Vector3 worldPos);
        Vector3 GridToWorld(Vector2Int gridPos);
        Vector3 GridToWorldCentered(Vector2Int gridPos);
    }
}
