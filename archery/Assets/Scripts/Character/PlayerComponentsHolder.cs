using Archery.Character.Animation;
using Archery.Character.Collisions;
using Archery.Character.Input;
using Archery.Character.Movement;
using Archery.Character.StateMachine;
using Archery.Core;
using Archery.Utils;
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


        public Vector3 GetNormalizedInputMoveDirection()
        {
            var look = Input.NormalizedLookDirection;
            var forward = look.ProjectOnGround().normalized;
            var right = Vector3.Cross(MathConstants.GroundNormal, forward).normalized;
            var moveDirection = (forward * Input.NormalizedForwardMovement + right * Input.NormalizedRightMovement).normalized;
            return moveDirection;
        }
    }
}