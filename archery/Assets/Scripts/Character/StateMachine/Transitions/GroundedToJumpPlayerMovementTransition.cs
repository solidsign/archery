using UnityEngine;

namespace Archery.Character.StateMachine.Transitions
{
    public class GroundedToJumpPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => TopPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            var standingAngle = Vector3.Angle(Vector3.up, mainCollision.Value.SurfaceNormal);
            
            return standingAngle < Components.Config.MaxJumpSurfaceAngle && Components.Input.Jump.IsDown;
        }

        protected override void PerformTransitionInternal()
        {
        }
    }
}