using System.Collections.Generic;
using System.Linq;
using Archery.Utils;
using UnityEngine;

namespace Archery.Character.Collisions
{
    public class CollisionsProvider : MonoBehaviour, ICollisionsProvider
    {
        [SerializeField] private SurfacesConfig _surfacesConfig;
        private readonly List<SurfaceCollision> _currentCollisions = new();
        
        private SurfaceCollision? _cachedMainStickyCollision = null;

        public IReadOnlyList<SurfaceCollision> GetCollisions() => _currentCollisions;

        public SurfaceCollision? GetCurrentMainStickyCollision()
        {
            if (_cachedMainStickyCollision.HasValue) return _cachedMainStickyCollision;
            if (_currentCollisions.Count == 0) return null;

            _cachedMainStickyCollision = _currentCollisions.OrderBy(x => x.SurfaceNormal.GetAngleWithWorldGround()).First();
            return _cachedMainStickyCollision;
        }

        public void Clear()
        {
            _currentCollisions.Clear();
            _cachedMainStickyCollision = null;
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            // todo: add proejectile info
            
            var surfaceConfig = _surfacesConfig.GetConfig(hit.gameObject.tag);
            _currentCollisions.Add(new SurfaceCollision(hit.normal, surfaceConfig.SlideAccelerationCoef, hit.point, null));
        }
    }
}