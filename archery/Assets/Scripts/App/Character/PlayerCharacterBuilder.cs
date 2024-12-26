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
}