using MyLibs.Movement;

namespace Game.Libraries.App.Character.Movement.StateMachine
{
    public abstract class PlayerMovementState : IMovementState
    {
        protected PlayerComponentsHolder PlayerComponentsHolder { get; private set; }

        public void Initialize(IPlayerComponentsHolder playerComponentsHolder)
        {
            PlayerComponentsHolder = (PlayerComponentsHolder)playerComponentsHolder;
        }

        public virtual void Update() { }
        public virtual void OnExit() { }
        public virtual void OnEnter() { }
    }

    public abstract class PlayerMovementStateTransition : MovementStateTransition
    {
        protected PlayerComponentsHolder PlayerComponentsHolder { get; private set; }

        public sealed override void Initialize(IPlayerComponentsHolder playerComponentsHolder)
        {
            PlayerComponentsHolder = (PlayerComponentsHolder)playerComponentsHolder;
        }
    }
}