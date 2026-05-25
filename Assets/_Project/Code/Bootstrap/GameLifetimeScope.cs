using VContainer;
using VContainer.Unity;

namespace Minesweeper.Bootstrap
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameStartup>();
        }
    }
}