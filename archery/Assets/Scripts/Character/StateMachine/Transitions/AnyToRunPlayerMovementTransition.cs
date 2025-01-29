using Archery.Character.StateMachine.States;
using Archery.Utils;

namespace Archery.Character.StateMachine.Transitions
{
    public class AnyToRunPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => CommonPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            if (currentState is RunPlayerMovementState) return false;
            
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            var standingAngle = mainCollision.Value.SurfaceNormal.GetAngleWithGround();
            
            return standingAngle < Components.Config.MaxStandAngle &&
                   (Components.Input.NormalizedRightMovement.Abs() > 0f ||
                    Components.Input.NormalizedForwardMovement.Abs() > 0f);
        }
        protected override void PerformTransitionInternal()
        {
        }
    }
}