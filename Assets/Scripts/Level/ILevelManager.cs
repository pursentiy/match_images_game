using System.Collections.Generic;
using Figures.Animals;
using Level.Params;

namespace Level
{
    public interface ILevelManager
    {
        void SetupLevel(List<LevelFigureParams> levelFiguresParams);
        void ConnectFigures(FigureAnimalTarget figureTarget);
    }
}