using Archery.Character.Behaviours;
using Archery.Character.StateMachine;
using Archery.Character.StateMachine.States;
using Archery.Core;
using UnityEngine;

namespace Archery.Character
{
    public class PlayerCharacterBuilder
    {
        private readonly PlayerReferences _playerReferences;
        private readonly Services _services;

        public PlayerCharacterBuilder(PlayerReferences playerReferences, Services services)
        {
            _playerReferences = playerReferences;
            _services = services;
        }

        public PlayerCharacter Build()
        {
            var playerComponentsHolder = new PlayerComponentsHolder(
                services: _services,
                properties: new PhysicalObjectProperties(_playerReferences.MainTransform, _services.Time).Initialize(),
                input: new SimpleInputController(_playerReferences),
                movement: new MovementController(_playerReferences.CharacterController, _playerReferences.Config),
                animation: new StubAnimationController(),
                collisions: _playerReferences.Collisions,
                config: _playerReferences.Config);
            
            var movementStateMachine = new MovementStateMachineBuilder(playerComponentsHolder)
                .AddInitialState(new StandPlayerMovementState())
                .AddState(new RunPlayerMovementState())
                .AddState(new JumpPlayerMovementState())
                .AddState(new InAirPlayerMovementState())
                .AddTransition<StandPlayerMovementState>(new AnyToStandPlayerMovementTransition())
                .AddTransition<RunPlayerMovementState>(new AnyToRunPlayerMovementTransition())
                .AddTransition<InAirPlayerMovementState>(new AnyToInAirPlayerMovementTransition())
                .AddTransition<JumpPlayerMovementState>(new GroundedToJumpPlayerMovementTransition())
                .Build();

            return new PlayerCharacter(playerComponentsHolder, movementStateMachine);
        }
    }

    public class StubAnimationController : IPlayerCharacterAnimationController
    {
        public void SetState(PlayerAnimationState state)
        {
            
        }
    }


    public class GroundedToJumpPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => TopPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            var standingAngle = Vector3.Angle(Vector3.up, mainCollision.Value.SurfaceNormal);
            
            return standingAngle < Components.Config.MaxJumpSurfaceAngle && Components.Input.Jump.IsDown;
        }

        protected override void PerformTransitionInternal()
        {
        }
    }

    public class AnyToRunPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => CommonPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            var standingAngle = Vector3.Angle(Vector3.up, mainCollision.Value.SurfaceNormal);
            
            return standingAngle < Components.Config.MaxStandAngle &&
                   (Components.Input.NormalizedRightMovement.Abs() > 0f ||
                    Components.Input.NormalizedForwardMovement.Abs() > 0f);
        }
        protected override void PerformTransitionInternal()
        {
        }
    }
    
    public class AnyToInAirPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => LowestPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            return currentState is not InAirPlayerMovementState && Components.Collisions.GetCurrentMainStickyCollision().HasValue is false;
        }

        protected override void PerformTransitionInternal()
        {
        }
    }
    
    public class AnyToStandPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => LowestPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            if (Components.Input.Slide.IsPressed) return false;
            if (Components.Input.Jump.IsDown) return false;
            if (Components.Input.NormalizedForwardMovement.Abs() > 0f) return false;
            if (Components.Input.NormalizedRightMovement.Abs() > 0f) return false;

            var standingAngle = Vector3.Angle(Vector3.up, mainCollision.Value.SurfaceNormal);
            return standingAngle < Components.Config.MaxStandAngle;
        }

        protected override void PerformTransitionInternal()
        {
        }
    }
    
}