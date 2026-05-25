using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace Minesweeper.Gameplay
{
    public class BoardViewController : IInitializable, IDisposable
    {
        private readonly FieldController _field;
        private readonly CellView _cellPrefab;
        private readonly Transform _root;

        private readonly List<CellView> _spawnedViews = new();

        public BoardViewController(FieldController field, CellView cellPrefab, BoardRoot boardRoot)
        {
            _field = field;
            _cellPrefab = cellPrefab;
            _root = boardRoot.Transform;
        }

        public void Initialize()
        {
            _field.FieldReset += OnFieldReset;
        }

        public void Dispose()
        {
            _field.FieldReset -= OnFieldReset;
        }

        private void OnFieldReset()
        {
            foreach (var view in _spawnedViews)
                if (view != null)
                    UnityEngine.Object.Destroy(view.gameObject);
            _spawnedViews.Clear();

            int cols = _field.Cols;
            int rows = _field.Rows;
            float halfCols = (cols - 1) * 0.5f;
            float halfRows = (rows - 1) * 0.5f;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    var position = new Vector3(x - halfCols, y - halfRows, 0f);
                    var view = UnityEngine.Object.Instantiate(_cellPrefab, position, Quaternion.identity, _root);
                    view.name = $"Cell_{x}_{y}";
                    view.SetState(CellVisualState.Closed);
                    _spawnedViews.Add(view);
                }
            }
        }
    }
}