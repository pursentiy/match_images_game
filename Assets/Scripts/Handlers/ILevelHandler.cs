using Level.Hud;
using UnityEngine;

namespace Handlers
{
    public interface ILevelHandler
    { 
        LevelHudHandler LevelHudHandlerPrefab  { get; }
        Color TargetFigureDefaultColor { get; }
    }
}