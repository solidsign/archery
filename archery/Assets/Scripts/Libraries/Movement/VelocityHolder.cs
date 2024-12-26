using MyLibs.Core;
using UnityEngine;

namespace MyLibs.Movement
{
    public interface IPhysicalObjectProperties
    {
        Position Position { get; set; }
        Velocity Velocity { get; set; }

        void Initialize();
        
        /// <summary>
        /// Tracks last move to current velocity
        /// </summary>
        void Update();
    }
    
    public class PhysicalObjectProperties : IPhysicalObjectProperties
    {
        private readonly Transform _transform;
        private readonly ITimeProvider _time;
        private Position _lastPosition;

        public Position Position
        {
            get => new(_transform.position);
            set => _transform.position = value;
        }
        public Velocity Velocity { get; set; }

        public PhysicalObjectProperties(Transform transform, ITimeProvider time)
        {
            _transform = transform;
            _time = time;
        }

        public void Initialize()
        {
            _lastPosition = Position;
        }
        
        public void Update()
        {
            Velocity = new Velocity((Position - _lastPosition) / _time.DeltaTime);
        }        
    }
}