using Minesweeper.Gameplay;
using UnityEngine;
using VContainer.Unity;

namespace Minesweeper.Bootstrap
{
    public class GameStartup : IStartable
    {
        private readonly FieldController _field;

        public GameStartup(FieldController field)
        {
            _field = field;
        }

        public void Start()
        {
            _field.PrepareNewGame();
            Debug.Log($"Field {_field.Cols}x{_field.Rows} prepared");
        }
    }
}