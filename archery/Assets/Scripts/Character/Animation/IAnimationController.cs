namespace Archery.Character.Animation
{
    public interface IAnimationController<in TState>
    {
        void SetState(TState state);
    }
}