namespace Game.Libraries.App.Character
{
    public interface ICollisionsProvider
    {
        SurfaceCollision[] GetCollisions();
        SurfaceCollision? GetCurrentMainCollision();
        void Update();
    }
}