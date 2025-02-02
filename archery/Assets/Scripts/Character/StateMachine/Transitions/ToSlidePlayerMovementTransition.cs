using Archery.Utils;

namespace Archery.Character.StateMachine.Transitions
{
    public class ToSlidePlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => HighPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            var standingAngle = mainCollision.Value.SurfaceNormal.GetAngleWithWorldGround();

            return standingAngle <= Components.Config.MaxSlideAngle &&
                   standingAngle >= Components.Config.MinSlideAngle &&
                   Components.Properties.Velocity.Value.ProjectOnCurrentGround(mainCollision.Value).magnitude > Components.Config.MinSlideVelocity &&
                   Components.Input.Slide.IsPressed;
        }
    }
}