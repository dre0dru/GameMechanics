using System;
using UnityEngine;

namespace Dre0Dru.GameGrids
{
    public static partial class GameGridsExtensions
    {
        public static bool TryRemoveGridObject<TGridObject>(this IGameGrid2D<TGridObject> gameGrid2D,
            Vector2Int gridPos, out TGridObject removedObject)
        {
            if (gameGrid2D.IsGridPositionValid(gridPos) && gameGrid2D.HasGridObject(gridPos))
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
            if (gameGrid2D.IsGridPositionValid(gridPos) && gameGrid2D.HasGridObject(gridPos))
            {
                gridObject = gameGrid2D.GetGridObject(gridPos);

                return true;
            }

            gridObject = default;
            return false;
        }

        public static Vector2 TotalSize<TGridObject>(this IGameGrid2D<TGridObject> gameGrid2D) =>
            new Vector2(gameGrid2D.GridSize.x, gameGrid2D.GridSize.y) * gameGrid2D.CellSize;

        public static TGridObject GetOrCreateGridObject<TGridObject>(this IGameGrid2D<TGridObject> gameGrid2D,
            Vector2Int gridPos)
            where TGridObject : new()
        {
            if (!gameGrid2D.TryGetGridObject(gridPos, out var gridObject))
            {
                gridObject = new TGridObject();
                gameGrid2D.SetGridObject(gridPos, gridObject);
            }

            return gridObject;
        }

        public static void FillWith<TGridObject> (this IGameGrid2D<TGridObject> gameGrid2D, Func<TGridObject> createFunc)
        {
            foreach (var gridPosObject in gameGrid2D)
            {
                gameGrid2D.SetGridObject(gridPosObject, createFunc());
            }
        }
        
        public static GridPositionedObject<TGridObject> GetGridPositionedObject<TGridObject>(
            this IGameGrid2D<TGridObject> gameGrid2D, Vector2Int gridPos)
        {
            var gridObject = gameGrid2D.GetGridObject(gridPos);

            return new GridPositionedObject<TGridObject>()
            {
                GridObject = gridObject,
                GridPosition = gridPos
            };
        }

        public static bool TryGetGridPositionedObject<TGridObject>(
            this IGameGrid2D<TGridObject> gameGrid2D, Vector2Int gridPos,
            out GridPositionedObject<TGridObject> gridPosObject)
        {
            if (gameGrid2D.TryGetGridObject(gridPos, out var gridObject))
            {
                gridPosObject = new GridPositionedObject<TGridObject>()
                {
                    GridObject = gridObject,
                    GridPosition = gridPos
                };
                return true;
            }

            gridPosObject = default;
            return false;
        }

        public static bool HasGridObject<TGridObject>(this GridPositionedObject<TGridObject> gridPosObject) =>
            gridPosObject.GridObject != null;

        public static bool TryGetGridObject<TGridObject>(this GridPositionedObject<TGridObject> gridPosObject, 
            out TGridObject gridObject)
        {
            gridObject = gridPosObject.GridObject;

            return gridPosObject.HasGridObject();
        }
    }
}
