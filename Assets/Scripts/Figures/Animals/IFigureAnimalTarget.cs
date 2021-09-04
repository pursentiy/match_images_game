using UnityEngine;

namespace Figures.Animals
{
    public interface IFigureAnimalTarget
    {
        void SetUpFigure(Color color, float scale, Vector3 position);
        void SetConnected();
    }
}