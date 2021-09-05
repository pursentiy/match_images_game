using ProgressHandlers;
using UnityEngine;

namespace Services
{
    public class GameService : MonoBehaviour, IGameService
    {
        public void InitializeGameService(IProgressHandler progressHandler)
        {
            ProgressHandler = progressHandler;
        }
        
        public IProgressHandler ProgressHandler { get; private set; }
    }
}