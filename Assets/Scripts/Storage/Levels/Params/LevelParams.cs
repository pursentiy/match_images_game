using System;
using System.Collections.Generic;
using Level.Game;

namespace Storage.Levels.Params
{
    [Serializable]
    public class LevelParams
    {
        public int LevelNumber;
        public LevelVisualHandler LevelVisualHandler;
        public List<LevelFigureParams> LevelFiguresParamsList;
    }
}