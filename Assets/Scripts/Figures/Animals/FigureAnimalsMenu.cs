using UnityEngine;
using UnityEngine.UI;

namespace Figures.Animals
{
    public class FigureAnimalsMenu : Figure, IFigureAnimalsMenu
    {
        [SerializeField] protected Image _image;
        [SerializeField] protected RectTransform _transform;
        
        public void SetUpFigure(Color color)
        {
            _image.color = color;
        }
    }
}