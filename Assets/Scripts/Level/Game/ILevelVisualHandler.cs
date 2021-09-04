using System.Collections.Generic;
using Figures.Animals;
using Storage.Levels.Params;

namespace Level.Game
{
    public interface ILevelVisualHandler
    {
        void SetupLevel(List<LevelFigureParams> levelFiguresParams);
        void ConnectFigures(FigureAnimalTarget figureTarget);
    }
}