namespace Game.Libraries.App.Character
{
    public interface IAnimationController<in TState>
    {
        void SetState(TState state);
    }
}