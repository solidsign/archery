using MyLibs.Movement;
using UnityEngine;

namespace App.Character
{
    public class PlayerComponentsHolder : IPlayerComponentsHolder
    {
        public global::App.Core.App App { get; }
        public IPhysicalObjectProperties Properties { get; }
        public IInputController Input { get; }
        public IMovementController Movement { get; }
        public IPlayerCharacterAnimationController Animation { get; }
        public ICollisionsProvider Collisions { get; }
        public CharacterConfig Config { get; }


        public Vector3 GetNormalizedInputMoveDirection() => GetNormalizedInputMoveDirection(Vector3.up); 
        public Vector3 GetNormalizedInputMoveDirection(Vector3 planeNormal)
        {
            var look = Input.NormalizedLookDirection;
            var forward = Vector3.ProjectOnPlane(look, planeNormal).normalized;
            var right = Vector3.Cross(forward, planeNormal).normalized;
            var moveDirection = (forward * Input.NormalizedForwardMovement + right * Input.NormalizedRightMovement).normalized;
            return moveDirection;
        }
    }
}