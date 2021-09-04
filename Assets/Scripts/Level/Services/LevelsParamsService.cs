using System.Collections.Generic;
using System.Linq;
using Level.Params;
using UnityEngine;

namespace Level.Services
{
    [CreateAssetMenu(fileName = "LevelsService", menuName = "LevelsService/LevelsParams")]
    public class LevelsParamsService : ScriptableObject
    {
        [SerializeField] private List<LevelParams> _levelParamsList;

        public LevelParams GetLevelByNumber(int number)
        {
            return _levelParamsList.FirstOrDefault(levelParams => levelParams.LevelNumber == number);
        }
    }
}