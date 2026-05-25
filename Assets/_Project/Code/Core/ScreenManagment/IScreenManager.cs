namespace Minesweeper.Core
{
    public interface IScreenManager
    {
        void Show<TScreen>() where TScreen : class, IScreen;
        void Hide<TScreen>() where TScreen : class, IScreen;
        void HideAll();
    }
}