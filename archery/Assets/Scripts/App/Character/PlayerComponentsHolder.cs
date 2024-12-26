using MyLibs.Movement;
using UnityEngine;

namespace Game.Libraries.App.Character
{
    public class PlayerComponentsHolder : IPlayerComponentsHolder
    {
        public App App { get; }
        public IPhysicalObjectProperties Properties { get; }
        public IInputController Input { get; }
        public IMovementController Movement { get; }
        public IPlayerCharacterAnimationController Animation { get; }
        public ICollisionsProvider Collisions { get; }
        public CharacterConfig Config { get; }
        public PlayerJobs Jobs { get; }
        
        
        public Vector3 GetNormalizedInputMoveDirection()
        {
            var look = Input.NormalizedLookDirection;
            var forward = Vector3.ProjectOnPlane(look, Vector3.up).normalized;
            var right = Vector3.Cross(Vector3.up, forward);
            var moveDirection = (forward * Input.NormalizedForwardMovement + right * Input.NormalizedRightMovement).normalized;
            return moveDirection;
        }
    }
}