using System;
using Minesweeper.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Screens
{
    public class GameView : BaseScreenView
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private Button _pauseButton;

        public event Action PauseButtonClicked;

        protected override void Awake()
        {
            base.Awake();
            _pauseButton?.onClick.AddListener(OnPauseButtonClicked);
        }

        private void OnDestroy()
        {
            _pauseButton?.onClick.RemoveListener(OnPauseButtonClicked);
        }

        public void SetTimer(int seconds)
        {
            _timerText.text = Mathf.Clamp(seconds, 0, 999).ToString("D3");
        }

        private void OnPauseButtonClicked() => PauseButtonClicked?.Invoke();
    }
}