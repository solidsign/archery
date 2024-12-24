namespace MyLibs.Movement
{
    public interface IMovementStateTransition
    {
        int Priority { get; }
        bool CanTransitionFrom(IMovementState currentState);
        IMovementState PerformTransition();
        void InitializeNextState(IMovementState nextState);
    }
}