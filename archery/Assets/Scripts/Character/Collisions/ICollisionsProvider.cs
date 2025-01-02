using System.Collections.Generic;

namespace Archery.Character
{
    public interface ICollisionsProvider
    {
        void Clear();
        IReadOnlyList<SurfaceCollision> GetCollisions();
        SurfaceCollision? GetCurrentMainStickyCollision();
    }
}