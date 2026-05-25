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

            if (!mouse.leftButton.wasPressedThisFrame) return;

            var screenPos = mouse.position.ReadValue();
            if (!_camera.TryScreenToCell(screenPos, out var cell)) return;

            _field.OpenCell(cell.x, cell.y);
        }
    }
}