using Minesweeper.Screens;
using UnityEngine;
using VContainer.Unity;

namespace Minesweeper.Gameplay
{
    public class TimerController : ITickable
    {
        private readonly GameView _view;
        private float _accumulator;

        public int ElapsedSeconds { get; private set; }
        public bool IsRunning { get; private set; }

        public TimerController(GameView view)
        {
            _view = view;
        }

        public void Start() => IsRunning = true;
        public void Pause() => IsRunning = false;

        public void Reset()
        {
            IsRunning = false;
            _accumulator = 0f;
            ElapsedSeconds = 0;
            _view.SetTimer(0);
        }

        public void Tick()
        {
            if (!IsRunning) return;

            _accumulator += Time.deltaTime;
            while (_accumulator >= 1f)
            {
                _accumulator -= 1f;
                ElapsedSeconds++;
                _view.SetTimer(ElapsedSeconds);
            }
        }
    }
}