using Archery.Utils;
using UnityEngine;

namespace Archery.Character.StateMachine.Transitions
{
    public class AnyToRunPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => CommonPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            var mainCollision = Components.Collisions.GetCurrentMainStickyCollision();
            if (mainCollision.HasValue is false) return false;
            
            var standingAngle = Vector3.Angle(Vector3.up, mainCollision.Value.SurfaceNormal);
            
            return standingAngle < Components.Config.MaxStandAngle &&
                   (Components.Input.NormalizedRightMovement.Abs() > 0f ||
                    Components.Input.NormalizedForwardMovement.Abs() > 0f);
        }
        protected override void PerformTransitionInternal()
        {
        }
    }
}