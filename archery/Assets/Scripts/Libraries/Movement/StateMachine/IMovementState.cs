using MyLibs.Core;

namespace MyLibs.Movement
{
    public interface IMovementState : IUpdatable
    {
        void OnExit();
        void OnEnter();
    }
}