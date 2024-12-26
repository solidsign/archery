using Game.Libraries.App.Character.Movement.StateMachine;
using MyLibs.Core;
using UnityEngine;

namespace Game.Libraries.App.Character
{
    public class RunPlayerMovementState : PlayerMovementState
    {
        private readonly ITimeProvider _time;

        public RunPlayerMovementState(ITimeProvider time)
        {
            _time = time;
        }
        
        public override void Update()
        {
            base.Update();

            var look = Components.Input.NormalizedLookDirection;
            var forward = Vector3.ProjectOnPlane(look, Vector3.up).normalized;
            var right = Vector3.Cross(Vector3.up, forward);
            var moveDirection = (forward * Components.Input.NormalizedForwardMovement + right * Components.Input.NormalizedRightMovement).normalized;
            var velocity = moveDirection * Components.Config.RunSpeed;
            var moveDelta = velocity * _time.DeltaTime;
            
            Components.Movement.Move(moveDelta);
        }
    }
}