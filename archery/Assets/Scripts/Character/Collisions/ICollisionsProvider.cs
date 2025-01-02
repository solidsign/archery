using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Archery.Character
{
    public interface ICollisionsProvider
    {
        void Clear();
        IReadOnlyList<SurfaceCollision> GetCollisions();
        SurfaceCollision? GetCurrentMainStickyCollision();
    }

    public class CollisionsProvider : MonoBehaviour, ICollisionsProvider
    {
        private readonly ContactPoint[] _sharedContactPoints = new ContactPoint[6];
        private readonly List<SurfaceCollision> _currentCollisions = new();
        
        private SurfaceCollision? _cachedMainStickyCollision = null;

        public IReadOnlyList<SurfaceCollision> GetCollisions() => _currentCollisions;

        public SurfaceCollision? GetCurrentMainStickyCollision()
        {
            if (_cachedMainStickyCollision.HasValue) return _cachedMainStickyCollision;
            if (_currentCollisions.Count == 0) return null;

            _cachedMainStickyCollision = _currentCollisions.OrderBy(x => Vector3.Angle(Vector3.up, x.SurfaceNormal)).First();
            return _cachedMainStickyCollision;
        }

        public void Clear()
        {
            _currentCollisions.Clear();
            _cachedMainStickyCollision = null;
        }

        private void OnCollisionEnter(Collision other)
        {
            var count = other.GetContacts(_sharedContactPoints);
            for (int i = 0; i < count; i++)
            {
                var contact = _sharedContactPoints[i];
                var surfaceNormal = contact.normal;
                var collisionPoint = contact.point;
                var slideAccelerationCoef = 1f;
                var projectileInfo = contact.otherCollider.CompareTag($"Projectile") ? new ProjectileInfo() : (ProjectileInfo?)null;
                var surfaceCollision = new SurfaceCollision(surfaceNormal, slideAccelerationCoef, collisionPoint, projectileInfo, CollisionState.Enter);
                _currentCollisions.Add(surfaceCollision);
            }
        }
        
        private void OnCollisionStay(Collision other)
        {
            var count = other.GetContacts(_sharedContactPoints);
            for (int i = 0; i < count; i++)
            {
                var contact = _sharedContactPoints[i];
                var surfaceNormal = contact.normal;
                var collisionPoint = contact.point;
                var slideAccelerationCoef = 1f;
                var surfaceCollision = new SurfaceCollision(surfaceNormal, slideAccelerationCoef, collisionPoint, null, CollisionState.Stay);
                _currentCollisions.Add(surfaceCollision);
            }
        }
    }
}