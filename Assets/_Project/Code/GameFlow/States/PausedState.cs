using Minesweeper.Core;
using Minesweeper.Screens;

namespace Minesweeper.GameFlow
{
    public class PausedState : IState
    {
        private readonly IScreenManager _screenManager;
        private readonly PauseView _view;
        private readonly GameStateMachine _stateMachine;

        public PausedState(
            IScreenManager screenManager,
            PauseView view,
            GameStateMachine stateMachine)
        {
            _screenManager = screenManager;
            _view = view;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _view.RestartClicked += OnRestart;
            _view.ContinueClicked += OnContinue;
            _view.ExitClicked += OnExit;
            _screenManager.Show<PauseView>();
        }

        public void Exit()
        {
            _view.RestartClicked -= OnRestart;
            _view.ContinueClicked -= OnContinue;
            _view.ExitClicked -= OnExit;
            _screenManager.Hide<PauseView>();
        }

        private void OnRestart() => _stateMachine.ChangeState<GameplaySetupState>();
        private void OnContinue() => _stateMachine.ChangeState<GameplayState>();
        private void OnExit() => _stateMachine.ChangeState<MainMenuState>();
    }
}