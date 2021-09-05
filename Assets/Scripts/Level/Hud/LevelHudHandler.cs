using System;
using System.Collections.Generic;
using Figures.Animals;
using Installers;
using Plugins.FSignal;
using Services;
using Storage;
using Storage.Levels.Params;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Level.Hud
{
    public class LevelHudHandler : InjectableMonoBehaviour, ILevelHudHandler
    {
        [Inject] private FiguresStorage _figuresStorage;
        [Inject] private IGameService _gameService;
        
        [SerializeField] private RectTransform _figuresParentTransform;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private Button _backButton;
        
        private List<FigureAnimalsMenu> _figureAnimalsMenuList;

        protected override void Awake()
        {
            _figureAnimalsMenuList = new List<FigureAnimalsMenu>();
            
            _backButton.onClick.AddListener(GoToMainMenuScreen);
        }

        public FSignal BackToMenuClickSignal { get; } = new FSignal();

        public void SetupScrollMenu(List<LevelFigureParams> levelFiguresParams)
        {
            levelFiguresParams.ForEach(SetFigure);
        }

        private void SetFigure(LevelFigureParams figureParams)
        {
            var figurePrefab = _figuresStorage.GetFiguresByType(figureParams.FigureType);

            if (figurePrefab == null)
            {
                Debug.LogWarning($"Could not find figure with type {figureParams.FigureType} in {this}");
                return;
            }

            if (figureParams.Completed)
            {
                return;
            }
            
            var figure = Instantiate(figurePrefab.FigureMenu, _figuresParentTransform);
            figure.SetUpDefaultParamsFigure(figureParams.Color, figureParams.FigureType);
            figure.SetUpFigure(figure.FigureColor);
            _figureAnimalsMenuList.Add(figure);

        }

        private void GoToMainMenuScreen()
        {
            BackToMenuClickSignal.Dispatch();
            _gameService.ScreenHandler.ShowChooseLevelScreen();
        }

        public void LockScroll(bool value)
        {
            _scrollRect.horizontal = !value;
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveAllListeners();
        }
    }
}