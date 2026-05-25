using System;
using Minesweeper.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Screens
{
    public class PauseView : BaseScreenView
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;

        public event Action RestartClicked;
        public event Action ContinueClicked;
        public event Action ExitClicked;

        protected override void Awake()
        {
            base.Awake();
            _restartButton?.onClick.AddListener(OnRestartClicked);
            _continueButton?.onClick.AddListener(OnContinueClicked);
            _exitButton?.onClick.AddListener(OnExitClicked);
        }

        private void OnDestroy()
        {
            _restartButton?.onClick.RemoveListener(OnRestartClicked);
            _continueButton?.onClick.RemoveListener(OnContinueClicked);
            _exitButton?.onClick.RemoveListener(OnExitClicked);
        }

        private void OnRestartClicked() => RestartClicked?.Invoke();
        private void OnContinueClicked() => ContinueClicked?.Invoke();
        private void OnExitClicked() => ExitClicked?.Invoke();
    }
}