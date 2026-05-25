using Minesweeper.Core;
using Minesweeper.Gameplay;
using UnityEngine;

namespace Minesweeper.GameFlow
{
    public class GameplayState : IState
    {
        private readonly FieldController _field;
        private readonly GameInputController _input;
        private readonly GameSession _session;

        public GameplayState(
            FieldController field,
            GameInputController input,
            GameSession session)
        {
            _field = field;
            _input = input;
            _session = session;
        }

        public void Enter()
        {
            _input.Enable();
            _field.GameWon += OnGameWon;
            _field.GameLost += OnGameLost;
        }

        public void Exit()
        {
            _input.Disable();
            _field.GameWon -= OnGameWon;
            _field.GameLost -= OnGameLost;
        }

        private void OnGameWon()
        {
            _session.SetResult(true);
            Debug.Log("[Minesweeper] Game won");
        }

        private void OnGameLost()
        {
            _session.SetResult(false);
            Debug.Log("[Minesweeper] Game lost");
        }
    }
}