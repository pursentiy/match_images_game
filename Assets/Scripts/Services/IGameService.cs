using ProgressHandlers;

namespace Services
{
    public interface IGameService
    {
        void InitializeGameService(IProgressHandler progressHandler);
        IProgressHandler ProgressHandler { get; }
    }
}