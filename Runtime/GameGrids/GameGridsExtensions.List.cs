using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.GameGrids
{
    public static partial class GameGridsExtensions
    {
        public static List<TGridObject> GetOrCreateList<TGridObject>(
            this IGameGrid2D<List<TGridObject>> gameGrid2D, Vector2Int gridPos)
        {
            if (!gameGrid2D.TryGetGridObject(gridPos, out var gridObjects))
            {
                gridObjects = new List<TGridObject>();
                gameGrid2D.SetGridObject(gridPos, gridObjects);
            }

            return gridObjects;
        }

        public static void AddToList<TGridObject>(this IGameGrid2D<List<TGridObject>> gameGrid2D,
            Vector2Int gridPos, TGridObject gridObject)
        {
            var gridObjects = gameGrid2D.GetOrCreateList(gridPos);

            gridObjects.Add(gridObject);
        }

        public static bool RemoveFromList<TGridObject>(this IGameGrid2D<List<TGridObject>> gameGrid2D,
            Vector2Int gridPos, TGridObject gridObject)
        {
            var gridObjects = gameGrid2D.GetOrCreateList(gridPos);

            return gridObjects.Remove(gridObject);
        }

        public static bool ContainsInList<TGridObject>(this IGameGrid2D<List<TGridObject>> gameGrid2D,
            Vector2Int gridPos, TGridObject gridObject)
        {
            var gridObjects = gameGrid2D.GetOrCreateList(gridPos);

            return gridObjects.Contains(gridObject);
        }

        public static int CountInList<TGridObject>(this IGameGrid2D<List<TGridObject>> gameGrid2D,
            Vector2Int gridPos)
        {
            var gridObjects = gameGrid2D.GetOrCreateList(gridPos);

            return gridObjects.Count;
        }
    }
}
