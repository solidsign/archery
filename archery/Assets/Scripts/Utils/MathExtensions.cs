using Archery.Character.Collisions;
using UnityEngine;

namespace Archery.Utils
{
    public static class MathConstants
    {
        public static readonly Vector3 WorldGroundNormal = Vector3.up;
    }
    
    public static class MathExtensions
    {
        public static float Abs(this float self) => Mathf.Abs(self);
        public static Vector3 ProjectOnWorldGround(this Vector3 self) => Vector3.ProjectOnPlane(self, MathConstants.WorldGroundNormal);
        public static Vector3 ProjectOnWorldUp(this Vector3 self) => Vector3.Project(self, MathConstants.WorldGroundNormal);
        public static Vector3 ProjectOnCurrentGround(this Vector3 self, SurfaceCollision collision)
        {
            return Vector3.ProjectOnPlane(self, collision.SurfaceNormal);
        }

        public static float GetAngleWithWorldGround(this Vector3 self) => Vector3.Angle(MathConstants.WorldGroundNormal, self);
        public static float GetAngleWithCurrentGround(this Vector3 self, SurfaceCollision collision) => Vector3.Angle(collision.SurfaceNormal, self);
    }
}