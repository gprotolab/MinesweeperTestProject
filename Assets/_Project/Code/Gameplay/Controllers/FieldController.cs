using System;
using System.Collections.Generic;
using Random = System.Random;

namespace Minesweeper.Gameplay
{
    public class FieldController
    {
        private static readonly (int dx, int dy)[] NeighbourOffsets =
        {
            (-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1)
        };

        private readonly Random _random = new();
        private readonly GameConfigSO _config;

        private Cell[,] _cells;
        private bool _minesPlaced;
        private bool _isGameOver;
        private int _openedNonMineCount;
        private int _totalNonMineCount;
        private int _minesCount;

        public int Cols { get; private set; }
        public int Rows { get; private set; }
        public bool IsFirstClickHappened { get; private set; }

        public event Action<Cell> CellChanged;
        public event Action FirstClickHappened;
        public event Action GameWon;
        public event Action GameLost;
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
            _minesCount = _config.MinesCount;
            _totalNonMineCount = Cols * Rows - _minesCount;
            _openedNonMineCount = 0;
            _minesPlaced = false;
            _isGameOver = false;
            IsFirstClickHappened = false;

            _cells = new Cell[Cols, Rows];
            for (int x = 0; x < Cols; x++)
            for (int y = 0; y < Rows; y++)
                _cells[x, y] = new Cell(x, y);

            FieldReset?.Invoke();
        }

        public void OpenCell(int x, int y)
        {
            if (_isGameOver) return;
            if (!InBounds(x, y)) return;

            var cell = _cells[x, y];
            if (cell.IsOpen || cell.IsFlagged) return;

            if (!_minesPlaced)
            {
                PlaceMines(safeX: x, safeY: y);
                CalculateNeighbours();
                _minesPlaced = true;
                IsFirstClickHappened = true;
                FirstClickHappened?.Invoke();
            }

            if (cell.HasMine)
            {
                cell.IsOpen = true;
                CellChanged?.Invoke(cell);
                _isGameOver = true;
                RevealAllMines();
                GameLost?.Invoke();
                return;
            }

            FloodFillOpen(cell);

            if (_openedNonMineCount >= _totalNonMineCount)
            {
                _isGameOver = true;
                GameWon?.Invoke();
            }
        }

        public void ToggleFlag(int x, int y)
        {
            if (_isGameOver) return;
            if (!InBounds(x, y)) return;

            var cell = _cells[x, y];
            if (cell.IsOpen) return;

            cell.IsFlagged = !cell.IsFlagged;
            CellChanged?.Invoke(cell);
        }

        private void RevealAllMines()
        {
            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    var cell = _cells[x, y];
                    if (!cell.HasMine || cell.IsOpen) continue;

                    cell.IsFlagged = false;
                    cell.IsOpen = true;
                    CellChanged?.Invoke(cell);
                }
            }
        }

        private void PlaceMines(int safeX, int safeY)
        {
            var candidates = new List<(int x, int y)>(Cols * Rows - 1);

            for (int x = 0; x < Cols; x++)
            for (int y = 0; y < Rows; y++)
                if (x != safeX || y != safeY)
                    candidates.Add((x, y));

            for (int i = candidates.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (candidates[i], candidates[j]) = (candidates[j], candidates[i]);
            }

            for (int i = 0; i < _minesCount; i++)
                _cells[candidates[i].x, candidates[i].y].HasMine = true;
        }

        private void CalculateNeighbours()
        {
            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    var cell = _cells[x, y];
                    if (cell.HasMine) continue;
                    cell.NeighbourMines = CountNeighbourMines(x, y);
                }
            }
        }

        private int CountNeighbourMines(int x, int y)
        {
            int count = 0;
            foreach (var (dx, dy) in NeighbourOffsets)
            {
                int nx = x + dx;
                int ny = y + dy;
                if (InBounds(nx, ny) && _cells[nx, ny].HasMine)
                    count++;
            }

            return count;
        }

        private void FloodFillOpen(Cell start)
        {
            var queue = new Queue<Cell>();

            start.IsOpen = true;
            _openedNonMineCount++;
            CellChanged?.Invoke(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                if (cell.NeighbourMines != 0) continue;

                foreach (var (dx, dy) in NeighbourOffsets)
                {
                    int nx = cell.X + dx;
                    int ny = cell.Y + dy;
                    if (!InBounds(nx, ny)) continue;

                    var neighbour = _cells[nx, ny];
                    if (neighbour.IsOpen || neighbour.IsFlagged || neighbour.HasMine)
                        continue;

                    neighbour.IsOpen = true;
                    _openedNonMineCount++;
                    CellChanged?.Invoke(neighbour);
                    queue.Enqueue(neighbour);
                }
            }
        }

        private bool InBounds(int x, int y) => x >= 0 && y >= 0 && x < Cols && y < Rows;
    }
}