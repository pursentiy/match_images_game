using System;
using System.Collections.Generic;
using Figures;
using Figures.Animals;
using Level.Params;
using UnityEngine;

namespace Level
{
    public class LevelVisualHandler : MonoBehaviour, ILevelVisualHandler
    {
        [SerializeField] private Transform _figuresParentTransform;
        private List<FigureAnimalTarget> _figureAnimalsList;
        
        public void SetupLevel(List<LevelFigureParams> levelFiguresParams)
        {
            levelFiguresParams.ForEach(SetFigure);
        }

        private void SetFigure(LevelFigureParams figureParams)
        {
            var figure = Instantiate(figureParams.FigureAnimal, _figuresParentTransform);
            figure.SetUpFigure(figureParams.Scale, figureParams.Color, figureParams.Position);
            _figureAnimalsList.Add(figure);
        }

        public void ConnectFigures(FigureAnimalTarget figureTarget)
        {
            _figureAnimalsList.ForEach(figure =>
            {
                if (figure.FigureType == figureTarget.FigureType)
                {
                    figure.SetConnected();
                }
            });
        }
    }
}
