using Archery.Utils;

namespace Archery.Character.StateMachine.Transitions
{
    public class ToJumpPlayerMovementTransition : PlayerMovementStateTransition
    {
        private bool _lastIsStandingValue = false;
        private float _coyoteTimeLeft;
        private bool _alreadyJumped;
        public override int Priority => TopPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            _coyoteTimeLeft -= Components.Services.Time.DeltaTime;
            var isStanding = IsStanding();
            if (isStanding is false && _lastIsStandingValue is true)
            {
                _coyoteTimeLeft = Components.Config.CoyoteTime;
            }

            var canTransition = (isStanding || _coyoteTimeLeft > 0f) && Components.Input.Jump.IsDown && _alreadyJumped is false;

            if (isStanding) _alreadyJumped = false;
            if (canTransition) _alreadyJumped = true;
            _lastIsStandingValue = isStanding;
            if (Components.Input.Jump.IsDown)
            {
                _coyoteTimeLeft = 0f;
            }
            return canTransition;
        }

        private bool IsStanding()
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            var standingAngle = mainCollision.Value.SurfaceNormal.GetAngleWithWorldGround();

            return standingAngle < Components.Config.MaxJumpSurfaceAngle;
        }
    }
}