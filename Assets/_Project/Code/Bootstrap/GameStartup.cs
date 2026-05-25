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
            _field.GameLost += OnGameLost;
            _field.PrepareNewGame();
            _camera.FitToField(_field.Cols, _field.Rows);
        }

        private void OnGameLost()
        {
            Debug.Log("[Minesweeper] Game lost");
        }
    }
}