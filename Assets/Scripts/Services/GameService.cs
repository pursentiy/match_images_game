using GameState;
using Handlers;
using UnityEngine;

namespace Services
{
    public class GameService : MonoBehaviour, IGameService
    {
        public void InitializeGameService(IProgressHandler progressHandler, IScreenHandler screenHandler, ILevelSessionHandler levelSessionHandler, ILevelHandler levelHandler)
        {
            ProgressHandler = progressHandler;
            ScreenHandler = screenHandler;
            LevelSessionHandler = levelSessionHandler;
            LevelHandler = levelHandler;
        }
        
        public IProgressHandler ProgressHandler { get; private set; }
        public IScreenHandler ScreenHandler { get; private set; }
        public ILevelSessionHandler LevelSessionHandler { get; private set; }
        public ILevelHandler LevelHandler { get; private set; }
    }
}