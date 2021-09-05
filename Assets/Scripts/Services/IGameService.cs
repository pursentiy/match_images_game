using GameState;
using Handlers;

namespace Services
{
    public interface IGameService
    {
        void InitializeGameService(IProgressHandler progressHandler, IScreenHandler screenHandler, ILevelSessionHandler levelSessionHandler, ILevelParamsHandler levelParamsHandler);
        IProgressHandler ProgressHandler { get; }
        IScreenHandler ScreenHandler { get; }
        ILevelSessionHandler LevelSessionHandler { get; }
        ILevelParamsHandler LevelParamsHandler { get; }
    }
}