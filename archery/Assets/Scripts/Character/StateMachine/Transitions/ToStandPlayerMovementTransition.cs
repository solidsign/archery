using Archery.Utils;

namespace Archery.Character.StateMachine.Transitions
{
    public class ToStandPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => LowestPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            if (Components.Input.Slide.IsPressed) return false;
            if (Components.Input.Jump.IsDown) return false;
            if (Components.Input.NormalizedForwardMovement.Abs() > 0f) return false;
            if (Components.Input.NormalizedRightMovement.Abs() > 0f) return false;

            var standingAngle = mainCollision.Value.SurfaceNormal.GetAngleWithWorldGround();
            return standingAngle < Components.Config.MaxStandAngle;
        }
    }
}