namespace Archery.Character.StateMachine.States
{
    public class CrouchPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.Crouch);
        }
        
        public override void Update()
        {
            base.Update();
            
            var moveDirection = Components.GetNormalizedInputMoveDirection();
            var velocity = moveDirection * Components.Config.CrouchSpeed;
            var moveDelta = velocity * Components.Services.Time.DeltaTime;
            
            Components.Movement.Move(moveDelta);
        }
    }
}