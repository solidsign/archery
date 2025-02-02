using Archery.Utils;

namespace Archery.Character.StateMachine.Transitions
{
    public class ToInAirPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => LowestPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return true;
            
            var standingAngle = mainCollision.Value.SurfaceNormal.GetAngleWithWorldGround();
            return standingAngle > Components.Config.MaxStandAngle;
        }
    }
}