using Minesweeper.Core;
using TMPro;
using UnityEngine;

namespace Minesweeper.Screens
{
    public class GameView : BaseScreenView
    {
        [SerializeField] private TMP_Text _timerText;

        public void SetTimer(int seconds)
        {
            _timerText.text = Mathf.Clamp(seconds, 0, 999).ToString("D3");
        }
    }
}