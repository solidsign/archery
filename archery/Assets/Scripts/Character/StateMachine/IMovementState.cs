namespace Archery.Character.StateMachine
{
    public interface IReadOnlyMovementState {}
    public interface IMovementState : IPlayerComponentsHolderDependent, IReadOnlyMovementState
    {
        void Update();
        void OnExit();
        void OnEnter();
    }
}