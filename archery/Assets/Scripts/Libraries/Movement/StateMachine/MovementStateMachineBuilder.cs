using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibs.Movement
{
    public class MovementStateMachineBuilder
    {
        private readonly Dictionary<Type, IMovementState> _states = new();
        private readonly List<IMovementStateTransition> _transitions = new();
        private IMovementState _initialState;

        public MovementStateMachineBuilder() { }

        public MovementStateMachineBuilder AddInitialState<T>(IMovementState state) where T : IMovementState
        {
            _initialState = state;
            return AddState<T>(state);
        }
        
        public MovementStateMachineBuilder AddState<T>(IMovementState state) where T : IMovementState
        {
            _states.Add(typeof(T), state);
            return this;
        }
        
        public MovementStateMachineBuilder AddTransition<TToState>(IMovementStateTransition transition) where TToState : IMovementState
        {
            transition.InitializeNextState(_states[typeof(TToState)]);
            _transitions.Add(transition);
            return this;
        }
        
        public IMovementStateMachine Build()
        {
            if (_initialState == null) throw new Exception($"Initial state can not be null");
            if (_states.Count == 0) throw new Exception($"States can not be empty");
            if (_transitions.Count == 0) throw new Exception($"Transitions can not be empty");
            
            return new MovementStateMachine(_states.Values.ToList(), _transitions, _initialState);
        }
    }
}