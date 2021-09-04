using UnityEngine;

namespace Figures.Animals
{
    public class FigureAnimalTarget : Figure, IFigureAnimalTarget
    {
        public void SetConnected()
        {
            SetFigureColor();
            SetConnected();
        }
    }
}