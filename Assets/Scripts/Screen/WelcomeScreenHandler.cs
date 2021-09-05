﻿using System;
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

        private void Start()
        {
            _playButton.onClick.AddListener(PushNextScreen);
        }

        private void PushNextScreen()
        {
            _gameService.ScreenHandler.ShowChooseLevelScreen();
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveAllListeners();
        }
    }
}