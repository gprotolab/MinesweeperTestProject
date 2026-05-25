using Minesweeper.GameFlow;
using VContainer.Unity;

namespace Minesweeper.Bootstrap
{
    public class GameStartup : IStartable
    {
        private readonly GameStateMachine _stateMachine;
        private readonly MainMenuState _mainMenuState;
        private readonly GameplaySetupState _gameplaySetupState;
        private readonly GameplayState _gameplayState;

        public GameStartup(
            GameStateMachine stateMachine,
            MainMenuState mainMenuState,
            GameplaySetupState gameplaySetupState,
            GameplayState gameplayState)
        {
            _stateMachine = stateMachine;
            _mainMenuState = mainMenuState;
            _gameplaySetupState = gameplaySetupState;
            _gameplayState = gameplayState;
        }

        public void Start()
        {
            _stateMachine.RegisterState(_mainMenuState);
            _stateMachine.RegisterState(_gameplaySetupState);
            _stateMachine.RegisterState(_gameplayState);

            _stateMachine.ChangeState<MainMenuState>();
        }
    }
}