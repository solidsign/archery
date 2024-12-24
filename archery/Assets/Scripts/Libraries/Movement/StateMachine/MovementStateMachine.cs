using System.Collections.Generic;
using System.Linq;

namespace MyLibs.Movement
{
    internal class MovementStateMachine : IMovementStateMachine
    {
        private readonly IReadOnlyList<IMovementState> _states;
        private readonly IReadOnlyList<IMovementStateTransition> _transitions;
        
        private IMovementState _currentState;

        public MovementStateMachine(IReadOnlyList<IMovementState> states, IReadOnlyList<IMovementStateTransition> transitions, IMovementState initialState)
        {
            _states = states;
            _transitions = transitions;
            _currentState = initialState;
        }
        
        public void Update()
        {
            var possibleTransitions = _transitions.Where(x => x.CanTransitionFrom(_currentState)).ToList();
            if (possibleTransitions.Any())
            {
                _currentState.OnExit();
                _currentState = possibleTransitions.OrderBy(x => x.Priority).First().PerformTransition();
                _currentState.OnEnter();
            }
            
            _currentState.Update();
        }
    }
}