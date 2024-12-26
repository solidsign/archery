using Game.Libraries.App.Character.Movement.StateMachine;
using MyLibs.Core;
using MyLibs.Movement;
using UnityEngine;

namespace Game.Libraries.App.Character
{
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
                .AddState(new RunPlayerMovementState(_app.Time))
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

    public class RunPlayerMovementState : PlayerMovementState
    {
        private readonly ITimeProvider _time;

        public RunPlayerMovementState(ITimeProvider time)
        {
            _time = time;
        }
        
        public override void Update()
        {
            base.Update();

            var look = Components.Input.NormalizedLookDirection;
            var forward = Vector3.ProjectOnPlane(look, Vector3.up).normalized;
            var right = Vector3.Cross(Vector3.up, forward);
            var moveDirection = (forward * Components.Input.NormalizedForwardMovement + right * Components.Input.NormalizedRightMovement).normalized;
            var velocity = moveDirection * Components.Config.RunSpeed;
            var moveDelta = velocity * _time.DeltaTime;
            
            Components.Movement.Move(moveDelta);
        }
    }

    public class StandPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.Stand);
        }
    }
}