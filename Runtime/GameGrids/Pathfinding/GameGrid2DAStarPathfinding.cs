using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Dre0Dru.GameGrids.Pathfinding
{
    //TODO bursted?
    //TODO since there is no cached data here instances can be created on demand
    //TODO or binded for diff pathfinding options
    public class GameGrid2DAStarPathfinding<TGridObject> : IGameGrid2DPathfinding<TGridObject>
        where TGridObject : IAStarPathfindingNode<TGridObject>
    {
        private static readonly Comparison<GridPositionedObject<TGridObject>> Comparison = (x, y) =>
            x.GridObject.TotalCost.CompareTo(y.GridObject.TotalCost);

        private readonly IGameGrid2D<TGridObject> _gameGrid2D;
        private readonly IAStarHeuristic<TGridObject> _heuristic;

        public GameGrid2DAStarPathfinding(IGameGrid2D<TGridObject> gameGrid2D, IAStarHeuristic<TGridObject> heuristic)
        {
            _gameGrid2D = gameGrid2D;
            _heuristic = heuristic;
        }

        //TODO refactor, split into smaller methods
        public bool FindPath(Vector2Int startGridPos, Vector2Int endGridPos,
            List<GridPositionedObject<TGridObject>> path)
        {
            using var pooledOpenList =
                CollectionPool<List<GridPositionedObject<TGridObject>>, GridPositionedObject<TGridObject>>.Get(
                    out var openList);

            using var pooledClosedSet =
                CollectionPool<HashSet<GridPositionedObject<TGridObject>>, GridPositionedObject<TGridObject>>.Get(
                    out var closedSet);

            using var pooledNeighbours =
                CollectionPool<List<GridPositionedObject<TGridObject>>, GridPositionedObject<TGridObject>>.Get(
                    out var neighbours);

            var start = _gameGrid2D.GetGridPositionedObject(startGridPos);
            var end = _gameGrid2D.GetGridPositionedObject(endGridPos);

            openList.Add(start);

            foreach (var gridPosition in _gameGrid2D)
            {
                var node = _gameGrid2D.GetGridObject(gridPosition);

                node.Cost = int.MaxValue;
                node.Heuristic = 0;
                node.Previous = default;
            }

            start.GridObject.Cost = 0;
            start.GridObject.Heuristic = CalculateHeuristic(start, end);

            while (openList.Count > 0)
            {
                var current = GetLowestCostNode(openList);

                if (current == end)
                {
                    CalculatePath(current, path);
                    return true;
                }

                openList.Remove(current);
                closedSet.Add(current);

                neighbours.Clear();
                GetNeighbours(current, neighbours);

                foreach (var neighbour in neighbours)
                {
                    if (closedSet.Contains(neighbour) || !neighbour.GridObject.IsPassable)
                    {
                        continue;
                    }

                    var cost = current.GridObject.Cost + CalculateHeuristic(current, neighbour);

                    if (cost < neighbour.GridObject.Cost)
                    {
                        TGridObject neighbourNode = neighbour;
                        neighbourNode.Previous = current;
                        neighbourNode.Cost = cost;
                        neighbourNode.Heuristic = CalculateHeuristic(neighbour, end);

                        if (!openList.Contains(neighbour))
                        {
                            openList.Add(neighbour);
                        }
                    }
                }
            }

            return false;
        }

        private float CalculateHeuristic(GridPositionedObject<TGridObject> from,
            GridPositionedObject<TGridObject> to)
        {
            return _heuristic.Calculate(from, to);
        }

        private GridPositionedObject<TGridObject> GetLowestCostNode(
            List<GridPositionedObject<TGridObject>> pathfindingNodes)
        {
            var lowest = pathfindingNodes[0];

            for (int i = 1; i < pathfindingNodes.Count; i++)
            {
                var current = pathfindingNodes[i];
                if (current.GridObject.TotalCost < lowest.GridObject.TotalCost)
                {
                    lowest = current;
                }
            }

            return lowest;
        }

        private void GetNeighbours(GridPositionedObject<TGridObject> node,
            IList<GridPositionedObject<TGridObject>> neighbours)
        {
            TryAddNeighbour(Vector2Int.up);
            TryAddNeighbour(Vector2Int.down);
            TryAddNeighbour(Vector2Int.right);
            TryAddNeighbour(Vector2Int.left);

            TryAddNeighbour(Vector2Int.up + Vector2Int.right);
            TryAddNeighbour(Vector2Int.down + Vector2Int.right);
            TryAddNeighbour(Vector2Int.up + Vector2Int.left);
            TryAddNeighbour(Vector2Int.down + Vector2Int.left);

            void TryAddNeighbour(Vector2Int offset)
            {
                if (_gameGrid2D.TryGetGridPositionedObject(node.GridPosition + offset, out var gridPosObject))
                {
                    neighbours.Add(gridPosObject);
                }
            }
        }

        private void CalculatePath(GridPositionedObject<TGridObject> to, List<GridPositionedObject<TGridObject>> path)
        {
            path.Add(to);

            var current = to;

            while (current.GridObject.Previous.HasGridObject())
            {
                current = current.GridObject.Previous;

                path.Add(current);
            }

            path.Reverse();
        }
    }
}
