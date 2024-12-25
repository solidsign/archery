using MyLibs.Core;

namespace MyLibs.Movement
{
    public interface IMovementState : IUpdatable, IPlayerComponentsHolderDependent
    {
        void OnExit();
        void OnEnter();
    }
}