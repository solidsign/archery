using System;
using System.Collections.Generic;
using UnityEngine;

namespace Archery.Character
{
    public interface ICollisionsProvider
    {
        IReadOnlyList<SurfaceCollision> GetCollisions();
        SurfaceCollision? GetCurrentMainStickyCollision();
    }

    public class CollisionsProvider : MonoBehaviour, ICollisionsProvider
    {
        private readonly ContactPoint[] _sharedContactPoints = new ContactPoint[6];
        private readonly List<SurfaceCollision> _currentCollisions = new();

        public IReadOnlyList<SurfaceCollision> GetCollisions() => _currentCollisions;

        public SurfaceCollision? GetCurrentMainStickyCollision()
        {
            throw new System.NotImplementedException();
        }

        private void OnCollisionEnter(Collision other)
        {
            var count = other.GetContacts(_sharedContactPoints);
            for (int i = 0; i < count; i++)
            {
                var contact = _sharedContactPoints[i];
                var surfaceNormal = contact.normal;
                var collisionPoint = contact.point;
                var slideAccelerationCoef = 0f;
                var projectileInfo = contact.otherCollider.CompareTag($"Projectile") ? new ProjectileInfo() : (ProjectileInfo?)null;
                var surfaceCollision = new SurfaceCollision(surfaceNormal, slideAccelerationCoef, collisionPoint, projectileInfo, CollisionState.Enter);
                _currentCollisions.Add(surfaceCollision);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            throw new NotImplementedException();
        }

        private void OnCollisionStay(Collision other)
        {
            throw new NotImplementedException();
        }
    }
}