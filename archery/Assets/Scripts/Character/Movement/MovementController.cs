using UnityEngine;

namespace Archery.Character.Movement
{
    public class MovementController : IMovementController
    {
        private readonly CharacterController _characterController;
        private readonly CharacterConfig _config;
        private Vector3 _currentDelta;
        
        public Vector3 DebugLastAppliedDelta { get; private set; }
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
            DebugLastAppliedDelta = _currentDelta + Vector3.down * _config.StickToGroundSpeed;
            _characterController.Move(DebugLastAppliedDelta);
            _currentDelta = Vector3.zero;
        }
    }
}