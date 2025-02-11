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
            if (Components.Movement.Jobs.HasJob(x => x is HorizontalWallRunFallingJob) is false)
            {
                Components.Movement.Jobs.Add(new HorizontalWallRunFallingJob(Components));
            }
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
            Components.Movement.Move(_runDirection * (Components.Services.Time.DeltaTime * Components.Config.HorizontalWallRunSpeed));
            Components.Movement.Move(-_currentCollision.SurfaceNormal * Components.Config.HorizontalWallRunGripSpeed);
        }
    }

    public class HorizontalWallRunFallingJob : IPlayerMovementJob
    {
        private readonly PlayerComponentsHolder _components;
        private float _runningTime;

        public HorizontalWallRunFallingJob(PlayerComponentsHolder components)
        {
            _components = components;
        }

        public bool IsDone { get; private set; } = false;
        public void Update()
        {
            if (_components.Collisions.TryGetCurrentMainStickyCollision(out var currentCollision) is false) return;
            if (currentCollision.SurfaceNormal.GetAngleWithWorldGround() < _components.Config.MaxStandAngle)
            {
                IsDone = true;
                return;
            }
            
            _runningTime += _components.Services.Time.DeltaTime;
            var fallingVelocity = _components.Config.HorizontalWallFallingVelocityCurve.Evaluate(_runningTime / _components.Config.MaxHorizontalWallFallingTime) * _components.Config.MaxHorizontalWallFallingVelocity;
            var fallDirection = Vector3.down.ProjectOnCurrentGround(currentCollision);
            _components.Movement.Move(fallDirection * (fallingVelocity * _components.Services.Time.DeltaTime));
        }
    }
}