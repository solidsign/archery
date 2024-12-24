namespace Game.Core
{
    public interface IGravityInfluence
    {
        public DecoratableAcceleration AccelerationFromGravity { get; }   
    }
}