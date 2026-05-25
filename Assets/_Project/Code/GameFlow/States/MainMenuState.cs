using Minesweeper.Core;
using Minesweeper.Screens;

namespace Minesweeper.GameFlow
{
    public class MainMenuState : IState
    {
        private readonly IScreenManager _screenManager;
        private readonly MainMenuView _view;
        private readonly GameStateMachine _stateMachine;

        public MainMenuState(
            IScreenManager screenManager,
            MainMenuView view,
            GameStateMachine stateMachine)
        {
            _screenManager = screenManager;
            _view = view;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _view.StartClicked += OnStart;
            _screenManager.HideAll();
            _screenManager.Show<MainMenuView>();
        }

        public void Exit()
        {
            _view.StartClicked -= OnStart;
        }

        private void OnStart() => _stateMachine.ChangeState<GameplaySetupState>();
    }
}