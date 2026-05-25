namespace Minesweeper.Gameplay
{
    public class Cell
    {
        public int X { get; }
        public int Y { get; }

        public bool HasMine;
        public bool IsOpen;
        public bool IsFlagged;
        public int NeighbourMines;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}