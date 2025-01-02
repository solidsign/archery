namespace Archery.Character
{
    public interface IAnimationController<in TState>
    {
        void SetState(TState state);
    }
}