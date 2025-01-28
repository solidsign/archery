using UnityEngine;

namespace Archery.Character
{
    public interface IMovementController
    {
        PlayerJobs<IPlayerMovementJob> Jobs { get; }

        /// <summary>
        /// Tries to move in given delta
        /// </summary>
        /// <param name="delta">Move delta</param>
        /// <returns>Resulted movement</returns>
        void Move(Vector3 delta);

        /// <summary>
        /// Applies the resulting movement
        /// </summary>
        void Apply();
    }
    
    public class MovementController : IMovementController
    {
        private readonly CharacterController _characterController;
        private Vector3 _currentDelta;
        
        public PlayerJobs<IPlayerMovementJob> Jobs { get; } = new();

        public MovementController(CharacterController characterController)
        {
            _characterController = characterController;
        }
        
        public void Move(Vector3 delta)
        {
            _currentDelta += delta;
        }

        public void Apply()
        {
            _characterController.Move(_currentDelta + Vector3.down * float.Epsilon);
            _currentDelta = Vector3.zero;
        }
    }
}