using System.Collections.Generic;
using Figures.Animals;
using Installers;
using Storage;
using Storage.Levels.Params;
using UnityEngine;
using Zenject;

namespace Level.Hud
{
    public class LevelHudHandler : InjectableMonoBehaviour, ILevelHudHandler
    {
        [Inject] private FiguresStorage _figuresStorage;
        
        [SerializeField] private RectTransform _figuresParentTransform;
        
        private List<FigureAnimalsMenu> _figureAnimalsMenuList;

        protected override void Awake()
        {
            _figureAnimalsMenuList = new List<FigureAnimalsMenu>();
        }

        public void SetupScrollMenu(List<LevelFigureParams> levelFiguresParams)
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
            
            var figure = Instantiate(figurePrefab.FigureMenu, _figuresParentTransform);
            figure.SetUpFigure(figureParams.Color);
            figure.SetUpDefaultParamsFigure(figureParams.Color, false);
            _figureAnimalsMenuList.Add(figure);
        }


        public void ConnectFigures(FigureAnimalsMenu figureTarget)
        {
            _figureAnimalsMenuList.ForEach(figure =>
            {
                if (figure.FigureType == figureTarget.FigureType)
                {
                    //figure.SetConnected();
                }
            });
        }
    }
}