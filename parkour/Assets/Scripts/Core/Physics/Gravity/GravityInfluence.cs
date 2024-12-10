namespace Game.Core
{
    public class GravityInfluence : IGravityInfluence
    {
        public DecoratableAcceleration AccelerationFromGravity { get; }

        public GravityInfluence(Acceleration gravityAcceleration)
        {
            AccelerationFromGravity = new DecoratableAcceleration(gravityAcceleration);
        }
    }
}