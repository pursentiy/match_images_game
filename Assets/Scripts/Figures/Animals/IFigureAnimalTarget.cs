using UnityEngine;

namespace Figures.Animals
{
    public interface IFigureAnimalTarget
    {
        void SetUpFigure(float scale, Color color, Vector3 position);
        void SetConnected();
    }
}