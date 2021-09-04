using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace Figures
{
    public abstract class Figure : MonoBehaviour, IFigure
    {
        [SerializeField] private FigureType _figureType;
        
        public FigureType FigureType { get; }
        public bool IsCompleted { get; private set; }
        public bool IsTarget { get; private set;}
        public int FigureScale { get; private set;}
        public Color FigureColor { get; private set;}

        public void SetFigureCompleted(bool value)
        {
            IsCompleted = value;
        }

        public void SetUpDefaultParamsFigure(Color figureColor, bool isTarget)
        {
            FigureColor = figureColor;
            IsTarget = isTarget;
        }
    }
}
