using System;
using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Screen
{
    public class WelcomeScreenHandler : ScreenHandler
    {
        [Inject] private IGameService _gameService;
        
        [SerializeField] private Button _playButton;
        [SerializeField] private ChooseLevelScreenHandler chooseLevelScreenHandlerScreen;
        
        private void Start()
        {
            _playButton.onClick.AddListener(PushNextScreen);
        }

        private void PushNextScreen()
        {
            _gameService.PopupsHandler.ShowChooseLevelScreen();
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveAllListeners();
        }
    }
}