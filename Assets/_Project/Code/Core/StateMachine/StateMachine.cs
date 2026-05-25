using System;
using System.Collections.Generic;

namespace Minesweeper.Core
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IState> _states = new();

        public IState CurrentState { get; private set; }

        public void RegisterState<TState>(TState state) where TState : IState
        {
            _states[typeof(TState)] = state;
        }

        public void ChangeState<TState>() where TState : IState
        {
            if (!_states.TryGetValue(typeof(TState), out var nextState))
                throw new InvalidOperationException($"[StateMachine] State {typeof(TState).Name} is not registered.");

            CurrentState?.Exit();
            CurrentState = nextState;
            CurrentState.Enter();
        }

        public bool IsCurrentState<TState>() where TState : IState
        {
            return CurrentState is TState;
        }
    }
}