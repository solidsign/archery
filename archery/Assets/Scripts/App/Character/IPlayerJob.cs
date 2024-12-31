namespace App.Character
{
    public interface IPlayerMovementJob : IPlayerJob {}
    public interface IPlayerJob
    {
        bool IsDone { get; }
        void Update();
    }
}