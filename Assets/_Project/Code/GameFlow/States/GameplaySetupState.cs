using Minesweeper.Core;
using Minesweeper.Gameplay;
using Minesweeper.Screens;

namespace Minesweeper.GameFlow
{
    public class GameplaySetupState : IState
    {
        private readonly IScreenManager _screenManager;
        private readonly FieldController _field;
        private readonly CameraController _camera;
        private readonly GameInputController _input;
        private readonly GameStateMachine _stateMachine;

        public GameplaySetupState(
            IScreenManager screenManager,
            FieldController field,
            CameraController camera,
            GameInputController input,
            GameStateMachine stateMachine)
        {
            _screenManager = screenManager;
            _field = field;
            _camera = camera;
            _input = input;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _screenManager.HideAll();
            _screenManager.Show<GameView>();

            _field.PrepareNewGame();
            _camera.FitToField(_field.Cols, _field.Rows);
            _input.Enable();

            _stateMachine.ChangeState<GameplayState>();
        }

        public void Exit() { }
    }
}