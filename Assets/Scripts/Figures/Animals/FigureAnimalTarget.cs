using UnityEngine;

namespace Figures.Animals
{
    public class FigureAnimalTarget : Figure, IFigureAnimalTarget
    {
        public void SetUpFigure(float scale, Color color, Vector3 position)
        {
            _spriteRenderer.color = color;
            _transform.localScale = new Vector3(scale, scale, 0);
            _transform.position = position;
        }
        
        public void SetConnected()
        {
            SetFigureColor();
            SetConnected();
        }
    }
}