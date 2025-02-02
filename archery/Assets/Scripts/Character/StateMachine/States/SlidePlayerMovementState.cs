using Archery.Character.Animation;
using Archery.Character.Collisions;
using Archery.Core;
using Archery.Utils;
using UnityEngine;

namespace Archery.Character.StateMachine.States
{
    public class SlidePlayerMovementState : PlayerMovementState
    {
        private Velocity _preservedVelocity;

        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.Slide);
            _preservedVelocity = Components.Properties.Velocity;
        }

        public override void Update()
        {
            base.Update();

            var collision = Components.Collisions.GetCurrentMainStickyCollision();
            var moveDelta = _preservedVelocity * Components.Services.Time.DeltaTime;

            if (collision.HasValue)
            {
                moveDelta += (collision.Value.SlideAccelerationCoef - 1f) * _preservedVelocity * Components.Services.Time.DeltaTime;
            }

            Components.Movement.Move(moveDelta);
        }
    }
}