using System;
using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Screen
{
    public class LevelCompleteScreenHandler : ScreenHandler
    {
        [Inject] private IGameService _gameService;
        
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _tryAgainButton;
        [SerializeField] private RawImage _finalLevelImage;
        [SerializeField] private int _levelTextureWidth;
        [SerializeField] private int _levelTextureHeight;
        
        private Camera _textureCamera;
        private RenderTexture _renderTexture;
        private Action _onFinishLevelSessionAction;

        public void SetOnFinishLevelSessionAction(Action action)
        {
            _onFinishLevelSessionAction = action;
        }

        public void SetupTextureCamera(Camera sourceCamera)
        {
            _textureCamera = sourceCamera;
            
            _textureCamera.gameObject.SetActive(true);
            _renderTexture = new RenderTexture(_levelTextureWidth, _levelTextureHeight, 16, RenderTextureFormat.ARGB32);
            _renderTexture.Create();
            _finalLevelImage.texture = _renderTexture;
            _textureCamera.targetTexture = _renderTexture;
        }
        
        private void Start()
        {
            InitializeLevelsButton();
        }

        private void InitializeLevelsButton()
        {
            _backButton.onClick.AddListener(_gameService.ScreenHandler.ShowChooseLevelScreen);
            _tryAgainButton.onClick.AddListener(TryAgainLevel);
        }

        private void TryAgainLevel()
        {
            if (_currentLevel == -1)
            {
                Debug.LogWarning($"Current Level is {_currentLevel}. Cannot continue. Warning in {this}");
                _gameService.ScreenHandler.ShowChooseLevelScreen();
            }
            
            _gameService.ProgressHandler.ResetLevelProgress(_currentLevel);
            var levelParams = _gameService.ProgressHandler.GetLevelByNumber(_currentLevel);

            TryInvokeFinishLevelSessionAction();
            
            _gameService.ScreenHandler.PopupAllScreenHandlers();
            _gameService.LevelSessionHandler.StartLevel(levelParams, _gameService.LevelParamsHandler.LevelHudHandlerPrefab, _gameService.LevelParamsHandler.TargetFigureDefaultColor);
        }
        
        private void OnDestroy()
        {
            _backButton.onClick.RemoveAllListeners();
            _tryAgainButton.onClick.RemoveAllListeners();
            
            TryInvokeFinishLevelSessionAction();
        }

        private void TryInvokeFinishLevelSessionAction()
        {
            _onFinishLevelSessionAction?.Invoke();

            _onFinishLevelSessionAction = null;
        }
    }
}