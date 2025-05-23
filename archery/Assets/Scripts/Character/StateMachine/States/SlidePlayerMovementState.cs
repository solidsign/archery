using Archery.Character.Animation;
using Archery.Core;

namespace Archery.Character.StateMachine.States
{
    public class SlidePlayerMovementState : PlayerMovementState
    {
        private Velocity _preservedVelocity;
        private float _time;

        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.Slide);
            _preservedVelocity = Components.Properties.Velocity;
            _time = 0f;
        }

        public override void Update()
        {
            base.Update();

            var collision = Components.Collisions.GetCurrentMainStickyCollision();
            _preservedVelocity = Components.ClampPreservedVelocity(_preservedVelocity);
            if (collision.HasValue)
            {
                _preservedVelocity += (collision.Value.SlideAccelerationCoef - 1f) * _preservedVelocity * Components.Services.Time.DeltaTime;
            }
            var moveDelta = _preservedVelocity * Components.Services.Time.DeltaTime * (1f + Components.Config.SlideBoostCoefCurve.Evaluate(_time / Components.Config.MaxSlideBoostTime));

            Components.Movement.Move(moveDelta);
            
            _time += Components.Services.Time.DeltaTime;
        }
    }
}