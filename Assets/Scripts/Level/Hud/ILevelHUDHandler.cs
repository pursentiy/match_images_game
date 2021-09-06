using System.Collections.Generic;
using Storage.Levels.Params;

namespace Level.Hud
{
    public interface ILevelHudHandler
    {
        void SetupScrollMenu(List<LevelFigureParams> levelFiguresParams);
        void LockScroll(bool value);
    }
}