using System;
using System.Linq;
using Archery.Character.Animation;
using Archery.Utils;
using UnityEngine;

namespace Archery.Character.StateMachine.States
{
    public class WallJumpPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.WallJump);
            ApplyPreservedSpeed();
            if (Components.Collisions.TryGetCurrentMainStickyCollision(out var collision) is false)
                throw new Exception($"Collision was null on entering wall jump state");
            Components.Movement.Jobs.Add(new WallJumpMovementJob(Components, collision.SurfaceNormal));
        }
        
        private void ApplyPreservedSpeed()
        {
            Components.Movement.Move(Components.Properties.Velocity * Components.Services.Time.DeltaTime);
        }
    }

    public class WallJumpMovementJob : IPlayerMovementJob
    {
        private readonly PlayerComponentsHolder _components;
        private readonly Vector3 _horizontalJumpDirection;

        private float _currentJumpTime = 0f;

        private CharacterConfig Config => _components.Config;
            
        public WallJumpMovementJob(PlayerComponentsHolder components, Vector3 horizontalJumpDirection)
        {
            _components = components;
            _horizontalJumpDirection = horizontalJumpDirection;
        }

        public bool IsDone { get; private set; } = false;
        public void Update()
        {
            var newJumpTime = _currentJumpTime + _components.Services.Time.DeltaTime;
            var normalizedVerticalDelta = Config.VerticalWallJumpCurve.Evaluate(newJumpTime) - Config.VerticalWallJumpCurve.Evaluate(_currentJumpTime);
            var normalizedHorizontalDelta = Config.HorizontalWallJumpCurve.Evaluate(newJumpTime) - Config.HorizontalWallJumpCurve.Evaluate(_currentJumpTime);
            _components.Movement.Move(MathConstants.WorldGroundNormal * (normalizedVerticalDelta * Config.MaxVerticalWallJumpHeight));
            _components.Movement.Move(_horizontalJumpDirection * (normalizedHorizontalDelta * Config.MaxHorizontalWallJumpHeight));
            _currentJumpTime = newJumpTime;

            var hitNonProjectile = _components.Collisions.GetCollisions().Any(x => x.ProjectileInfo.HasValue);

            if (hitNonProjectile || 
                _currentJumpTime >= Mathf.Max(Config.MaxVerticalWallJumpTime, Config.MaxHorizontalWallJumpTime) || 
                _currentJumpTime >= Mathf.Max(Config.MinVerticalWallJumpTime, Config.MinHorizontalWallJumpTime) && 
                _components.Input.Jump.IsPressed is false)
            {
                IsDone = true;
            }
        }
    }
}