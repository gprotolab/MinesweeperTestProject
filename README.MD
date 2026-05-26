## Minesweeper

Реализация классической игры «Сапёр» в рамках **тестового задания**.

## Cтек

- **Unity 6000.3.15f1**
- **VContainer** - Dependency Injection

## Детали реализации

### Архитектура
Все зависимости разрешаются через VContainer. Синглтоны и `FindObjectOfType` не используются.
Игровой поток построен на стейт-машине: каждое состояние (`MainMenuState`, `GameplaySetupState`,
`GameplayState`, `PausedState`, `GameOverState`) - это изолированный класс с методами `Enter` / `Exit`.

### Рендеринг
Клетки отрисовываются через `SpriteRenderer`. Спрайты используют один атлас и один материал,
что позволяет Unity автоматически объединять их в один батч, чтобы количество draw calls не росло
с размером поля.

### Камера
`CameraController` подстраивает ортографический размер камеры под поле после каждого старта:
учитывается соотношение сторон экрана, чтобы поле корректно отображалось на любом разрешении.
Отступы вокруг поля (Top / Bottom / Left / Right) настраиваются через `CameraConfigSO`.

## Структура проекта
```
Assets/_Project/Code/
├── Bootstrap/              # GameLifetimeScope (DI-контейнер), GameStartup (точка входа)
├── Core/
│   ├── ScreenManagement/   # IScreen, IScreenManager, BaseScreenView, ScreenManager
│   └── StateMachine/       # IState, StateMachine
├── GameFlow/               # GameStateMachine
│   └── States/             # MainMenuState, GameplaySetupState, GameplayState, PausedState, GameOverState
├── Gameplay/
│   ├── Configs/            # GameConfigSO (поле, мины), CameraConfigSO (отступы)
│   ├── Controllers/        # FieldController, CameraController, GameInputController, TimerController, BoardViewController (спавн и обновление клеток)
│   ├── Model/              # Cell
│   └── View/               # CellView, CellVisualState, BoardRoot
└── Screens/                # MainMenuView, GameView, PauseView, GameOverView
```

## Реализованный функционал

| Пункт | Описание                                                                                           |
|---|----------------------------------------------------------------------------------------------------|
| Настраиваемое поле | Количество строк, столбцов и мин задаётся в `GameConfigSO` ScriptableObject                        |
| Безопасный первый клик | Мины расставляются **после** первого клика, он всегда безопасен                                    |
| Цепное открытие | Открытие пустой клетки автоматически раскрывает все соседние пустые клетки и их соседей итеративно |
| Таймер | Запускается при первом клике, останавливается на паузе                                             |
| Главное меню | Кнопка старт                                                                                       |
| Меню паузы | Продолжить / Рестарт / Выйти в главное меню                                                        |
| Экран окончания игры | Сообщение «You won!» или «Game over» + кнопки рестарт и выход в главное меню                       |
| Клавиша рестарта | **F2** перезапускает игру    