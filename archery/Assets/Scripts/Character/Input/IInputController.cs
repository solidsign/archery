using Archery.Character.Behaviours;
using UnityEngine;

namespace Archery.Character
{
    public interface IInputController : IMovementInputController
    {
        void Update();
    }

    public class SimpleInputController : IInputController
    {
        private readonly PlayerReferences _playerReferences;
        
        public Vector3 NormalizedLookDirection { get; private set; }
        public float NormalizedForwardMovement { get; private set; }
        public float NormalizedRightMovement { get; private set; }
        public KeyState Jump { get; private set; }
        public KeyState Slide { get; private set; }

        public SimpleInputController(PlayerReferences playerReferences)
        {
            _playerReferences = playerReferences;
        }
        
        public void Update()
        {
            NormalizedLookDirection = _playerReferences.LookCameraTransform.forward;
            NormalizedForwardMovement = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;
            NormalizedRightMovement = Input.GetKey(KeyCode.D) ? 1f : Input.GetKey(KeyCode.A) ? -1f : 0f;
            Jump = new KeyState(isPressed: Input.GetKey(KeyCode.Space), isDown: Input.GetKeyDown(KeyCode.Space), isUp: Input.GetKeyUp(KeyCode.Space));
            Slide = new KeyState(isPressed: Input.GetKey(KeyCode.LeftControl), isDown: Input.GetKeyDown(KeyCode.LeftControl), isUp: Input.GetKeyUp(KeyCode.LeftControl));
        }
    }
}