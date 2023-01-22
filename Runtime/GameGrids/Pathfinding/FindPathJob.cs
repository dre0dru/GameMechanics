using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Dre0Dru.GameGrids.Pathfinding
{
    //TODO also pass original costs
    [BurstCompile]
    public struct FindPathJob : IJob
    {
        [WriteOnly]
        public NativeList<int2> Path;

        [ReadOnly]
        public NativeArray<bool> Passable;
        
        [ReadOnly]
        public int2 StartNodePos;

        [ReadOnly]
        public int2 EndNodePos;

        [ReadOnly]
        public  int2 GridSize;

        [ReadOnly]
        public bool AllowDiagonalMovement;

        public void Execute()
        {
            var pathNodes = new NativeArray<PathNode>(GridSize.x * GridSize.y, Allocator.Temp);

            for (int x = 0; x < GridSize.x; x++)
            {
                for (int y = 0; y < GridSize.y; y++)
                {
                    var gridPos = new int2(x, y);
                    var idx = CalculateIndex(gridPos);

                    var pathNode = new PathNode()
                    {
                        GridPosition = gridPos,
                        Cost = int.MaxValue,
                        Heuristic = CalculateHeuristic(gridPos, EndNodePos),
                        Index = idx,
                        IsPassable = Passable[idx],
                        PreviousNodeIndex = -1
                    };

                    pathNodes[pathNode.Index] = pathNode;
                }
            }
            
            var startNodeIdx = CalculateIndex(StartNodePos);
            var startNode = pathNodes[startNodeIdx];
            startNode.Cost = 0;
            pathNodes[startNodeIdx] = startNode;

            var endNodeIdx = CalculateIndex(EndNodePos);

            var openList = new NativeList<int>(Allocator.Temp);
            var closedSet = new NativeList<int>(Allocator.Temp);

            var neighbourOffsets = new NativeArray<int2>(AllowDiagonalMovement ? 8 : 4, Allocator.Temp);
            neighbourOffsets[0] = new int2(0, 1);
            neighbourOffsets[1] = new int2(1, 0);
            neighbourOffsets[2] = new int2(0, -1);
            neighbourOffsets[3] = new int2(-1, 0);

            if (AllowDiagonalMovement)
            {
                neighbourOffsets[4] = new int2(1, 1);
                neighbourOffsets[5] = new int2(1, -1);
                neighbourOffsets[6] = new int2(-1, -1);
                neighbourOffsets[7] = new int2(-1, 1);
            }

            openList.Add(startNode.Index);

            while (openList.Length > 0)
            {
                var currentNodeIdx = GetLowestCostNodeIndex(openList, pathNodes);
                var currentNode = pathNodes[currentNodeIdx];

                if (currentNodeIdx == endNodeIdx)
                {
                    break;
                }

                for (int i = 0; i < openList.Length; i++)
                {
                    if (openList[i] == currentNodeIdx)
                    {
                        openList.RemoveAtSwapBack(i);
                        break;
                    }
                }

                closedSet.Add(currentNodeIdx);

                ProcessNeighbours(currentNode, openList, closedSet, pathNodes, neighbourOffsets);
            }

            var endNode = pathNodes[endNodeIdx];

            CalculatePath(endNode, pathNodes);

            openList.Dispose();
            closedSet.Dispose();
            neighbourOffsets.Dispose();
            pathNodes.Dispose();
        }

        //TODO move index calculation to extensions/utils, because it is used everywhere
        private int CalculateIndex(int2 gridPos)
        {
            return gridPos.x + gridPos.y * GridSize.y;
        }

        private float CalculateHeuristic(int2 from, int2 to)
        {
            return math.distancesq(from, to);
        }

        private int GetLowestCostNodeIndex(NativeList<int> openList, NativeArray<PathNode> pathfindingNodes)
        {
            var lowest = pathfindingNodes[openList[0]];

            for (int i = 1; i < openList.Length; i++)
            {
                var current = pathfindingNodes[openList[i]];
                if (current.TotalCost < lowest.TotalCost)
                {
                    lowest = current;
                }
            }

            return lowest.Index;
        }

        private void ProcessNeighbours(PathNode currentNode, NativeList<int> openList, NativeList<int> closedSet,
            NativeArray<PathNode> pathNodes, NativeArray<int2> neighbourOffsets)
        {
            foreach (var offset in neighbourOffsets)
            {
                var neighbourPos = currentNode.GridPosition + offset;

                if (!IsPositionInsideGrid(neighbourPos))
                {
                    return;
                }

                var neighbourIdx = CalculateIndex(neighbourPos);

                if (closedSet.Contains(neighbourIdx))
                {
                    return;
                }

                var neighbourNode = pathNodes[neighbourIdx];

                if (!neighbourNode.IsPassable)
                {
                    continue;
                }

                var cost = currentNode.Cost + CalculateHeuristic(currentNode.GridPosition, neighbourNode.GridPosition);

                if (cost < neighbourNode.Cost)
                {
                    neighbourNode.PreviousNodeIndex = currentNode.Index;
                    neighbourNode.Cost = cost;

                    pathNodes[neighbourIdx] = neighbourNode;

                    if (!openList.Contains(neighbourIdx))
                    {
                        openList.Add(neighbourIdx);
                    }
                }
            }
        }

        private bool IsPositionInsideGrid(int2 gridPos)
        {
            return gridPos.x >= 0 && gridPos.y >= 0 &&
                   gridPos.x < GridSize.x && gridPos.y < GridSize.y;
        }

        private void CalculatePath(PathNode endNode, NativeArray<PathNode> pathNodes)
        {
            if (endNode.PreviousNodeIndex == -1)
            {
                return;
            }

            Path.Add(endNode.GridPosition);

            var currentNode = endNode;

            while (currentNode.PreviousNodeIndex != -1)
            {
                var previous = pathNodes[currentNode.PreviousNodeIndex];

                Path.Add(previous.GridPosition);

                currentNode = previous;
            }
        }

        private struct PathNode
        {
            public int2 GridPosition;
            public int Index;
            public float Cost;
            public float Heuristic;
            public bool IsPassable;
            public float TotalCost => Cost + Heuristic;

            public int PreviousNodeIndex;
        }
    }
    
}
