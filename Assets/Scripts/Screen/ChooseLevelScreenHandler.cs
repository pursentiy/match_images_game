using Installers;
using Screen.SubElements;
using Services;
using UnityEngine;
using Zenject;

namespace Screen
{
    public class ChooseLevelScreenHandler : ScreenHandler
    {
        [Inject] private IGameService _gameService;
        
        
        [SerializeField] private LevelEnterPopupHandler _levelEnterPopupPrefab;
        
    }
}