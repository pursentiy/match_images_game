using System;
using Screen;
using UnityEngine;

namespace Handlers
{
    public interface IScreenHandler
    {
        void Initialize(RectTransform popupCanvasTransform, ChooseLevelScreenHandler chooseLevelScreenHandler, WelcomeScreenHandler welcomeScreenHandler, LevelCompleteScreenHandler levelCompleteScreenHandler);
        void ShowChooseLevelScreen();
        void ShowWelcomeScreen();
        void PopupAllScreenHandlers();
        void ShowLevelCompleteScreen(int currentLevel, Camera sourceCamera, Action onFinishAction);
    }
}