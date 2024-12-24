namespace Game.Core
{
    public class VelocityAccelerator : IValueDecorator<Velocity>
    {
        private readonly IValue<Acceleration> _acceleration;
        private readonly ITimeProvider _time;
        
        private Velocity _currentAddedVelocity = Velocity.Zero;
        private long _lastUpdateTick = 0;

        public VelocityAccelerator(IValue<Acceleration> acceleration, ITimeProvider time)
        {
            _acceleration = acceleration;
            _time = time;
        }
        
        public Velocity Decorate(Velocity value)
        {
            if (_time.Tick > _lastUpdateTick)
            {
                _currentAddedVelocity += new Velocity(_acceleration.Value.Value * _time.DeltaTime);
                _lastUpdateTick = _time.Tick;
            } 
            
            return value + _currentAddedVelocity;
        }
    }
}