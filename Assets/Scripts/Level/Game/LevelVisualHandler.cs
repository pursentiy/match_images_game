using System.Collections.Generic;
using Figures.Animals;
using Installers;
using Plugins.FSignal;
using Storage;
using Storage.Levels.Params;
using UnityEngine;
using Zenject;

namespace Level.Game
{
    public class LevelVisualHandler : InjectableMonoBehaviour, ILevelVisualHandler
    {
        [Inject] private FiguresStorage _figuresStorage;

        [SerializeField] private Transform _figuresParentTransform;
        [SerializeField] private Camera _textureCamera;
        
        public Camera TextureCamera => _textureCamera;
        
        public void SetupLevel(List<LevelFigureParams> levelFiguresParams, Color defaultColor)
        {
            levelFiguresParams.ForEach(figure => SetFigure(figure, defaultColor));
        }

        private void SetFigure(LevelFigureParams figureParams, Color defaultColor)
        {
            var figurePrefab = _figuresStorage.GetFiguresByType(figureParams.FigureType);

            if (figurePrefab == null)
            {
                Debug.LogWarning($"Could not find figure with type {figureParams.FigureType} in {this}");
                return;
            }
            
            var figure = Instantiate(figurePrefab.FigureAnimal, _figuresParentTransform);
            figure.SetUpFigure(figureParams.Completed ? figureParams.Color : defaultColor, figureParams.Scale, figureParams.Position);
            figure.SetUpDefaultParamsFigure(figureParams.Color, figureParams.FigureType);
        }
    }
}
