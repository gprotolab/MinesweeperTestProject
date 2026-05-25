using TMPro;
using UnityEngine;

namespace Minesweeper.Gameplay
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _closedSprite;
        [SerializeField] private SpriteRenderer _openedSprite;
        [SerializeField] private SpriteRenderer _flagSprite;
        [SerializeField] private SpriteRenderer _mineSprite;
        [SerializeField] private TMP_Text _numberLabel;

        public void SetState(CellVisualState state, int neighbourMines)
        {
            bool isClosed = state == CellVisualState.Closed;
            bool isFlagged = state == CellVisualState.Flagged;
            bool isOpened = state == CellVisualState.Opened;
            bool isMine = state == CellVisualState.Mine;

            if (_closedSprite != null) _closedSprite.enabled = isClosed || isFlagged;
            if (_openedSprite != null) _openedSprite.enabled = isOpened || isMine;
            if (_flagSprite != null) _flagSprite.enabled = isFlagged;
            if (_mineSprite != null) _mineSprite.enabled = isMine;

            if (_numberLabel != null)
            {
                bool showNumber = isOpened && neighbourMines > 0;
                _numberLabel.gameObject.SetActive(showNumber);
                if (showNumber)
                    _numberLabel.text = neighbourMines.ToString();
            }
        }
    }
}