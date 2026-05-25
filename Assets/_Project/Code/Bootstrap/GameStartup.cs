using Minesweeper.Gameplay;
using UnityEngine;
using VContainer.Unity;

namespace Minesweeper.Bootstrap
{
    public class GameStartup : IStartable
    {
        private readonly FieldController _field;
        private readonly CameraController _camera;

        public GameStartup(FieldController field, CameraController camera)
        {
            _field = field;
            _camera = camera;
        }

        public void Start()
        {
            _field.PrepareNewGame();
            _camera.FitToField(_field.Cols, _field.Rows);
            Debug.Log($"[Minesweeper] Field {_field.Cols}x{_field.Rows} prepared");
        }
    }
}