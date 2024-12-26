namespace Game.Libraries.App.Character
{
    public interface ICollisionsProvider
    {
        SurfaceCollision[] GetCollisions();
        void Update();
    }
}