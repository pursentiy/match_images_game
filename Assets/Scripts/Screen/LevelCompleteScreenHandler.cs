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
            _gameService.ScreenHandler.PopupAllScreenHandlers();
            _gameService.LevelSessionHandler.StartLevel(levelParams, _gameService.LevelParamsHandler.LevelHudHandlerPrefab, _gameService.LevelParamsHandler.TargetFigureDefaultColor);
        }
        
        private void OnDestroy()
        {
            _backButton.onClick.RemoveAllListeners();
            _tryAgainButton.onClick.RemoveAllListeners();
        }
    }
}