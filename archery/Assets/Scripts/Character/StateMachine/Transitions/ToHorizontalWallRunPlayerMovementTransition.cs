using Archery.Utils;
using UnityEngine;

namespace Archery.Character.StateMachine.Transitions
{
    public class ToHorizontalWallRunPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => HighPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            if (Components.Input.NormalizedForwardMovement < Components.Config.MinForwardMovementForWallRun) return false;
            if (Components.Collisions.TryGetCurrentMainStickyCollision(out var mainCollision) is false) return false;
            
            var collisionAngle = mainCollision.SurfaceNormal.GetAngleWithWorldGround();

            if (collisionAngle < Components.Config.MinHorizontalWallRunSurfaceAngle ||
                collisionAngle > Components.Config.MaxHorizontalWallRunSurfaceAngle) return false;
            
            // проверить, что есть скорость вдоль стены
            var possibleWallRunDirection = Vector3.Cross(MathConstants.WorldGroundNormal, mainCollision.SurfaceNormal).normalized;

            var velocityProjection = Vector3.Project(Components.Properties.Velocity.Value, possibleWallRunDirection).magnitude;
            if (velocityProjection < Components.Config.MinProjectionVelocityForHorizontalWallRun) return false;

            var lookProjectionRation = Vector3.Project(Components.Input.NormalizedLookDirection, possibleWallRunDirection).magnitude;
            return lookProjectionRation > Components.Config.MinLookDirectionForHorizontalWallRun;
        }
    }
}