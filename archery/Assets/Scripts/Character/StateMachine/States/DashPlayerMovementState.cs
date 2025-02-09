using Archery.Utils;
using UnityEngine;

namespace Archery.Character.StateMachine.States
{
    public class DashPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            ApplyPreservedSpeed();
            var inputDir = Components.GetNormalizedInputMoveDirectionWorld();
            if (inputDir.magnitude < 0.1f) inputDir = Components.Input.NormalizedLookDirection.ProjectOnWorldGround().normalized;
            Components.Movement.Jobs.Add(new Job(Components, inputDir));
            Components.UtilityJobs.Add(new SimpleCooldownJob<DashPlayerMovementState>(Components.Config.DashCooldown, Components));
        }
        
        private void ApplyPreservedSpeed()
        {
            Components.Movement.Move(Components.Properties.Velocity * Components.Services.Time.DeltaTime);
        }
        
        public class Job : IPlayerMovementJob
        {
            private readonly PlayerComponentsHolder _components;
            private readonly Vector3 _direction;

            private float _currentDashTime = 0f;

            private CharacterConfig Config => _components.Config;
            
            public Job(PlayerComponentsHolder components, Vector3 direction)
            {
                _components = components;
                _direction = direction;
            }

            public bool IsDone { get; private set; } = false;
            public void Update()
            {
                var newDashTime = Mathf.Clamp(_currentDashTime + _components.Services.Time.DeltaTime, 0f, Config.MaxDashTime);
                var normalizedMoveDelta = Config.DashCurve.Evaluate(newDashTime) - Config.DashCurve.Evaluate(_currentDashTime);
                _components.Movement.Move( _direction * normalizedMoveDelta * Config.MaxDashLength);
                _currentDashTime = newDashTime;

                if (_currentDashTime >= Config.MaxDashTime && _components.Input.Dash.IsPressed is false)
                {
                    IsDone = true;
                }
            }
        }
    }
}