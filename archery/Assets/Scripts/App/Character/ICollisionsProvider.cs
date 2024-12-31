namespace App.Character
{
    public interface ICollisionsProvider
    {
        SurfaceCollision[] GetCollisions();
        SurfaceCollision? GetCurrentMainStickyCollision();
        void Update();
    }
}