using Minesweeper.Gameplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Minesweeper.Bootstrap
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Configs")] [SerializeField] private GameConfigSO _gameConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameConfig);
            builder.Register<FieldController>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameStartup>();
        }
    }
}