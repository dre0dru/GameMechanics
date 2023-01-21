using System;

namespace Dre0Dru.GameGrids.Pathfinding
{
    public interface IAStarPathfindingNode<TGridObject>
        where TGridObject : IAStarPathfindingNode<TGridObject>
    {
        float Cost { get; set; }
        //TODO don't store, calculate?
        float Heuristic { get; set; }
        bool IsPassable { get; set; }
        GridPositionedObject<TGridObject> Previous { get; set; }
        public float TotalCost => Cost + Heuristic;
    }
    
    public class SimpleAStarPathfindingNode<TGridObject> : IAStarPathfindingNode<TGridObject>
        where TGridObject : IAStarPathfindingNode<TGridObject>
    {
        public float Cost { get; set; }

        public float Heuristic { get; set; }
        
        public bool IsPassable { get; set; }

        public GridPositionedObject<TGridObject> Previous { get; set; }

        public float TotalCost => Cost + Heuristic;
    }
}
