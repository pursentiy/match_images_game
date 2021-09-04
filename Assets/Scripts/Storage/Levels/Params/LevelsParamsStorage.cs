using System.Collections.Generic;
using System.Linq;
using Level.Hud;
using UnityEngine;

namespace Storage.Levels.Params
{
    [CreateAssetMenu(fileName = "LevelsService", menuName = "LevelsService/LevelsParams")]
    public class LevelsParamsStorage : ScriptableObject
    {
        [SerializeField] private List<LevelParams> _levelParamsList;
        [SerializeField] private LevelHudHandler _levelHudHandlerPrefab;
        public LevelParams GetLevelByNumber(int number)
        {
            return _levelParamsList.FirstOrDefault(levelParams => levelParams.LevelNumber == number);
        }

        public LevelHudHandler GetLevelHudHandler()
        {
            return _levelHudHandlerPrefab;
        }
    }
}