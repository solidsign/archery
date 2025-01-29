using Archery.Core;
using UnityEngine;

namespace Archery.Character.StateMachine.States
{
    public class InAirPlayerMovementState : PlayerMovementState
    {
        private float _inAirTime = 0f;
        private Velocity _preservedVelocity;

        public override void OnEnter()
        {
            base.OnEnter();
            _preservedVelocity = Components.Properties.Velocity;
            _inAirTime = 0f;
        }

        public override void Update()
        {
            base.Update();

            ApplyInputMovementToPreservedVelocity();
            ApplyPreservedVelocity();
            ApplyFalling();
        }

        private void ApplyInputMovementToPreservedVelocity()
        {
            var moveDirection = Components.GetNormalizedInputMoveDirection();
            var acceleration = moveDirection * Components.Config.InAirControlAcceleration;
            var velocityDelta = acceleration / Components.Services.Time.DeltaTime;

            var horizontalPreservedVelocity = Vector3.ProjectOnPlane(_preservedVelocity, Vector3.up);
            var verticalPreservedVelocity = _preservedVelocity - horizontalPreservedVelocity;

            horizontalPreservedVelocity = Vector3.ClampMagnitude(horizontalPreservedVelocity + velocityDelta, Mathf.Max(horizontalPreservedVelocity.magnitude, Components.Config.RunSpeed));

            _preservedVelocity = horizontalPreservedVelocity + verticalPreservedVelocity;
        }

        private void ApplyPreservedVelocity()
        {
            Components.Movement.Move(_preservedVelocity * Components.Services.Time.DeltaTime);
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
            
            var fallingVelocity = Components.Config.FallingVelocityCurve.Evaluate(_inAirTime / Components.Config.MaxFallingTime) * Components.Config.MaxFallingVelocity;
            Components.Movement.Move(Vector3.down * fallingVelocity * Components.Services.Time.DeltaTime);
        }
    }
}