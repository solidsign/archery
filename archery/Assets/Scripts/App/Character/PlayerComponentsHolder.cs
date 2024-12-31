using Archery.Core;
using MyLibs.Movement;
using UnityEngine;

namespace Archery.Character
{
    public class PlayerComponentsHolder : IPlayerComponentsHolder
    {
        public PlayerComponentsHolder(
            Services services, 
            IPhysicalObjectProperties properties, 
            IInputController input, 
            IMovementController movement, 
            IPlayerCharacterAnimationController animation, 
            ICollisionsProvider collisions, 
            CharacterConfig config)
        {
            Services = services;
            Properties = properties;
            Input = input;
            Movement = movement;
            Animation = animation;
            Collisions = collisions;
            Config = config;
        }

        public Services Services { get; }
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