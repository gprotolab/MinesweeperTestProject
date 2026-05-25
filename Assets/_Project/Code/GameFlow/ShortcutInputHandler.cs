using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Minesweeper.GameFlow
{
    public class ShortcutInputHandler : ITickable
    {
        private readonly GameStateMachine _stateMachine;

        private const Key ShortcutKey = Key.F2;

        public ShortcutInputHandler(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Tick()
        {
            var keyboard = Keyboard.current;
            if (keyboard == null) return;
            if (!keyboard[ShortcutKey].wasPressedThisFrame) return;
            if (_stateMachine.IsCurrentState<MainMenuState>()) return;

            _stateMachine.ChangeState<GameplaySetupState>();
        }
    }
}