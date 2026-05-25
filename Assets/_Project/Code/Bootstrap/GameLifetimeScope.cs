using Minesweeper.Gameplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Minesweeper.Bootstrap
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Configs")] [SerializeField] private GameConfigSO _gameConfig;
        [SerializeField] private CameraConfigSO _cameraConfig;

        [Header("Scene References")] [SerializeField] private Camera _mainCamera;
        [SerializeField] private BoardRoot _boardRoot;
        [SerializeField] private CellView _cellPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameConfig);
            builder.RegisterInstance(_cameraConfig);
            builder.RegisterInstance(_mainCamera);
            builder.RegisterInstance(_boardRoot);
            builder.RegisterInstance(_cellPrefab);

            builder.Register<FieldController>(Lifetime.Singleton);
            builder.Register<CameraController>(Lifetime.Singleton);
            builder.Register<GameInputController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<BoardViewController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.RegisterEntryPoint<GameStartup>();
        }
    }
}