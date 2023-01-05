using UnityEngine;

namespace Dre0Dru.GameGrids
{
    public static partial class GameGridsExtensions
    {
        public static bool TryRemoveGridObject<TGridObject>(this IGameGrid2D<TGridObject> gameGrid2D,
            Vector2Int gridPos, out TGridObject removedObject)
        {
            if (gameGrid2D.HasGridObject(gridPos))
            {
                removedObject = gameGrid2D.GetGridObject(gridPos);
                gameGrid2D.RemoveGridObject(gridPos);

                return true;
            }

            removedObject = default;
            return false;
        }
        
        public static bool TryGetGridObject<TGridObject>(this IGameGrid2D<TGridObject> gameGrid2D,
            Vector2Int gridPos, out TGridObject gridObject)
        {
            if (gameGrid2D.HasGridObject(gridPos))
            {
                gridObject = gameGrid2D.GetGridObject(gridPos);

                return true;
            }

            gridObject = default;
            return false;
        }

        public static Vector2 TotalSize<TGridObject>(this IGameGrid2D<TGridObject> gameGrid2D) =>
            new Vector2(gameGrid2D.GridSize.x, gameGrid2D.GridSize.y) * gameGrid2D.CellSize;
    }
}
