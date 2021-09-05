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

        public void Initialize(RectTransform popupCanvasTransform, ChooseLevelScreenHandler chooseLevelScreenHandler, WelcomeScreenHandler welcomeScreenHandler)
        {
            _popupCanvasTransform = popupCanvasTransform;
            _chooseLevelScreenHandler = chooseLevelScreenHandler;
            _welcomeScreenHandler = welcomeScreenHandler;
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

        public void PopupAllScreenHandlers()
        {
            if (_currentScreenHandler != null)
            {
                Destroy(_currentScreenHandler.gameObject);
                _currentScreenHandler = null;
            }
        }
    }
}