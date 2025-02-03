using Archery.Utils;

namespace Archery.Character.StateMachine.Transitions
{
    public class ToRunPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => CommonPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            var standingAngle = mainCollision.Value.SurfaceNormal.GetAngleWithWorldGround();
            
            return standingAngle <= Components.Config.MaxStandAngle &&
                   (Components.Input.NormalizedRightMovement.Abs() > 0f ||
                    Components.Input.NormalizedForwardMovement.Abs() > 0f);
        }
    }
}