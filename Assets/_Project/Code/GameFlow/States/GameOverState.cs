using Minesweeper.Core;
using Minesweeper.Screens;

namespace Minesweeper.GameFlow
{
    public class GameOverState : IState
    {
        private readonly IScreenManager _screenManager;
        private readonly GameOverView _view;
        private readonly GameSession _session;
        private readonly GameStateMachine _stateMachine;

        public GameOverState(
            IScreenManager screenManager,
            GameOverView view,
            GameSession session,
            GameStateMachine stateMachine)
        {
            _screenManager = screenManager;
            _view = view;
            _session = session;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _view.RestartClicked += OnRestart;
            _view.ExitClicked += OnExit;
            _view.SetMessage(_session.IsWon ? "You won!" : "Game over");
            _screenManager.Show<GameOverView>();
        }

        public void Exit()
        {
            _view.RestartClicked -= OnRestart;
            _view.ExitClicked -= OnExit;
            _screenManager.Hide<GameOverView>();
        }

        private void OnRestart() => _stateMachine.ChangeState<GameplaySetupState>();
        private void OnExit() => _stateMachine.ChangeState<MainMenuState>();
    }
}