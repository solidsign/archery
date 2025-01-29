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
            Vector3 rot = playerReferences.LookCameraTransform.localRotation.eulerAngles;
            _rotY = rot.y;
            _rotX = rot.x;
        }
        public float mouseSensitivity = 100.0f;
        public float clampAngle = 80.0f;

        private float _rotY = 0.0f; // rotation around the up/y axis
        private float _rotX = 0.0f; // rotation around the right/x axis

        private void RotateCamera()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            _rotY += mouseX * mouseSensitivity * Time.deltaTime;
            _rotX += mouseY * mouseSensitivity * Time.deltaTime;

            _rotX = Mathf.Clamp(_rotX, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(_rotX, _rotY, 0.0f);
            _playerReferences.LookCameraTransform.rotation = localRotation;
        }
        
        public void Update()
        {
            RotateCamera();
            NormalizedLookDirection = _playerReferences.LookCameraTransform.forward;
            NormalizedForwardMovement = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;
            NormalizedRightMovement = Input.GetKey(KeyCode.D) ? 1f : Input.GetKey(KeyCode.A) ? -1f : 0f;
            Jump = new KeyState(isPressed: Input.GetKey(KeyCode.Space), isDown: Input.GetKeyDown(KeyCode.Space), isUp: Input.GetKeyUp(KeyCode.Space));
            Slide = new KeyState(isPressed: Input.GetKey(KeyCode.LeftControl), isDown: Input.GetKeyDown(KeyCode.LeftControl), isUp: Input.GetKeyUp(KeyCode.LeftControl));
        }
    }
}