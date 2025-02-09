namespace Archery.Character
{
    public interface IPlayerMovementJob : IPlayerJob {}
    public interface IPlayerUtilityJob : IPlayerJob {}
    public interface IPlayerJob
    {
        bool IsDone { get; }
        void Update();
    }
    
    public class SimpleCooldownJob<T> : IPlayerUtilityJob
    {
        private float _timeLeft;
        private readonly PlayerComponentsHolder _components;

        public SimpleCooldownJob(float timeLeft, PlayerComponentsHolder components)
        {
            _timeLeft = timeLeft;
            _components = components;
        }
        
        public bool IsDone => _timeLeft <= 0;
        public void Update()
        {
            _timeLeft -= _components.Services.Time.DeltaTime;
        }
    }
}