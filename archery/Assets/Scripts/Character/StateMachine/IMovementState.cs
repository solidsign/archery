namespace Archery.Character.StateMachine
{
    public interface IMovementState : IPlayerComponentsHolderDependent
    {
        void Update();
        void OnExit();
        void OnEnter();
    }
}