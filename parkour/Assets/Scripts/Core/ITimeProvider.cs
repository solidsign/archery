namespace Game.Core
{
    public interface ITimeProvider
    {
        public long Tick { get; }
        public float DeltaTime { get; }
    }
}