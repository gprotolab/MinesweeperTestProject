using UnityEngine;

namespace Minesweeper.Gameplay
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _closedSprite;
        [SerializeField] private SpriteRenderer _openedSprite;

        public void SetState(CellVisualState state)
        {
            bool isClosed = state == CellVisualState.Closed;
            bool isOpened = state == CellVisualState.Opened;

            if (_closedSprite != null) _closedSprite.enabled = isClosed;
            if (_openedSprite != null) _openedSprite.enabled = isOpened;
        }
    }
}