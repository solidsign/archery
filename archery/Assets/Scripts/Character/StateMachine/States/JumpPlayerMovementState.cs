using System.Linq;
using Archery.Character.Animation;
using Archery.Utils;
using UnityEngine;

namespace Archery.Character.StateMachine.States
{
    public class JumpPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.Jump);
            ApplyPreservedSpeed();
            Components.Movement.Jobs.Add(new JumpMovementJob(Components));
        }
        
        private void ApplyPreservedSpeed()
        {
            Components.Movement.Move(Components.Properties.Velocity * Components.Services.Time.DeltaTime);
        }
    }

    public class JumpMovementJob : IPlayerMovementJob
    {
        private readonly PlayerComponentsHolder _components;
            
        private float _currentJumpTime = 0f;

        private CharacterConfig Config => _components.Config;
            
        public JumpMovementJob(PlayerComponentsHolder components)
        {
            _components = components;
        }

        public bool IsDone { get; private set; } = false;
        public void Update()
        {
            var newJumpTime = Mathf.Clamp(_currentJumpTime + _components.Services.Time.DeltaTime, 0f, Config.MaxJumpTime);
            var normalizedHeightDelta = Config.JumpCurve.Evaluate(newJumpTime) - Config.JumpCurve.Evaluate(_currentJumpTime);
            _components.Movement.Move(Vector3.up * normalizedHeightDelta * Config.MaxJumpHeight);
            _currentJumpTime = newJumpTime;

            var hitTop = _components.Collisions.GetCollisions().Any(x =>
                x.SurfaceNormal.GetAngleWithWorldGround() < Config.MaxStopJumpHitSurfaceAngle && 
                x.SurfaceNormal.GetAngleWithWorldGround() > Config.MinStopJumpHitSurfaceAngle);

            if (hitTop || _currentJumpTime >= Config.MaxJumpTime || _currentJumpTime >= Config.MinJumpTime && _components.Input.Jump.IsPressed is false)
            {
                IsDone = true;
            }
        }
    }
}