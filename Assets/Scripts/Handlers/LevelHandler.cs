using Level.Hud;
using UnityEngine;

namespace Handlers
{
    public class LevelHandler : MonoBehaviour, ILevelHandler
    {
        [SerializeField] private LevelHudHandler _levelHudHandlerPrefab;
        [SerializeField] private Color _targetFigureDefaultColor;
        
        public LevelHudHandler LevelHudHandlerPrefab => _levelHudHandlerPrefab;
        public Color TargetFigureDefaultColor => _targetFigureDefaultColor;
    }
}