using System.Collections.Generic;
using Figures.Animals;
using Installers;
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
        
        private List<FigureAnimalTarget> _figureAnimalsList;

        protected override void Awake()
        {
            _figureAnimalsList = new List<FigureAnimalTarget>();
        }

        public void SetupLevel(List<LevelFigureParams> levelFiguresParams)
        {
            levelFiguresParams.ForEach(SetFigure);
        }

        private void SetFigure(LevelFigureParams figureParams)
        {
            var figurePrefab = _figuresStorage.GetFiguresByType(figureParams.FigureType);

            if (figurePrefab == null)
            {
                Debug.LogWarning($"Could not find figure with type {figureParams.FigureType} in {this}");
                return;
            }
            
            var figure = Instantiate(figurePrefab.FigureAnimal, _figuresParentTransform);
            figure.SetUpFigure(figureParams.Scale, figureParams.Position);
            figure.SetUpDefaultParamsFigure(figureParams.Color, true);
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
