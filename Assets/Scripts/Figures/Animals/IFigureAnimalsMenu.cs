using Plugins.FSignal;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Figures.Animals
{
    public interface IFigureAnimalsMenu
    {
        void SetUpFigure(Color color, int siblingPosition);
        int SiblingPosition { get; }
        void SetScale(float scale);
        FSignal<PointerEventData> OnBeginDragSignal { get; }
        FSignal<PointerEventData> OnEndDragSignal { get; }
        FSignal<PointerEventData> OnDraggingSignal { get; }
        FSignal<FigureAnimalsMenu> OnBeginDragFigureSignal { get; }
        Vector3 InitialPosition { get; set; }
        void SetConnected();
        void Destroy();
    }
}