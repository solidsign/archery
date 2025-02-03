using Archery.Core;
using UnityEngine;

namespace Archery.Character.Movement
{
    public interface IPhysicalObjectProperties
    {
        Position Position { get; set; }
        Velocity Velocity { get; set; }

        IPhysicalObjectProperties Initialize();
        
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

        public IPhysicalObjectProperties Initialize()
        {
            _lastPosition = Position;
            return this;
        }
        
        public void Update()
        {
            Velocity = new Velocity((Position - _lastPosition) / _time.DeltaTime);
            _lastPosition = Position;
        }        
    }
}