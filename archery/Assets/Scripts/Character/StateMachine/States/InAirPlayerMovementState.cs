using Archery.Core;
using UnityEngine;

namespace Archery.Character.StateMachine.States
{
    public class InAirPlayerMovementState : PlayerMovementState
    {
        private float _inAirTime = 0f;
        private Velocity _startVelocity;

        public override void OnEnter()
        {
            base.OnEnter();
            _startVelocity = Components.Properties.Velocity;
            _inAirTime = 0f;
        }

        public override void Update()
        {
            base.Update();

            ApplyPreservedSpeed();
            ApplyInputMovement();
            ApplyFalling();
        }

        private void ApplyFalling()
        {
            if (Components.Movement.Jobs.HasJob<JumpPlayerMovementState.Job>())
            {
                _inAirTime = 0f;
                return;
            }
            
            _inAirTime += Components.Services.Time.DeltaTime;
            _inAirTime = Mathf.Clamp(_inAirTime, 0f, Components.Config.MaxFallingTime);
            
            var fallingVelocity = Components.Config.FallingVelocityCurve.Evaluate(_inAirTime) * Components.Config.MaxFallingVelocity;
            Components.Movement.Move(Vector3.down * fallingVelocity * Components.Services.Time.DeltaTime);
        }

        private void ApplyPreservedSpeed()
        {
            Components.Movement.Move(_startVelocity * Components.Services.Time.DeltaTime);
        }

        private void ApplyInputMovement()
        {
            var moveDirection = Components.GetNormalizedInputMoveDirection();
            var velocity = moveDirection * Components.Config.InAirRunSpeed;
            var moveDelta = velocity * Components.Services.Time.DeltaTime;
            
            Components.Movement.Move(moveDelta);
        }
    }
}