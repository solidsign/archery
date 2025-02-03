using UnityEngine;

namespace Archery.Character.Movement
{
    public class MovementController : IMovementController
    {
        private readonly CharacterController _characterController;
        private readonly CharacterConfig _config;
        private Vector3 _currentDelta;
        
        public PlayerJobs<IPlayerMovementJob> Jobs { get; } = new();

        public MovementController(CharacterController characterController, CharacterConfig config)
        {
            _characterController = characterController;
            _config = config;
        }
        
        public void Move(Vector3 delta)
        {
            _currentDelta += delta;
        }

        public void Apply()
        {
            _characterController.Move(_currentDelta + Vector3.down * _config.StickToGroundSpeed);
            _currentDelta = Vector3.zero;
        }
    }
}