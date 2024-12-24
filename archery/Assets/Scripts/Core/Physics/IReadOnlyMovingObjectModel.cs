namespace Game.Core
{
    public interface IReadOnlyMovingObjectModel
    {
        public Acceleration Acceleration { get; }
        public Velocity Velocity { get; }
    }
}