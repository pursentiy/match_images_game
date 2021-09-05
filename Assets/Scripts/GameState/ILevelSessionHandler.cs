using Level.Hud;
using Storage.Levels.Params;
using UnityEngine;

namespace GameState
{
    public interface ILevelSessionHandler
    {
        void StartLevel(LevelParams levelParams, LevelHudHandler levelHudHandler, Color defaultColor);
    }
}