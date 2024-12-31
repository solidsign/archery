using App.Character.Movement.StateMachine;
using UnityEngine;

namespace App.Character
{
    public class JumpPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            ApplyPreservedSpeed();
            Components.Movement.Jobs.Add(new Job(Components));
        }
        
        private void ApplyPreservedSpeed()
        {
            Components.Movement.Move(Components.Properties.Velocity * Components.App.Time.DeltaTime);
        }
        
        public class Job : IPlayerMovementJob
        {
            private readonly PlayerComponentsHolder _components;
            
            private float _currentJumpTime = 0f;

            private CharacterConfig Config => _components.Config;
            
            public Job(PlayerComponentsHolder components)
            {
                _components = components;
            }

            public bool IsDone { get; private set; } = false;
            public void Update()
            {
                var newJumpTime = Mathf.Clamp(_currentJumpTime + _components.App.Time.DeltaTime, 0f, Config.MaxJumpTime);
                var normalizedHeightDelta = Config.JumpCurve.Evaluate(newJumpTime) - Config.JumpCurve.Evaluate(_currentJumpTime);
                _components.Movement.Move(Vector3.up * normalizedHeightDelta * Config.MaxJumpHeight);
                _currentJumpTime = newJumpTime;

                if (_currentJumpTime >= Config.MaxJumpTime || _currentJumpTime >= Config.MinJumpTime &&
                    _components.Input.Jump.IsPressed is false)
                {
                    IsDone = true;
                }
            }
        }
    }
}