#if ALINE && UNITY_COLLECTIONS
using System;
using System.Diagnostics;
using Drawing;
using Unity.Mathematics;
using UnityEngine;

namespace Dre0Dru.GameGrids
{
    public static class GridDebug
    {
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEBUG")]
        public static void DrawGrid<TGridObject>(this IGameGrid2D<TGridObject> gameGrid2d, Color color)
        {
            Draw.WireGrid(gameGrid2d.Center, Quaternion.identity,
                new int2(gameGrid2d.GridSize.x, gameGrid2d.GridSize.y),
                gameGrid2d.TotalSize(), color);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional("DEBUG")]
        public static void DrawGridPositionText3d<TGridObject>(this IGameGrid2D<TGridObject> gameGrid2d,
            Quaternion rotation, float size, LabelAlignment labelAlignment, Color color)
        {
            gameGrid2d.DrawGridObjectText3d(rotation, size, labelAlignment, color,
                gridPos => gridPos.ToString());
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional("DEBUG")]
        public static void DrawGridObjectText3d<TGridObject>(this IGameGrid2D<TGridObject> gameGrid2d,
            Quaternion rotation, float size, LabelAlignment labelAlignment,
            Color color, Func<Vector2Int, string> gridObjectToStringFunc)
        {
            for (int i = 0; i < gameGrid2d.GridSize.x; i++)
            {
                for (int j = 0; j < gameGrid2d.GridSize.y; j++)
                {
                    var gridPos = new Vector2Int(i, j);

                    var text = gridObjectToStringFunc(gridPos);

                    Draw.Label3D(gameGrid2d.GridToWorldCentered(gridPos),
                        rotation, text, size, labelAlignment, color);
                }
            }
        }
    }
}

#endif
