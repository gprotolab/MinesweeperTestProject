using UnityEngine;
using VContainer.Unity;

namespace Minesweeper.Bootstrap
{
    public class GameStartup : IStartable
    {
        public void Start()
        {
            Debug.Log("Game started");
        }
    }
}