using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibs.Movement
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
        private readonly List<IMovementStateTransition> _transitions = new();
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
            _transitions.Add(transition);
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
            
            foreach (var transition in _transitions)
            {
                transition.Initialize(_playerComponentsHolder);
            }
            
            return new MovementStateMachine(_states.Values.ToList(), _transitions, _initialState);
        }
    }
}