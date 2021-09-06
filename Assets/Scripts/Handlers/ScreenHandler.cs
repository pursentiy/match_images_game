using System;
using Screen;
using UnityEngine;

namespace Handlers
{
    public class ScreenHandler : MonoBehaviour, IScreenHandler
    {
        private RectTransform _popupCanvasTransform;
        private ChooseLevelScreenHandler _chooseLevelScreenHandler;
        private WelcomeScreenHandler _welcomeScreenHandler;
        private Screen.ScreenHandler _currentScreenHandler;
        private LevelCompleteScreenHandler _levelCompleteScreenHandler;

        public void Initialize(RectTransform popupCanvasTransform, ChooseLevelScreenHandler chooseLevelScreenHandler, WelcomeScreenHandler welcomeScreenHandler, LevelCompleteScreenHandler levelCompleteScreenHandler)
        {
            _popupCanvasTransform = popupCanvasTransform;
            _chooseLevelScreenHandler = chooseLevelScreenHandler;
            _welcomeScreenHandler = welcomeScreenHandler;
            _levelCompleteScreenHandler = levelCompleteScreenHandler;
        }

        public void ShowChooseLevelScreen()
        {
            PopupAllScreenHandlers();

            _currentScreenHandler = Instantiate(_chooseLevelScreenHandler, _popupCanvasTransform);
        }
        
        public void ShowWelcomeScreen()
        {
            PopupAllScreenHandlers();

            _currentScreenHandler = Instantiate(_welcomeScreenHandler, _popupCanvasTransform);
        }
        
        public void ShowLevelCompleteScreen(int currentLevel, Camera sourceCamera, Action onFinishAction)
        {
            PopupAllScreenHandlers();

            var screenHandler = Instantiate(_levelCompleteScreenHandler, _popupCanvasTransform);
            screenHandler.SetOnFinishLevelSessionAction(onFinishAction);
            screenHandler.SetupTextureCamera(sourceCamera);
            
            _currentScreenHandler = screenHandler;
            _currentScreenHandler.CurrentLevel = currentLevel;
        }

        public void PopupAllScreenHandlers()
        {
            if (_currentScreenHandler == null)
            {
                return;
            }
            
            Destroy(_currentScreenHandler.gameObject);
            _currentScreenHandler = null;
        }
    }
}