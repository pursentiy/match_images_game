using Screen;
using UnityEngine;

namespace Handlers
{
    public interface IPopupsHandler
    {
        void Initialize(RectTransform popupCanvasTransform, ChooseLevelScreenHandler chooseLevelScreenHandler, WelcomeScreenHandler welcomeScreenHandler);
        void ShowChooseLevelScreen();
        void ShowWelcomeScreen();
    }
}