using Level.Hud;
using UnityEngine;

namespace Handlers
{
    public class LevelParamsParamsHandler : MonoBehaviour, ILevelParamsHandler
    {
        [SerializeField] private LevelHudHandler _levelHudHandlerPrefab;
        [SerializeField] private Color _targetFigureDefaultColor;
        
        public LevelHudHandler LevelHudHandlerPrefab => _levelHudHandlerPrefab;
        public Color TargetFigureDefaultColor => _targetFigureDefaultColor;
    }
}