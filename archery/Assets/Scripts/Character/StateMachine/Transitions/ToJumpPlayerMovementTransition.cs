using Archery.Character.StateMachine.States;
using Archery.Utils;

namespace Archery.Character.StateMachine.Transitions
{
    public class ToJumpPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => TopPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            var standingAngle = mainCollision.Value.SurfaceNormal.GetAngleWithWorldGround();
            
            return standingAngle < Components.Config.MaxJumpSurfaceAngle && Components.Input.Jump.IsDown;
        }
    }
}