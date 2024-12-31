using Archery.Character.Movement.StateMachine;

namespace Archery.Character
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