using Figures.Animals;
using Plugins.FSignal;

namespace Level.Hud.Click
{
    public interface IClickHandler
    {
        FSignal<FigureAnimalsMenu> StartGrabbingPositionSignal { get; }
        FSignal<FigureAnimalTarget> ReleaseGrabbingPositionSignal { get; }
    }
}