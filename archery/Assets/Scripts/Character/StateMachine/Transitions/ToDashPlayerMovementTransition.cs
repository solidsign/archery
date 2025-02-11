using Archery.Character.StateMachine.States;

namespace Archery.Character.StateMachine.Transitions
{
    public class ToDashPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => TopPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            return Components.Input.Dash.IsDown && Components.UtilityJobs.HasJob(x => x is DashCooldownJob) is false;
        }
    }
}