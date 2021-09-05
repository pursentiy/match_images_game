using Handlers;

namespace Services
{
    public interface IGameService
    {
        void InitializeGameService(IProgressHandler progressHandler, IPopupsHandler popupsHandler);
        IProgressHandler ProgressHandler { get; }
        IPopupsHandler PopupsHandler { get; }
    }
}