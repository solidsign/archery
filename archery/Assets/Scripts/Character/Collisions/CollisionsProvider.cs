using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Archery.Character
{
    public class CollisionsProvider : MonoBehaviour, ICollisionsProvider
    {
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

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            // todo: add stickiness rank to surface by tag and handle different slide accelerations
            _currentCollisions.Add(new SurfaceCollision(hit.normal, 1, hit.point, null));
        }
    }
}