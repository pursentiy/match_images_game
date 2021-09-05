using System.Collections.Generic;
using Installers;
using Level.Hud.Click;
using ProgressHandlers;
using Services;
using Storage.Levels.Params;
using UnityEngine;
using Zenject;

namespace GameState
{
    public class OnGameEnterState : InjectableMonoBehaviour
    {
        [Inject] private LevelsParamsStorage _levelsParamsStorage;
        [Inject] private IProcessProgressDataService _processProgressDataService;
        [Inject] private IGameService _gameService;

        [SerializeField] private ProgressHandler _progressHandler;

        protected override void Awake()
        {
            var savedDataProgress = _processProgressDataService.LoadProgress();
            _progressHandler.InitializeHandler(savedDataProgress ?? StartNewGameProgress());
            _gameService.InitializeGameService(_progressHandler);
        }

        private List<LevelParams> StartNewGameProgress()
        {
            var levelsParams = _levelsParamsStorage.LevelsParamsList;
            _processProgressDataService.SaveProgress(levelsParams);
            return levelsParams;
        }
    }
}