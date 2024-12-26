using Game.Libraries.App.Character.Movement.StateMachine;

namespace Game.Libraries.App.Character
{
    public class RunPlayerMovementState : PlayerMovementState
    {
        public override void Update()
        {
            base.Update();

            var moveDirection = Components.GetNormalizedInputMoveDirection();
            var velocity = moveDirection * Components.Config.RunSpeed;
            var moveDelta = velocity * Components.App.Time.DeltaTime;
            
            Components.Movement.Move(moveDelta);
        }
    }
}