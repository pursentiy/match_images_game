using GameState;
using Handlers;
using UnityEngine;

namespace Services
{
    public class GameService : MonoBehaviour, IGameService
    {
        public void InitializeGameService(IProgressHandler progressHandler, IScreenHandler screenHandler, ILevelSessionHandler levelSessionHandler, ILevelParamsHandler levelParamsHandler)
        {
            ProgressHandler = progressHandler;
            ScreenHandler = screenHandler;
            LevelSessionHandler = levelSessionHandler;
            LevelParamsHandler = levelParamsHandler;
        }
        
        public IProgressHandler ProgressHandler { get; private set; }
        public IScreenHandler ScreenHandler { get; private set; }
        public ILevelSessionHandler LevelSessionHandler { get; private set; }
        public ILevelParamsHandler LevelParamsHandler { get; private set; }
    }
}