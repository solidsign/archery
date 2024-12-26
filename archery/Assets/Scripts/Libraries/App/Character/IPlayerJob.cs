namespace Game.Libraries.App.Character
{
    public interface IPlayerJob
    {
        bool IsDone { get; }
        void Update();
    }
}