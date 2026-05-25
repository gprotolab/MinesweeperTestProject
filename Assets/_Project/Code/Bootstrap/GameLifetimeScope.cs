using Minesweeper.Gameplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Minesweeper.Bootstrap
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Configs")] [SerializeField] private GameConfigSO _gameConfig;

        [Header("Scene References")] [SerializeField] private BoardRoot _boardRoot;
        [SerializeField] private CellView _cellPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameConfig);
            builder.RegisterInstance(_boardRoot);
            builder.RegisterInstance(_cellPrefab);

            builder.Register<FieldController>(Lifetime.Singleton);
            builder.Register<BoardViewController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.RegisterEntryPoint<GameStartup>();
        }
    }
}