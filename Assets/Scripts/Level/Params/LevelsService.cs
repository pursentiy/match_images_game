using System.Collections.Generic;
using UnityEngine;

namespace Level.Params
{
    [CreateAssetMenu(fileName = "LevelsService", menuName = "LevelsService/LevelsParams")]
    public class LevelsService : ScriptableObject
    {
        public List<LevelParams> LevelParamsList;
        
    }
}