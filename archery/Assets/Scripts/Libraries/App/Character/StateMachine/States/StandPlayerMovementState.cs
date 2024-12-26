using Game.Libraries.App.Character.Movement.StateMachine;

namespace Game.Libraries.App.Character
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