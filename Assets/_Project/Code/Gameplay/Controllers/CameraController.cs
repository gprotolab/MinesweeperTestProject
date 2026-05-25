using UnityEngine;

namespace Minesweeper.Gameplay
{
    public class CameraController
    {
        private readonly Camera _camera;
        private readonly CameraConfigSO _config;

        private int _cols;
        private int _rows;

        public CameraController(Camera camera, CameraConfigSO config)
        {
            _camera = camera;
            _config = config;
        }

        public void FitToField(int cols, int rows)
        {
            _cols = cols;
            _rows = rows;

            float totalWidth  = cols + _config.LeftPadding + _config.RightPadding;
            float totalHeight = rows + _config.TopPadding  + _config.BottomPadding;

            float aspect = (float)Screen.width / Screen.height;

            float sizeByHeight = totalHeight * 0.5f;
            float sizeByWidth  = totalWidth  * 0.5f / aspect;
            float size = Mathf.Max(sizeByHeight, sizeByWidth);

            float cx = (_config.RightPadding - _config.LeftPadding) * 0.5f;
            float cy = (_config.TopPadding   - _config.BottomPadding) * 0.5f;

            _camera.orthographic = true;
            _camera.orthographicSize = size;

            var t = _camera.transform;
            t.position = new Vector3(cx, cy, t.position.z);
        }

        public bool TryScreenToCell(Vector2 screenPosition, out Vector2Int cell)
        {
            var world = _camera.ScreenToWorldPoint(screenPosition);
            int x = Mathf.RoundToInt(world.x + (_cols - 1) * 0.5f);
            int y = Mathf.RoundToInt(world.y + (_rows - 1) * 0.5f);

            if (x < 0 || y < 0 || x >= _cols || y >= _rows)
            {
                cell = default;
                return false;
            }

            cell = new Vector2Int(x, y);
            return true;
        }
    }
}