using UnityEngine;

namespace Minesweeper.Gameplay
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Minesweeper/Game Config")]
    public class GameConfigSO : ScriptableObject
    {
        [field: SerializeField, Min(4)] public int Rows { get; private set; } = 9;
        [field: SerializeField, Min(4)] public int Cols { get; private set; } = 9;
    }
}