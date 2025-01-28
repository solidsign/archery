using UnityEngine;

namespace Archery.Character
{
    public readonly struct SurfaceCollision
    {
        public readonly Vector3 SurfaceNormal;
        public readonly float SlideAccelerationCoef;
        public readonly Vector3 CollisionPoint;
        public readonly ProjectileInfo? ProjectileInfo;

        public SurfaceCollision(Vector3 surfaceNormal, float slideAccelerationCoef, Vector3 collisionPoint, ProjectileInfo? projectileInfo)
        {
            SurfaceNormal = surfaceNormal;
            SlideAccelerationCoef = slideAccelerationCoef;
            CollisionPoint = collisionPoint;
            ProjectileInfo = projectileInfo;
        }
    }

    public struct ProjectileInfo
    {
    }
}