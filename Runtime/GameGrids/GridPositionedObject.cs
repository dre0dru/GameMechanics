using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.GameGrids
{
    public struct GridPositionedObject<TGridObject> : IEquatable<GridPositionedObject<TGridObject>>
    {
        public TGridObject GridObject;
        public Vector2Int GridPosition;

        public static implicit operator TGridObject(GridPositionedObject<TGridObject> gridPositionObject)
        {
            return gridPositionObject.GridObject;
        }

        public static implicit operator Vector2Int(GridPositionedObject<TGridObject> gridPositionObject)
        {
            return gridPositionObject.GridPosition;
        }

        public static bool operator ==(GridPositionedObject<TGridObject> left, GridPositionedObject<TGridObject> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(GridPositionedObject<TGridObject> left, GridPositionedObject<TGridObject> right)
        {
            return !left.Equals(right);
        }

        public bool Equals(GridPositionedObject<TGridObject> other)
        {
            return EqualityComparer<TGridObject>.Default.Equals(GridObject, other.GridObject) &&
                   GridPosition.Equals(other.GridPosition);
        }

        public override bool Equals(object obj)
        {
            return obj is GridPositionedObject<TGridObject> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GridObject, GridPosition);
        }
    }
}
