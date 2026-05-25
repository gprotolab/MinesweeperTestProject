# Minesweeper

Реализация классической игры «Сапёр» в рамках тестового задания.

## Реализация по ТЗ

- Всё на одной сцене
- Размер поля и количество мин задаётся в ScriptableObject конфиге `GameConfigSO`
- Левый клик - открыть клетку, правый клик - поставить/снять флажок
- Первый клик всегда безопасен (мины расставляются после него)
- Таймер запускается при первом клике
- Цепочка пустых клеток раскрывается итеративно
- Игра начинается с главного меню с кнопкой «Старт»
- Кнопка паузы открывает меню с вариантами: продолжить, рестарт, выход в главное меню
- При победе или поражении отображается соответствующее сообщение и кнопки рестарта и выхода в главное меню
- Быстрый рестарт игры нажатием клавиши **F2**

## Cтек

- **Unity 6000.3.15f1**
- **VContainer** - Dependency Injection

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