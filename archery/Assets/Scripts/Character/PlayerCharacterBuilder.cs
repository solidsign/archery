using Archery.Character.Animation;
using Archery.Character.Input;
using Archery.Character.Movement;
using Archery.Character.StateMachine;
using Archery.Character.StateMachine.States;
using Archery.Character.StateMachine.Transitions;
using Archery.Core;

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
                .AddState(new SlidePlayerMovementState())
                .AddState(new DashPlayerMovementState())
                .AddTransition<StandPlayerMovementState>(new ToStandPlayerMovementTransition())
                .AddTransition<RunPlayerMovementState>(new ToRunPlayerMovementTransition())
                .AddTransition<InAirPlayerMovementState>(new ToInAirPlayerMovementTransition())
                .AddTransition<JumpPlayerMovementState>(new ToJumpPlayerMovementTransition())
                .AddTransition<SlidePlayerMovementState>(new ToSlidePlayerMovementTransition())
                .AddTransition<DashPlayerMovementState>(new ToDashPlayerMovementTransition())
                .Build();

            return new PlayerCharacter(playerComponentsHolder, movementStateMachine);
        }
    }
}