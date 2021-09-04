using System.Collections.Generic;
using Figures.Animals;
using Storage.Levels.Params;

namespace Level.Hud
{
    public interface ILevelHudHandler
    {
        void SetupScrollMenu(List<LevelFigureParams> levelFiguresParams);
        void ConnectFigures(FigureAnimalsMenu figureTarget);
    }
}