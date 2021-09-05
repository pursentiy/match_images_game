using System;
using System.Collections.Generic;
using Handlers;
using Installers;
using Level.Hud.Click;
using Screen;
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
        [SerializeField] private PopupsHandler _popupsHandler;
        
        [SerializeField] private ChooseLevelScreenHandler _chooseLevelScreenHandler;
        [SerializeField] private WelcomeScreenHandler _welcomeScreenHandler;
        [SerializeField]private RectTransform _popupCanvasTransform;

        protected override void Awake()
        {
            var savedDataProgress = _processProgressDataService.LoadProgress();
            
            _popupsHandler.Initialize(_popupCanvasTransform, _chooseLevelScreenHandler, _welcomeScreenHandler);
            _progressHandler.InitializeHandler(savedDataProgress ?? StartNewGameProgress());
            
            _gameService.InitializeGameService(_progressHandler, _popupsHandler);
        }

        private void Start()
        {
            _gameService.PopupsHandler.ShowWelcomeScreen();
        }

        private List<LevelParams> StartNewGameProgress()
        {
            var levelsParams = _levelsParamsStorage.LevelsParamsList;
            _processProgressDataService.SaveProgress(levelsParams);
            return levelsParams;
        }
    }
}