using Archery.Character.Animation;

namespace Archery.Character.StateMachine.States
{
    public class RunPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.Run);
        }

        public override void Update()
        {
            base.Update();

            var moveDirection = Components.GetNormalizedInputMoveDirection();
            var velocity = moveDirection * Components.Config.RunSpeed;
            var moveDelta = velocity * Components.Services.Time.DeltaTime;
            
            Components.Movement.Move(moveDelta);
        }
    }
}