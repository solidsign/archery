namespace Game.Core
{
    public class DecoratableVelocity : DecoratableValue<Velocity>
    {
        public DecoratableVelocity(Velocity baseValue, IValue<Acceleration> accelerationProvider, ITimeProvider time) :
            base(baseValue)
        {
            this.Decorate(new VelocityAccelerator(accelerationProvider, time));
        }
    }
}