namespace Dre0Dru.GameGrids.Pathfinding
{
    public interface IAStarHeuristic<TGridObject>
        where TGridObject : IAStarPathfindingNode<TGridObject>
    {
        float Calculate(GridPositionedObject<TGridObject> from,
            GridPositionedObject<TGridObject> to);
    }
}
