using Minesweeper.Core;
using Minesweeper.GameFlow;
using Minesweeper.Gameplay;
using Minesweeper.Screens;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Minesweeper.Bootstrap
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Configs")] 
        [SerializeField] private GameConfigSO _gameConfig;
        [SerializeField] private CameraConfigSO _cameraConfig;

        [Header("Scene References")] 
        [SerializeField] private Camera _mainCamera;

        [SerializeField] private BoardRoot _boardRoot;
        [SerializeField] private CellView _cellPrefab;

        [Header("Views")] 
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private GameView _gameView;
        [SerializeField] private PauseView _pauseView;
        [SerializeField] private GameOverView _gameOverView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameConfig);
            builder.RegisterInstance(_cameraConfig);

            builder.RegisterInstance(_mainCamera);
            builder.RegisterInstance(_boardRoot);
            builder.RegisterInstance(_cellPrefab);
            builder.RegisterComponent(_mainMenuView).AsImplementedInterfaces().AsSelf();
            builder.RegisterComponent(_gameView).AsImplementedInterfaces().AsSelf();
            builder.RegisterComponent(_pauseView).AsImplementedInterfaces().AsSelf();
            builder.RegisterComponent(_gameOverView).AsImplementedInterfaces().AsSelf();

            builder.Register<ScreenManager>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<FieldController>(Lifetime.Singleton);
            builder.Register<TimerController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<CameraController>(Lifetime.Singleton);
            builder.Register<GameInputController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<BoardViewController>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<GameSession>(Lifetime.Singleton);

            builder.Register<GameStateMachine>(Lifetime.Singleton);
            builder.Register<MainMenuState>(Lifetime.Singleton);
            builder.Register<GameplaySetupState>(Lifetime.Singleton);
            builder.Register<GameplayState>(Lifetime.Singleton);
            builder.Register<PausedState>(Lifetime.Singleton);
            builder.Register<GameOverState>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameStartup>();
        }
    }
}