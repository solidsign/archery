using UnityEngine;

namespace MyLibs.Movement
{
    public readonly struct Position
    {
        public readonly Vector3 Value;
        
        public Position(Vector3 value)
        {
            Value = value;
        }
        
        public static Position operator +(Position left, Position right)
        {
            return new Position(left.Value + right.Value);
        }
        
        public static Position operator -(Position left, Position right)
        {
            return new Position(left.Value - right.Value);
        }
        
        public static Position operator +(Vector3 left, Position right)
        {
            return new Position(left + right.Value);
        }
        
        public static Position operator -(Vector3 left, Position right)
        {
            return new Position(left - right.Value);
        }
        
        public static Position operator +(Position left, Vector3 right)
        {
            return new Position(left.Value + right);
        }
        
        public static Position operator -(Position left, Vector3 right)
        {
            return new Position(left.Value - right);
        }
        
        public static Position operator *(Position left, float right)
        {
            return new Position(left.Value * right);
        }
        
        public static Position operator *(float left, Position right)
        {
            return new Position(left * right.Value);
        }
        
        public static Position operator *(Position left, int right)
        {
            return new Position(left.Value * right);
        }
        
        public static Position operator *(int left, Position right)
        {
            return new Position(left * right.Value);
        }
        
        public static Position operator /(Position left, float right)
        {
            return new Position(left.Value / right);
        }
        
        public static Position operator /(Position left, int right)
        {
            return new Position(left.Value / right);
        }
        
        public static implicit operator Vector3(Position Position) => Position.Value;
    }
}