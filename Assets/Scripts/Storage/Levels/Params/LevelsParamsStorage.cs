using System;
using System.Collections.Generic;
using System.Linq;
using Level.Hud;
using UnityEngine;

namespace Storage.Levels.Params
{
    [CreateAssetMenu(fileName = "LevelsParamsStorage", menuName = "ScriptableObjects/LevelsParams")]
    public class LevelsParamsStorage : ScriptableObject
    {
        [SerializeField] private List<LevelParams> _levelParamsList;
        [SerializeField] private LevelHudHandler _levelHudHandlerPrefab;
        [SerializeField] private Color _targetFigureDefaultColor;
        
        public LevelParams GetLevelByNumber(int number)
        {
            return _levelParamsList.FirstOrDefault(levelParams => levelParams.LevelNumber == number);
        }

        public List<LevelParams> LevelsParamsList => _levelParamsList;

        public LevelHudHandler LevelHudHandler => _levelHudHandlerPrefab;

        public Color TargetFigureDefaultColor => _targetFigureDefaultColor;
    }
}