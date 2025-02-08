using System.Collections.Generic;

namespace Archery.Character.Collisions
{
    public interface ICollisionsProvider
    {
        void Clear();
        IReadOnlyList<SurfaceCollision> GetCollisions();
        SurfaceCollision? GetCurrentMainStickyCollision();
        bool TryGetCurrentMainStickyCollision(out SurfaceCollision collision);
    }
}