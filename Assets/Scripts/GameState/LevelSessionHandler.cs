using DG.Tweening;
using Figures.Animals;
using Installers;
using Level.Game;
using Level.Hud;
using Level.Hud.Click;
using Storage;
using Storage.Levels.Params;
using UnityEngine;
using Zenject;

namespace GameState
{
    public class LevelSessionHandler : InjectableMonoBehaviour, ILevelSessionHandler
    {
        [Inject] private FiguresStorage _figuresStorage;

        [SerializeField] private RectTransform _gameMainCanvasTransform;
        [SerializeField] private RectTransform _draggingTransform;
        [SerializeField] private ClickHandler _clickHandler;

        private ILevelVisualHandler _levelVisualHandler;
        private ILevelHudHandler _levelHudHandler;
        private FigureAnimalsMenu _draggingFigure;
        private FigureAnimalsMenu _menuFigure;
        private bool _isDraggable;

        public void StartLevel(LevelParams levelParams, LevelHudHandler levelHudHandler, Color defaultColor)
        {
            SetClickListeners();
            
            SetupHud(levelParams, levelHudHandler);
            SetupFigures(levelParams, defaultColor);
        }

        private void SetClickListeners()
        {
            _clickHandler.StartGrabbingPositionSignal.AddListener(StartElementDragging);
            _clickHandler.ReleaseGrabbingPositionSignal.AddListener(EndElementDragging);
        }

        private void SetupFigures(LevelParams levelParam, Color defaultColor)
        {
            _levelVisualHandler = ContainerHolder.CurrentContainer.InstantiatePrefabForComponent<ILevelVisualHandler>(levelParam.LevelVisualHandler);
            _levelVisualHandler.SetupLevel(levelParam.LevelFiguresParamsList, defaultColor);
        }

        private void SetupHud(LevelParams levelParam, LevelHudHandler levelHudHandler)
        {
            _levelHudHandler = ContainerHolder.CurrentContainer.InstantiatePrefabForComponent<ILevelHudHandler>(levelHudHandler, _gameMainCanvasTransform);
            _levelHudHandler.SetupScrollMenu(levelParam.LevelFiguresParamsList);
        }

        private void StartElementDragging(FigureAnimalsMenu figure)
        {
            if (figure == null || figure.IsCompleted)
            {
                return;
            }

            _isDraggable = true;
            _menuFigure = figure;
            _levelHudHandler.LockScroll(true);
            SetupDraggingFigure(figure);
        }

        private void SetupDraggingFigure(FigureAnimalsMenu figure)
        {
            _draggingFigure = Instantiate(_figuresStorage.GetFiguresByType(figure.FigureType).FigureMenu, Input.mousePosition, Quaternion.identity, _draggingTransform);
            _draggingFigure.SetUpDefaultParamsFigure(figure.FigureColor, figure.FigureType);
            _draggingFigure.SetUpFigure(figure.FigureColor);
            _draggingFigure.SetScale(1.5f);
        }

        private void EndElementDragging(FigureAnimalTarget releasedOnFigure)
        {
            _isDraggable = false;
        
            if (_draggingFigure == null)
            {
                return;
            }

            if (releasedOnFigure == null)
            {
                ResetDraggingFigure();
            }

            if (_draggingFigure.FigureType == releasedOnFigure.FigureType)
            {
                DOTween.Sequence().Append(_draggingFigure.transform.DOScale(0, 0.4f)).AppendCallback(() =>
                {
                    ClearDraggingFigure();
                    releasedOnFigure.SetConnected();
                    _menuFigure.SetConnected();
                });
            }
            else
            {
                ResetDraggingFigure();
            }
        }

        private void ResetDraggingFigure()
        {
            DOTween.Sequence().Append(_draggingFigure.transform.DOMove(_menuFigure.transform.position, 0.4f))
                .Insert(0.2f, _draggingFigure.transform.DOScale(0, 0.2f))
                .AppendCallback(ClearDraggingFigure);
        }

        private void ClearDraggingFigure()
        {
            _levelHudHandler.LockScroll(false);
            Destroy(_draggingFigure.gameObject);
            _draggingFigure = null;
        }

        private void Update()
        {
            TryUpdateDraggingFigurePosition();
        }

        private void TryUpdateDraggingFigurePosition()
        {
            if (_draggingFigure == null || !_isDraggable)
            {
                return;
            }

            _draggingFigure.transform.position = Input.mousePosition;
        }

        private void OnDestroy()
        {
            _clickHandler.StartGrabbingPositionSignal.RemoveListener(StartElementDragging);
            _clickHandler.ReleaseGrabbingPositionSignal.RemoveListener(EndElementDragging);
        }
    }
}
