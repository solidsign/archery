using UnityEngine;

namespace Archery.Character.Collisions
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

        public override string ToString()
        {
            return $"SurfaceNormal: {SurfaceNormal}, SlideAccelerationCoef: {SlideAccelerationCoef}, CollisionPoint: {CollisionPoint}, ProjectileInfo: {ProjectileInfo}";
        }
    }

    public struct ProjectileInfo
    {
    }
}