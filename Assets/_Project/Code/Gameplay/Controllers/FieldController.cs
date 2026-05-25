using System;

namespace Minesweeper.Gameplay
{
    public class FieldController
    {
        private readonly GameConfigSO _config;

        private Cell[,] _cells;

        public int Cols { get; private set; }
        public int Rows { get; private set; }

        public event Action<Cell> CellChanged;
        public event Action FieldReset;

        public FieldController(GameConfigSO config)
        {
            _config = config;
        }

        public Cell GetCell(int x, int y) => _cells[x, y];

        public void PrepareNewGame()
        {
            Cols = _config.Cols;
            Rows = _config.Rows;

            _cells = new Cell[Cols, Rows];
            for (int x = 0; x < Cols; x++)
            for (int y = 0; y < Rows; y++)
                _cells[x, y] = new Cell(x, y);

            FieldReset?.Invoke();
        }

        public void OpenCell(int x, int y)
        {
            if (!InBounds(x, y)) return;

            var cell = _cells[x, y];
            if (cell.IsOpen) return;

            cell.IsOpen = true;
            CellChanged?.Invoke(cell);
        }

        private bool InBounds(int x, int y) => x >= 0 && y >= 0 && x < Cols && y < Rows;
    }
}