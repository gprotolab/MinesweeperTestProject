using UnityEngine;

namespace Minesweeper.Gameplay
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Minesweeper/Camera Config")]
    public class CameraConfigSO : ScriptableObject
    {
        [field: SerializeField, Min(0)] public float TopPadding { get; private set; } = 1.5f;
        [field: SerializeField, Min(0)] public float BottomPadding { get; private set; } = 0.5f;
        [field: SerializeField, Min(0)] public float LeftPadding { get; private set; } = 0.5f;
        [field: SerializeField, Min(0)] public float RightPadding { get; private set; } = 0.5f;
    }
}