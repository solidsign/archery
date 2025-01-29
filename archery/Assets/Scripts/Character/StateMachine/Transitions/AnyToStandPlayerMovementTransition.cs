using Archery.Character.StateMachine.States;
using Archery.Utils;

namespace Archery.Character.StateMachine.Transitions
{
    public class AnyToStandPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => LowestPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            if (currentState is StandPlayerMovementState) return false;
            
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            if (Components.Input.Slide.IsPressed) return false;
            if (Components.Input.Jump.IsDown) return false;
            if (Components.Input.NormalizedForwardMovement.Abs() > 0f) return false;
            if (Components.Input.NormalizedRightMovement.Abs() > 0f) return false;

            var standingAngle = mainCollision.Value.SurfaceNormal.GetAngleWithGround();
            return standingAngle < Components.Config.MaxStandAngle;
        }

        protected override void PerformTransitionInternal()
        {
        }
    }
}