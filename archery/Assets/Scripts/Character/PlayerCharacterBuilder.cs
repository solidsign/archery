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
                movement: new MovementController(_playerReferences.CharacterController),
                animation: new StubAnimationController(),
                collisions: _playerReferences.Collisions,
                config: _playerReferences.Config);
            
            var movementStateMachine = new MovementStateMachineBuilder(playerComponentsHolder)
                .AddInitialState(new StandPlayerMovementState())
                .AddState(new RunPlayerMovementState())
                .AddState(new JumpPlayerMovementState())
                .AddState(new InAirPlayerMovementState())
                // .AddState(new SlidePlayerMovementState())
                // .AddState(new InertialRunPlayerMovementState())
                // .AddState(new CrouchPlayerMovementState())
                // .AddState(new WallRunVerticalPlayerMovementState())
                // .AddState(new WallRunHorizontalPlayerMovementState())
                // .AddState(new InertialWallRunVerticalPlayerMovementState())
                // .AddState(new InertialWallRunHorizontalPlayerMovementState())
                .AddTransition<StandPlayerMovementState>(new AnyToStandPlayerMovementTransition())
                .AddTransition<RunPlayerMovementState>(new AnyToRunPlayerMovementTransition())
                .AddTransition<InAirPlayerMovementState>(new AnyToInAirPlayerMovementTransition())
                .AddTransition<JumpPlayerMovementState>(new GroundedToJumpPlayerMovementTransition())
                // .AddTransition<SlidePlayerMovementState>(new GroundedSpeedToSlidePlayerMovementTransition())
                // .AddTransition<InertialRunPlayerMovementState>(new InAirToInertialRunPlayerMovementTransition())
                // .AddTransition<SlidePlayerMovementState>(new InAirToSlidePlayerMovementTransition())
                // .AddTransition<CrouchPlayerMovementState>(new GroundedToCrouchPlayerMovementTransition())
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


    public class WallRunVerticalPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.WallRunVertical);
        }
    }
    
    public class WallRunHorizontalPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.WallRunHorizontal);
        }
    }
    
    public class InertialWallRunVerticalPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.InertialWallRunVertical);
        }
    }
    
    public class InertialWallRunHorizontalPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.InertialWallRunHorizontal);
        }
    }
    
    public class GroundedToJumpPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => HighPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            var standingAngle = Vector3.Angle(Vector3.up, mainCollision.Value.SurfaceNormal);
            
            return standingAngle < Components.Config.MaxStandAngle && Components.Input.Jump.IsDown;
        }

        protected override void PerformTransitionInternal()
        {
        }
    }

    public class GroundedSpeedToSlidePlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority { get; }

        public override bool CanTransitionFrom(IMovementState currentState)
        {
            throw new System.NotImplementedException();
        }

        protected override void PerformTransitionInternal()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class GroundedToCrouchPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority { get; }

        public override bool CanTransitionFrom(IMovementState currentState)
        {
            throw new System.NotImplementedException();
        }

        protected override void PerformTransitionInternal()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class InAirToInertialRunPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority { get; }
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            throw new System.NotImplementedException();
        }

        protected override void PerformTransitionInternal()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class InAirToSlidePlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority { get; }
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            throw new System.NotImplementedException();
        }

        protected override void PerformTransitionInternal()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class InAirToCrouchPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority { get; }
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            throw new System.NotImplementedException();
        }

        protected override void PerformTransitionInternal()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class InAirToRunPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority { get; }
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            throw new System.NotImplementedException();
        }

        protected override void PerformTransitionInternal()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class InAirToStandPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority { get; }
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            throw new System.NotImplementedException();
        }

        protected override void PerformTransitionInternal()
        {
            throw new System.NotImplementedException();
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
            return Components.Collisions.GetCurrentMainStickyCollision().HasValue is false;
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