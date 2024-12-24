using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibs.Movement
{
    public class MovementStateMachineBuilder
    {
        private readonly Dictionary<Type, IMovementState> _states = new();
        private readonly List<IMovementStateTransition> _transitions = new();

        public MovementStateMachineBuilder() { }
        
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
        
        public IMovementStateMachine Build() => new MovementStateMachine(_states.Values.ToList(), _transitions);
    }
}