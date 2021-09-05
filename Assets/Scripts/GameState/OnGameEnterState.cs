using System;
using System.Collections.Generic;
using Handlers;
using Installers;
using Level.Hud;
using Level.Hud.Click;
using Screen;
using Services;
using Storage.Levels.Params;
using UnityEngine;
using Zenject;
using ScreenHandler = Handlers.ScreenHandler;

namespace GameState
{
    public class OnGameEnterState : InjectableMonoBehaviour
    {
        [Inject] private LevelsParamsStorage _levelsParamsStorage;
        [Inject] private IProcessProgressDataService _processProgressDataService;
        [Inject] private IGameService _gameService;

        [SerializeField] private ProgressHandler _progressHandler;
        [SerializeField] private ScreenHandler _screenHandler;
        [SerializeField] private LevelSessionHandler _levelSessionHandler;
        [SerializeField] private LevelParamsParamsHandler levelParamsParamsHandler;
        
        [SerializeField] private ChooseLevelScreenHandler _chooseLevelScreenHandler;
        [SerializeField] private WelcomeScreenHandler _welcomeScreenHandler;
        [SerializeField] private LevelCompleteScreenHandler _levelCompleteScreenHandler;
        [SerializeField]private RectTransform _scnreenCanvasTransform;

        protected override void Awake()
        {
            var savedDataProgress = _processProgressDataService.LoadProgress();
            
            _screenHandler.Initialize(_scnreenCanvasTransform, _chooseLevelScreenHandler, _welcomeScreenHandler, _levelCompleteScreenHandler);
            _progressHandler.InitializeHandler(savedDataProgress ?? StartNewGameProgress());
            
            _gameService.InitializeGameService(_progressHandler, _screenHandler, _levelSessionHandler, levelParamsParamsHandler);
        }

        private void Start()
        {
            _gameService.ScreenHandler.ShowWelcomeScreen();
        }

        private List<LevelParams> StartNewGameProgress()
        {
            var levelsParams = _levelsParamsStorage.DefaultLevelsParamsList;
            _processProgressDataService.SaveProgress(levelsParams);
            return levelsParams;
        }

        private void OnDestroy()
        {
            _processProgressDataService.SaveProgress(_gameService.ProgressHandler.GetAllLevelsParams());
        }
    }
}