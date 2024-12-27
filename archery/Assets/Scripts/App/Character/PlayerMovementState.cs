using MyLibs.Movement;

namespace Game.Libraries.App.Character.Movement.StateMachine
{
    public abstract class PlayerMovementState : IMovementState
    {
        protected PlayerComponentsHolder Components { get; private set; }

        public void Initialize(IPlayerComponentsHolder playerComponentsHolder)
        {
            Components = (PlayerComponentsHolder)playerComponentsHolder;
        }

        public virtual void Update() { }
        public virtual void OnExit() { }
        public virtual void OnEnter() { }
    }

    public abstract class PlayerMovementStateTransition : MovementStateTransition
    {
        protected const int TopPriority = 100; 
        protected const int HighPriority = 50; 
        protected const int CommonPriority = 0; 
        protected const int LowPriority = -50; 
        protected const int LowestPriority = -100; 
        
        protected PlayerComponentsHolder Components { get; private set; }

        public sealed override void Initialize(IPlayerComponentsHolder playerComponentsHolder)
        {
            Components = (PlayerComponentsHolder)playerComponentsHolder;
        }
    }
}