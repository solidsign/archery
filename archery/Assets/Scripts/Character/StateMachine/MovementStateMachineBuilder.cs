using System;
using System.Collections.Generic;
using System.Linq;

namespace Archery.Character.StateMachine
{
    public interface IPlayerComponentsHolder { }

    public interface IPlayerComponentsHolderDependent
    {
        void Initialize(IPlayerComponentsHolder playerComponentsHolder);
    }
    
    public class MovementStateMachineBuilder
    {
        private readonly IPlayerComponentsHolder _playerComponentsHolder;
        private readonly Dictionary<Type, IMovementState> _states = new();
        private readonly Dictionary<Type /*toState*/, IMovementStateTransition> _transitions = new();
        private IMovementState _initialState;

        public MovementStateMachineBuilder(IPlayerComponentsHolder playerComponentsHolder)
        {
            _playerComponentsHolder = playerComponentsHolder;
        }

        public MovementStateMachineBuilder AddInitialState(IMovementState state)
        {
            _initialState = state;
            return AddState(state);
        }
        
        public MovementStateMachineBuilder AddState(IMovementState state)
        {
            _states.Add(state.GetType(), state);
            return this;
        }
        
        public MovementStateMachineBuilder AddTransition<TToState>(IMovementStateTransition transition) where TToState : IMovementState
        {
            transition.InitializeNextState(_states[typeof(TToState)]);
            _transitions.Add(typeof(TToState), transition);
            return this;
        }
        
        public IMovementStateMachine Build()
        {
            if (_initialState == null) throw new Exception($"Initial state can not be null");
            if (_states.Count == 0) throw new Exception($"States can not be empty");
            if (_transitions.Count == 0) throw new Exception($"Transitions can not be empty");
            
            foreach (var (_, movementState) in _states)
            {
                movementState.Initialize(_playerComponentsHolder);
            }

            var statesWithoutTransitions = new HashSet<Type>(_states.Keys);
            foreach (var (toStateOfType, transition) in _transitions)
            {
                transition.Initialize(_playerComponentsHolder);
                statesWithoutTransitions.Remove(toStateOfType);
            }

            if (statesWithoutTransitions.Count > 0) throw new Exception($"States without transitions: {string.Join(", ", statesWithoutTransitions)}");

            
            return new MovementStateMachine(_transitions.Values.ToArray(), _initialState);
        }
    }
}