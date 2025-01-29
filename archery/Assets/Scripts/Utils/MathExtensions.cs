using UnityEngine;

namespace Archery.Utils
{
    public static class MathConstants
    {
        public static readonly Vector3 GroundNormal = Vector3.up;
    }
    
    public static class MathExtensions
    {
        public static float Abs(this float self) => Mathf.Abs(self);
        public static Vector3 ProjectOnGround(this Vector3 self) => Vector3.ProjectOnPlane(self, Vector3.up);
        public static float GetAngleWithGround(this Vector3 self) => Vector3.Angle(Vector3.up, self);
    }
}