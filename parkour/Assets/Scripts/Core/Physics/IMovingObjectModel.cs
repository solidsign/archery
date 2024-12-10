namespace Game.Core
{
    public interface IMovingObjectModel : IReadOnlyMovingObjectModel
    {
        public DecoratableAcceleration DecoratableAcceleration { get; }
        public DecoratableVelocity DecoratableVelocity { get; }
    }
}