using Archery.Character.Animation;
using Archery.Character.Collisions;
using Archery.Utils;
using UnityEngine;

namespace Archery.Character.StateMachine.States
{
    public class HorizontalWallRunPlayerMovementState : PlayerMovementState
    {
        private Vector3 _runDirection;
        private SurfaceCollision _currentCollision;

        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.HorizontalWallRun);
        }

        private void UpdateCurrentRunDirection()
        {
            if (Components.Collisions.TryGetCurrentMainStickyCollision(out _currentCollision) is false) return;
            
            var horizontalWallAxis = Vector3.Cross(MathConstants.WorldGroundNormal, _currentCollision.SurfaceNormal).normalized;
            _runDirection = Vector3.Project(Components.Properties.Velocity, horizontalWallAxis).normalized;
        }

        public override void Update()
        {
            base.Update();
            UpdateCurrentRunDirection();
            Components.Movement.Move(_runDirection * Components.Services.Time.DeltaTime * Components.Config.HorizontalWallRunSpeed);
            Components.Movement.Move(-_currentCollision.SurfaceNormal * Components.Config.HorizontalWallRunGripSpeed);
        }
    }
}