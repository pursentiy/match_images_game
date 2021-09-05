using Screen;
using UnityEngine;

namespace Handlers
{
    public class PopupsHandler : MonoBehaviour, IPopupsHandler
    {
        private RectTransform _popupCanvasTransform;
        private ChooseLevelScreenHandler _chooseLevelScreenHandler;
        private WelcomeScreenHandler _welcomeScreenHandler;
        private ScreenHandler _currentScreenHandler;

        public void Initialize(RectTransform popupCanvasTransform, ChooseLevelScreenHandler chooseLevelScreenHandler, WelcomeScreenHandler welcomeScreenHandler)
        {
            _popupCanvasTransform = popupCanvasTransform;
            _chooseLevelScreenHandler = chooseLevelScreenHandler;
            _welcomeScreenHandler = welcomeScreenHandler;
        }

        public void ShowChooseLevelScreen()
        {
            if (_currentScreenHandler != null)
            {
                Destroy(_currentScreenHandler.gameObject);
                _currentScreenHandler = null;
            }

            _currentScreenHandler = Instantiate(_chooseLevelScreenHandler, _popupCanvasTransform);
        }
        
        public void ShowWelcomeScreen()
        {
            if (_currentScreenHandler != null)
            {
                Destroy(_currentScreenHandler.gameObject);
                _currentScreenHandler = null;
            }

            _currentScreenHandler = Instantiate(_welcomeScreenHandler, _popupCanvasTransform);
        }
    }
}