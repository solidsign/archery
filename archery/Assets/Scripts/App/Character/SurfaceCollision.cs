using UnityEngine;

namespace Archery.Character
{
    public readonly struct SurfaceCollision
    {
        public readonly Vector3 SurfaceNormal;
        public readonly float SlideAccelerationCoef;
        public readonly Vector3 CollisionPoint;

        public SurfaceCollision(Vector3 surfaceNormal, float slideAccelerationCoef, Vector3 collisionPoint)
        {
            SurfaceNormal = surfaceNormal;
            SlideAccelerationCoef = slideAccelerationCoef;
            CollisionPoint = collisionPoint;
        }
    }
}