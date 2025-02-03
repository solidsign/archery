using UnityEngine;

namespace Archery.Core
{
    public readonly struct Velocity
    {
        public static Velocity Zero => new Velocity(Vector3.zero);
        
        public readonly Vector3 Value;
        public Velocity(Vector3 value)
        {
            Value = value;
        }
        
        public static Velocity operator +(Velocity left, Velocity right)
        {
            return new Velocity(left.Value + right.Value);
        }
        
        public static Velocity operator -(Velocity left, Velocity right)
        {
            return new Velocity(left.Value - right.Value);
        }
        
        public static Velocity operator +(Vector3 left, Velocity right)
        {
            return new Velocity(left + right.Value);
        }
        
        public static Velocity operator -(Vector3 left, Velocity right)
        {
            return new Velocity(left - right.Value);
        }
        
        public static Velocity operator +(Velocity left, Vector3 right)
        {
            return new Velocity(left.Value + right);
        }
        
        public static Velocity operator -(Velocity left, Vector3 right)
        {
            return new Velocity(left.Value - right);
        }
        
        public static Velocity operator *(Velocity left, float right)
        {
            return new Velocity(left.Value * right);
        }
        
        public static Velocity operator *(float left, Velocity right)
        {
            return new Velocity(left * right.Value);
        }
        
        public static Velocity operator *(Velocity left, int right)
        {
            return new Velocity(left.Value * right);
        }
        
        public static Velocity operator *(int left, Velocity right)
        {
            return new Velocity(left * right.Value);
        }
        
        public static Velocity operator /(Velocity left, float right)
        {
            return new Velocity(left.Value / right);
        }
        
        public static Velocity operator /(Velocity left, int right)
        {
            return new Velocity(left.Value / right);
        }
        
        public static implicit operator Vector3(Velocity velocity) => velocity.Value;
    }
}