using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Core
{
    [RequireComponent(typeof(Canvas))]
    public abstract class BaseScreenView : MonoBehaviour, IScreen
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GraphicRaycaster _raycaster;

        protected virtual void Awake()
        {
            if (_canvas == null) _canvas = GetComponent<Canvas>();
            if (_raycaster == null) _raycaster = GetComponent<GraphicRaycaster>();
        }

        public virtual void Show()
        {
            EnsureActive();
            if (_canvas != null) _canvas.enabled = true;
            if (_raycaster != null) _raycaster.enabled = true;
        }

        public virtual void Hide()
        {
            EnsureActive();
            if (_canvas != null) _canvas.enabled = false;
            if (_raycaster != null) _raycaster.enabled = false;
        }

        private void EnsureActive()
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
        }
    }
}