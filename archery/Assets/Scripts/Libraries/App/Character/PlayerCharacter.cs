using MyLibs.Core;
using MyLibs.Movement;

namespace Game.Libraries.App.Character
{
    public class PlayerComponentsHolder : IPlayerComponentsHolder
    {
        public IVelocityHolder Velocity { get; }
        public IInputController Input { get; }
        public IMovementController MovementController { get; }
        public IAnimationController Animation { get; }
        public ICollisionsProvider Collisions { get; }
    }
    
    public class PlayerCharacter : IUpdatable
    {
        public App App { get; }
        public PlayerComponentsHolder Components { get; }
        public IMovementStateMachine MovementStateMachine { get; }

        public PlayerCharacter(App app, PlayerComponentsHolder components, IMovementStateMachine movementStateMachine)
        {
            App = app;
            Components = components;
            MovementStateMachine = movementStateMachine;
        }
        
        public void Update()
        {
            
        }
    }
    
    public class PlayerCharacterBuilder
    {
        private readonly App _app;
        private readonly PlayerComponentsHolder _playerComponentsHolder;

        public PlayerCharacterBuilder(App app, PlayerComponentsHolder playerComponentsHolder)
        {
            _app = app;
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
                .AddTransition<JumpPlayerMovementState>(new GroundedToJumpPlayerMovementTransition())
                .AddTransition<RunPlayerMovementState>(new StandToRunPlayerMovementTransition())
                .AddTransition<InAirPlayerMovementState>(new AnyToInAirPlayerMovementTransition())
                .AddTransition<RunPlayerMovementState>(new InAirToRunPlayerMovementTransition())
                .AddTransition<StandPlayerMovementState>(new InAirToStandPlayerMovementTransition())
                .AddTransition<SlidePlayerMovementState>(new GroundedSpeedToSlidePlayerMovementTransition())
                .AddTransition<InertialRunPlayerMovementState>(new InAirToInertialRunPlayerMovementTransition())
                .AddTransition<SlidePlayerMovementState>(new InAirToSlidePlayerMovementTransition())
                .Build();

            return new PlayerCharacter(_app, _playerComponentsHolder, movementStateMachine);
        }
    }

    public interface IInputController
    {
        
    }

    public interface IMovementController
    {
        
    }

    public interface IAnimationController
    {
        
    }

    public interface ICollisionsProvider
    {
        
    }
}