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

        public List<LevelParams> LevelsParamsList => _levelParamsList;
    }
}