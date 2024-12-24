namespace Game.Core
{
    internal class GravityAccelerationDecorator : IAccelerationDecorator
    {
        private readonly IValue<Acceleration> _gravityAcceleration;

        public GravityAccelerationDecorator(IValue<Acceleration> gravityAcceleration)
        {
            _gravityAcceleration = gravityAcceleration;
        }
        
        public Acceleration Decorate(Acceleration value)
        {
            return value + _gravityAcceleration.Value;
        }
    }
}