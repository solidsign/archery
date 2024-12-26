namespace MyLibs.Movement
{
    public interface IMovementState : IPlayerComponentsHolderDependent
    {
        void Update();
        void OnExit();
        void OnEnter();
    }
}