using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Dre0Dru.GameGrids.Pathfinding
{
    public class AStarPathfinding2DJobs<TGridObject> : IGameGrid2DPathfinding<TGridObject>
        where TGridObject : IAStarPathfindingNode<TGridObject>
    {
        private readonly IGameGrid2D<TGridObject> _gameGrid2D;
        private readonly bool _allowDiagonalMovement;
        private NativeList<int2> _jobOutput;

        public AStarPathfinding2DJobs(IGameGrid2D<TGridObject> gameGrid2D, bool allowDiagonalMovement)
        {
            _allowDiagonalMovement = allowDiagonalMovement;
            _gameGrid2D = gameGrid2D;
            _jobOutput = new NativeList<int2>(Allocator.Persistent);
        }

        public bool TryFindPath(Vector2Int startGridPos, Vector2Int endGridPos, List<GridPositionedObject<TGridObject>> path)
        {
            _jobOutput.Clear();
            
            var passable = new NativeArray<bool>(_gameGrid2D.GridSize.x * _gameGrid2D.GridSize.y, Allocator.TempJob);

            for (int i = 0; i < passable.Length; i++)
            {
                var y = i / _gameGrid2D.GridSize.y;
                var x = i - y * _gameGrid2D.GridSize.y;
                var gridPos = new Vector2Int(x, y);

                passable[i] = _gameGrid2D.GetGridObject(gridPos).IsPassable;
            }
            
            var job = new FindPathJob()
            {
                Path = _jobOutput,
                Passable = passable,
                StartNodePos = new int2(startGridPos.x, startGridPos.y),
                EndNodePos = new int2(endGridPos.x, endGridPos.y),
                GridSize = new int2(_gameGrid2D.GridSize.x, _gameGrid2D.GridSize.y),
                AllowDiagonalMovement = _allowDiagonalMovement,
            };
            
            job.Run();

            passable.Dispose();
            
            if (_jobOutput.Length == 0)
            {
                return false;
            }
            
            foreach (var pathGridPos in _jobOutput)
            {
                var gridPos = new Vector2Int(pathGridPos.x, pathGridPos.y);
                
                path.Add(_gameGrid2D.GetGridPositionedObject(gridPos));
            }
            
            path.Reverse();

            return true;
        }
    }
}
