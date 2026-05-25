using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Minesweeper.Gameplay
{
    public class GameInputController : ITickable
    {
        private readonly FieldController _field;
        private readonly CameraController _camera;

        public GameInputController(FieldController field, CameraController camera)
        {
            _field = field;
            _camera = camera;
        }

        public void Tick()
        {
            var mouse = Mouse.current;
            if (mouse == null) return;

            bool left = mouse.leftButton.wasPressedThisFrame;
            bool right = mouse.rightButton.wasPressedThisFrame;
            if (!left && !right) return;

            var screenPos = mouse.position.ReadValue();
            if (!_camera.TryScreenToCell(screenPos, out var cell)) return;

            if (left) _field.OpenCell(cell.x, cell.y);
            else _field.ToggleFlag(cell.x, cell.y);
        }
    }
}