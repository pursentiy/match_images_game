using Handlers;
using UnityEngine;

namespace Services
{
    public class GameService : MonoBehaviour, IGameService
    {
        public void InitializeGameService(IProgressHandler progressHandler, IPopupsHandler popupsHandler)
        {
            ProgressHandler = progressHandler;
            PopupsHandler = popupsHandler;
        }
        
        public IProgressHandler ProgressHandler { get; private set; }
        public IPopupsHandler PopupsHandler { get; private set; }
    }
}