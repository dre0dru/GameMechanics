using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.GameGrids.Pathfinding
{
    public interface IGameGrid2DPathfinding<TGridObject>
    {
        bool FindPath(Vector2Int startGridPos, Vector2Int endGridPos, List<GridPositionedObject<TGridObject>> path);
    }
}
