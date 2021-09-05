using GameState;
using Handlers;

namespace Services
{
    public interface IGameService
    {
        void InitializeGameService(IProgressHandler progressHandler, IScreenHandler screenHandler, ILevelSessionHandler levelSessionHandler, ILevelHandler levelHandler);
        IProgressHandler ProgressHandler { get; }
        IScreenHandler ScreenHandler { get; }
        ILevelSessionHandler LevelSessionHandler { get; }
        ILevelHandler LevelHandler { get; }
    }
}