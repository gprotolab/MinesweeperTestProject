namespace Minesweeper.Core
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}