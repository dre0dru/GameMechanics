using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.GameGrids
{
    public static partial class GameGridsExtensions
    {
        public static void AddToList<TGridObject>(this IGameGrid2D<List<TGridObject>> gameGrid2D,
            Vector2Int gridPos, TGridObject gridObject)
        {
            var gridObjects = gameGrid2D.GetOrCreateGridObject(gridPos);

            gridObjects.Add(gridObject);
        }

        public static bool RemoveFromList<TGridObject>(this IGameGrid2D<List<TGridObject>> gameGrid2D,
            Vector2Int gridPos, TGridObject gridObject)
        {
            var gridObjects = gameGrid2D.GetOrCreateGridObject(gridPos);

            return gridObjects.Remove(gridObject);
        }

        public static bool ContainsInList<TGridObject>(this IGameGrid2D<List<TGridObject>> gameGrid2D,
            Vector2Int gridPos, TGridObject gridObject)
        {
            var gridObjects = gameGrid2D.GetOrCreateGridObject(gridPos);

            return gridObjects.Contains(gridObject);
        }

        public static int CountInList<TGridObject>(this IGameGrid2D<List<TGridObject>> gameGrid2D,
            Vector2Int gridPos)
        {
            var gridObjects = gameGrid2D.GetOrCreateGridObject(gridPos);

            return gridObjects.Count;
        }
    }
}
