using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.GameGrids.Pathfinding
{
    //TODO out TResult, where it can be a list or a struct with job inside
    public interface IGameGrid2DPathfinding<TGridObject>
    {
        bool TryFindPath(Vector2Int startGridPos, Vector2Int endGridPos, List<GridPositionedObject<TGridObject>> path);
    }
}
