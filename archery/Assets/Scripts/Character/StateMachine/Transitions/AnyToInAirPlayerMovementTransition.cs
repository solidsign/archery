using Archery.Character.StateMachine.States;

namespace Archery.Character.StateMachine.Transitions
{
    public class AnyToInAirPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => LowestPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            return currentState is not InAirPlayerMovementState && Components.Collisions.GetCurrentMainStickyCollision().HasValue is false;
        }

        protected override void PerformTransitionInternal()
        {
        }
    }
}