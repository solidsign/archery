namespace Game.Core
{
    public class MovingObjectModel : IMovingObjectModel
    {
        public DecoratableAcceleration DecoratableAcceleration { get; }
        public DecoratableVelocity DecoratableVelocity { get; }

        public Acceleration Acceleration => DecoratableAcceleration.Value;
        public Velocity Velocity => DecoratableVelocity.Value;

        public MovingObjectModel(ITimeProvider time)
        {
            DecoratableAcceleration = new DecoratableAcceleration(Acceleration.Zero);
            DecoratableVelocity = new DecoratableVelocity(Velocity.Zero, DecoratableAcceleration, time);
        }
    }
}