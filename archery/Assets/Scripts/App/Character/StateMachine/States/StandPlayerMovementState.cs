using App.Character.Movement.StateMachine;

namespace App.Character
{
    public class StandPlayerMovementState : PlayerMovementState
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Components.Animation.SetState(PlayerAnimationState.Stand);
        }
    }
}