using Archery.Character.Animation;

namespace Archery.Character.StateMachine.States
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