using Minesweeper.Core;
using Minesweeper.Gameplay;
using Minesweeper.Screens;

namespace Minesweeper.GameFlow
{
    public class GameplayState : IState
    {
        private readonly FieldController _field;
        private readonly GameInputController _input;
        private readonly GameSession _session;
        private readonly GameStateMachine _stateMachine;
        private readonly GameView _view;

        public GameplayState(
            FieldController field,
            GameInputController input,
            GameSession session,
            GameStateMachine stateMachine,
            GameView view)
        {
            _field = field;
            _input = input;
            _session = session;
            _stateMachine = stateMachine;
            _view = view;
        }

        public void Enter()
        {
            _input.Enable();
            _view.PauseButtonClicked += OnPauseClicked;
            _field.GameWon += OnGameWon;
            _field.GameLost += OnGameLost;
        }

        public void Exit()
        {
            _input.Disable();
            _view.PauseButtonClicked -= OnPauseClicked;
            _field.GameWon -= OnGameWon;
            _field.GameLost -= OnGameLost;
        }

        private void OnPauseClicked() => _stateMachine.ChangeState<PausedState>();

        private void OnGameWon()
        {
            _session.SetResult(true);
            _stateMachine.ChangeState<GameOverState>();
        }

        private void OnGameLost()
        {
            _session.SetResult(false);
            _stateMachine.ChangeState<GameOverState>();
        }
    }
}