using System;
using System.Collections.Generic;
using Figures.Animals;
using UnityEngine;

namespace Level
{
    public class LevelVisualHandler : MonoBehaviour, ILevelManager
    {
        [SerializeField] private List<FigureAnimalTarget> _figureAnimalsArray;


        public void ConnectFigures(FigureAnimalTarget figureTarget)
        {
            _figureAnimalsArray.ForEach(figure =>
            {
                if (figure.FigureType == figureTarget.FigureType)
                {
                    figure.SetConnected();
                }
            });
        }
    }
}
