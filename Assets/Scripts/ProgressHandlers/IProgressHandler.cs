﻿using System.Collections.Generic;
using Figures;
using Storage.Levels.Params;

namespace ProgressHandlers
{
    public interface IProgressHandler
    {
        void InitializeHandler(List<LevelParams> levelsParams);
        void UpdateProgress(int levelNumber, FigureType figureType);
        bool CheckForLevelCompletion(int levelNumber);
    }
}