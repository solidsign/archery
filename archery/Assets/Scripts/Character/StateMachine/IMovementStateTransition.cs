namespace Archery.Character.StateMachine
{
    public interface IMovementStateTransition : IPlayerComponentsHolderDependent
    {
        /// <summary>
        /// The higher the number, the higher the priority
        /// </summary>
        int Priority { get; }
        
        /// <summary>
        /// Checks if the transition can be performed
        /// </summary>
        /// <param name="currentState">Current state of the character FSM</param>
        /// <returns></returns>
        bool CanTransitionFrom(IMovementState currentState);
        
        /// <summary>
        /// Makes actions needed on transitioning to next state
        /// </summary>
        /// <returns>Next state</returns>
        IMovementState PerformTransition();
        
        /// <summary>
        /// Used to store next state when bulding transition. Is some kind of hack.
        /// </summary>
        /// <param name="nextState"></param>
        void InitializeNextState(IMovementState nextState);
    }

    public abstract class MovementStateTransition : IMovementStateTransition
    {
        public abstract int Priority { get; }
        
        private IMovementState _nextState;

        public void InitializeNextState(IMovementState nextState)
        {
            _nextState = nextState;
        }

        public abstract void Initialize(IPlayerComponentsHolder playerComponentsHolder);

        public abstract bool CanTransitionFrom(IMovementState currentState);

        public IMovementState PerformTransition()
        {
            PerformTransitionInternal();
            return _nextState;
        }

        protected abstract void PerformTransitionInternal();
    }
}