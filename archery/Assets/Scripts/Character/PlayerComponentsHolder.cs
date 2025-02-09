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
        public PlayerJobs<IPlayerUtilityJob> UtilityJobs { get; } = new();


        public Vector3 GetNormalizedInputMoveDirectionWorld()
        {
            var look = Input.NormalizedLookDirection;
            var forward = look.ProjectOnWorldGround().normalized;
            var right = Vector3.Cross(MathConstants.WorldGroundNormal, forward).normalized;
            var moveDirection = (forward * Input.NormalizedForwardMovement + right * Input.NormalizedRightMovement).normalized;
            return moveDirection;
        }

        public Vector3 GetNormalizedInputMoveDirectionOnCurrentGround(SurfaceCollision surfaceCollision)
        {
            var look = Input.NormalizedLookDirection;
            var forward = look.ProjectOnCurrentGround(surfaceCollision).normalized;
            var right = Vector3.Cross(surfaceCollision.SurfaceNormal, forward).normalized;
            var moveDirection = (forward * Input.NormalizedForwardMovement + right * Input.NormalizedRightMovement).normalized;
            return moveDirection;
        }

        public Velocity ClampPreservedVelocity(Velocity oldVelocity)
        {
            var horizontalActualVelocity = Properties.Velocity.Value.ProjectOnWorldGround();
            var verticalActualVelocity = Properties.Velocity.Value - horizontalActualVelocity;
            var horizontalPreservedVelocity = oldVelocity.Value.ProjectOnWorldGround();
            var verticalPreservedVelocity = oldVelocity.Value - horizontalPreservedVelocity;
            horizontalPreservedVelocity = Vector3.ClampMagnitude(horizontalPreservedVelocity, horizontalActualVelocity.magnitude);
            verticalPreservedVelocity = Vector3.ClampMagnitude(verticalPreservedVelocity, verticalActualVelocity.magnitude);
        
            return new Velocity(horizontalPreservedVelocity + verticalPreservedVelocity);
        }
    }
}