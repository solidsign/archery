using MyLibs.Core;

namespace MyLibs.Movement
{
    public interface IVelocityHolder : IUpdatable
    {
        Velocity Velocity { get; set; }
        Acceleration Acceleration { get; set; }
    }
    
    public class VelocityHolder : IVelocityHolder
    {
        private readonly ITimeProvider _time;

        public VelocityHolder(ITimeProvider time)
        {
            _time = time;
        }

        public Velocity Velocity { get; set; }
        public Acceleration Acceleration { get; set; }
        
        public void Update()
        {
            Velocity += Acceleration * _time.DeltaTime;
        }
    }
}