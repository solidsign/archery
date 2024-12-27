using Game.Libraries.App.Character.Movement.StateMachine;
using MyLibs.Movement;

namespace Game.Libraries.App.Character
{
    public class PlayerCharacterBuilder
    {
        private readonly PlayerComponentsHolder _playerComponentsHolder;

        public PlayerCharacterBuilder(PlayerComponentsHolder playerComponentsHolder)
        {
            _playerComponentsHolder = playerComponentsHolder;
        }
        
        public PlayerCharacter Build()
        {
            var movementStateMachine = new MovementStateMachineBuilder(_playerComponentsHolder)
                .AddInitialState(new StandPlayerMovementState())
                .AddState(new RunPlayerMovementState())
                .AddState(new JumpPlayerMovementState())
                .AddState(new InAirPlayerMovementState())
                .AddState(new SlidePlayerMovementState())
                .AddState(new InertialRunPlayerMovementState())
                .AddState(new CrouchPlayerMovementState())
                .AddState(new WallRunVerticalPlayerMovementState())
                .AddState(new WallRunHorizontalPlayerMovementState())
                .AddState(new InertialWallRunVerticalPlayerMovementState())
                .AddState(new InertialWallRunHorizontalPlayerMovementState())
                .AddTransition<JumpPlayerMovementState>(new GroundedToJumpPlayerMovementTransition())
                .AddTransition<RunPlayerMovementState>(new StandToRunPlayerMovementTransition())
                .AddTransition<InAirPlayerMovementState>(new AnyToInAirPlayerMovementTransition())
                .AddTransition<RunPlayerMovementState>(new InAirToRunPlayerMovementTransition())
                .AddTransition<StandPlayerMovementState>(new InAirToStandPlayerMovementTransition())
                .AddTransition<SlidePlayerMovementState>(new GroundedSpeedToSlidePlayerMovementTransition())
                .AddTransition<InertialRunPlayerMovementState>(new InAirToInertialRunPlayerMovementTransition())
                .AddTransition<SlidePlayerMovementState>(new InAirToSlidePlayerMovementTransition())
                .AddTransition<CrouchPlayerMovementState>(new GroundedToCrouchPlayerMovementTransition())
                .Build();

            return new PlayerCharacter(_playerComponentsHolder, movementStateMachine);
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
    
    public class StandToRunPlayerMovementTransition : PlayerMovementStateTransition
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
    
    public class AnyToInAirPlayerMovementTransition : PlayerMovementStateTransition
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
    
    
}