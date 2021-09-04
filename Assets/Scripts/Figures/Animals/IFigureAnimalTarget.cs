using UnityEngine;

namespace Figures.Animals
{
    public interface IFigureAnimalTarget
    {
        void SetUpFigure(float scale, Vector3 position);
        void SetConnected();
    }
}