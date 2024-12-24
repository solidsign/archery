using UnityEngine;

namespace MyLibs.Movement
{
    public readonly struct Acceleration
    {
        public static Acceleration Zero => new Acceleration(Vector3.zero);
        
        public readonly Vector3 Value;

        public Acceleration(Vector3 value)
        {
            Value = value;
        }
        
        public static Acceleration operator +(Acceleration left, Acceleration right)
        {
            return new Acceleration(left.Value + right.Value);
        }
        
        public static Acceleration operator -(Acceleration left, Acceleration right)
        {
            return new Acceleration(left.Value - right.Value);
        }
        
        public static Acceleration operator *(Acceleration left, float right)
        {
            return new Acceleration(left.Value * right);
        }
        
        public static Acceleration operator *(float left, Acceleration right)
        {
            return new Acceleration(left * right.Value);
        }
        
        public static Acceleration operator *(Acceleration left, int right)
        {
            return new Acceleration(left.Value * right);
        }
        
        public static Acceleration operator *(int left, Acceleration right)
        {
            return new Acceleration(left * right.Value);
        }
        
        public static Acceleration operator /(Acceleration left, float right)
        {
            return new Acceleration(left.Value / right);
        }
        
        public static Acceleration operator /(Acceleration left, int right)
        {
            return new Acceleration(left.Value / right);
        }
    }
}