using System;
using Minesweeper.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Screens
{
    public class MainMenuView : BaseScreenView
    {
        [SerializeField] private Button _startButton;

        public event Action StartClicked;

        protected override void Awake()
        {
            base.Awake();
            _startButton?.onClick.AddListener(OnStartClicked);
        }

        private void OnDestroy()
        {
            _startButton?.onClick.RemoveListener(OnStartClicked);
        }

        private void OnStartClicked() => StartClicked?.Invoke();
    }
}