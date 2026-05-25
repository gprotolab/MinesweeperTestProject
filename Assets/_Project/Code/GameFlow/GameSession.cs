namespace Minesweeper.GameFlow
{
    public class GameSession
    {
        public bool IsWon { get; private set; }

        public void SetResult(bool isWon) => IsWon = isWon;
    }
}