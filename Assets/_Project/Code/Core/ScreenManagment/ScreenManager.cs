using System;
using System.Collections.Generic;

namespace Minesweeper.Core
{
    public class ScreenManager : IScreenManager
    {
        private readonly Dictionary<Type, IScreen> _screens;

        public ScreenManager(IEnumerable<IScreen> screens)
        {
            _screens = new Dictionary<Type, IScreen>();
            foreach (var screen in screens)
                _screens[screen.GetType()] = screen;

            HideAll();
        }

        public void Show<TScreen>() where TScreen : class, IScreen
        {
            if (_screens.TryGetValue(typeof(TScreen), out var screen))
                screen.Show();
        }

        public void Hide<TScreen>() where TScreen : class, IScreen
        {
            if (_screens.TryGetValue(typeof(TScreen), out var screen))
                screen.Hide();
        }

        public void HideAll()
        {
            foreach (var screen in _screens.Values)
                screen.Hide();
        }
    }
}