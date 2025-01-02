using System.Collections.Generic;
using System.Linq;

namespace Archery.Character.StateMachine
{
    internal class MovementStateMachine : IMovementStateMachine
    {
        private readonly IReadOnlyList<IMovementStateTransition> _transitions;
        
        private IMovementState _currentState;

        public MovementStateMachine(IReadOnlyList<IMovementStateTransition> transitions, IMovementState initialState)
        {
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