using Screen;
using UnityEngine;

namespace Handlers
{
    public interface IScreenHandler
    {
        void Initialize(RectTransform popupCanvasTransform, ChooseLevelScreenHandler chooseLevelScreenHandler, WelcomeScreenHandler welcomeScreenHandler);
        void ShowChooseLevelScreen();
        void ShowWelcomeScreen();
        void PopupAllScreenHandlers();
    }
}