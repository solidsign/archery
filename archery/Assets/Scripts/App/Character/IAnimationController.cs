namespace App.Character
{
    public interface IAnimationController<in TState>
    {
        void SetState(TState state);
    }
}