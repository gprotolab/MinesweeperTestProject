using System;
using Minesweeper.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Screens
{
    public class GameOverView : BaseScreenView
    {
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        public event Action RestartClicked;
        public event Action ExitClicked;

        protected override void Awake()
        {
            base.Awake();
            _restartButton?.onClick.AddListener(OnRestartClicked);
            _exitButton?.onClick.AddListener(OnExitClicked);
        }

        private void OnDestroy()
        {
            _restartButton?.onClick.RemoveListener(OnRestartClicked);
            _exitButton?.onClick.RemoveListener(OnExitClicked);
        }

        public void SetMessage(string message) => _messageText.text = message;

        private void OnRestartClicked() => RestartClicked?.Invoke();
        private void OnExitClicked() => ExitClicked?.Invoke();
    }
}