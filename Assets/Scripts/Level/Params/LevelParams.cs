using System;
using System.Collections.Generic;
using Figures;
using UnityEngine;

namespace Level.Params
{
    [Serializable]
    public class LevelParams
    {
        public int LevelNumber;
        public LevelVisualHandler LevelVisualHandler;
        public List<LevelFigureParams> LevelFiguresParamsList;
    }
}