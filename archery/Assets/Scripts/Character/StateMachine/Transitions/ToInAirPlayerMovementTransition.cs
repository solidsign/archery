namespace Archery.Character.StateMachine.Transitions
{
    public class ToInAirPlayerMovementTransition : PlayerMovementStateTransition
    {
        public override int Priority => LowestPriority;
        public override bool CanTransitionFrom(IMovementState currentState)
        {
            return Components.Collisions.GetCurrentMainStickyCollision().HasValue is false;
        }
    }
}