using System;

namespace Dre0Dru.GameGrids.Pathfinding
{
    public class DelegateAStarHeuristic<TGridObject> : IAStarHeuristic<TGridObject>
        where TGridObject : IAStarPathfindingNode<TGridObject>
    {
        private readonly Func<GridPositionedObject<TGridObject>, 
            GridPositionedObject<TGridObject>, float> _heuristic;

        public DelegateAStarHeuristic(Func<GridPositionedObject<TGridObject>, 
            GridPositionedObject<TGridObject>, float> heuristic)
        {
            _heuristic = heuristic;
        }

        public float Calculate(GridPositionedObject<TGridObject> from, GridPositionedObject<TGridObject> to) =>
            _heuristic(from, to);
    }
}
