namespace Archery.Character.StateMachine
{
    public interface IMovementStateMachine
    {
        IReadOnlyMovementState CurrentState { get; }
        void Update();
    }
}