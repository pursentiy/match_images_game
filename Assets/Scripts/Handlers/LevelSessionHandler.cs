using DG.Tweening;
using Figures.Animals;
using Installers;
using Level.Game;
using Level.Hud;
using Level.Hud.Click;
using Services;
using Storage;
using Storage.Levels.Params;
using UnityEngine;
using Zenject;

namespace Handlers
{
    public class LevelSessionHandler : InjectableMonoBehaviour, ILevelSessionHandler
    {
        [Inject] private FiguresStorage _figuresStorage;
        [Inject] private IGameService _gameService;

        [SerializeField] private RectTransform _gameMainCanvasTransform;
        [SerializeField] private RectTransform _draggingTransform;
        [SerializeField] private ClickHandler _clickHandler;

        private LevelVisualHandler _levelVisualHandler;
        private LevelHudHandler _levelHudHandler;
        private FigureAnimalsMenu _draggingFigure;
        private FigureAnimalsMenu _menuFigure;
        private bool _isDraggable;
        private int _currentLevel;

        private Sequence _resetDraggingAnimationSequence;
        private Sequence _completeDraggingAnimationSequence;

        public void StartLevel(LevelParams levelParams, LevelHudHandler levelHudHandler, Color defaultColor)
        {
            _currentLevel = levelParams.LevelNumber;
            
            SetupClickHandler();
            SetupHud(levelParams, levelHudHandler);
            SetupFigures(levelParams, defaultColor);
            
            TryHandleLevelCompletion();
        }

        private void TryHandleLevelCompletion()
        {
            if (!_gameService.ProgressHandler.CheckForLevelCompletion(_currentLevel))
            {
                return;
            }
            
            _gameService.ScreenHandler.ShowLevelCompleteScreen(_currentLevel);
            OnDestroyLevel();
        }

        private void SetupClickHandler()
        {
            _clickHandler.enabled = true;
            _clickHandler.StartGrabbingPositionSignal.AddListener(StartElementDragging);
            _clickHandler.ReleaseGrabbingPositionSignal.AddListener(EndElementDragging);
        }

        private void SetupFigures(LevelParams levelParam, Color defaultColor)
        {
            _levelVisualHandler = ContainerHolder.CurrentContainer.InstantiatePrefabForComponent<LevelVisualHandler>(levelParam.LevelVisualHandler);
            _levelVisualHandler.SetupLevel(levelParam.LevelFiguresParamsList, defaultColor);
        }

        private void SetupHud(LevelParams levelParam, LevelHudHandler levelHudHandler)
        {
            _levelHudHandler = ContainerHolder.CurrentContainer.InstantiatePrefabForComponent<LevelHudHandler>(levelHudHandler, _gameMainCanvasTransform);
            _levelHudHandler.SetupScrollMenu(levelParam.LevelFiguresParamsList);
            
            _levelHudHandler.BackToMenuClickSignal.AddListener(OnDestroyLevel);
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
                return;
            }

            if (_draggingFigure.FigureType == releasedOnFigure.FigureType)
            {
                _gameService.ProgressHandler.UpdateProgress(_currentLevel, releasedOnFigure.FigureType);
                _completeDraggingAnimationSequence = DOTween.Sequence().Append(_draggingFigure.transform.DOScale(0, 0.4f)).AppendCallback(() =>
                {
                    ClearDraggingFigure();
                    releasedOnFigure.SetConnected();
                    _menuFigure.SetConnected();

                    TryHandleLevelCompletion();
                });
            }
            else
            {
                ResetDraggingFigure();
            }
        }

        private void ResetDraggingFigure()
        {
            _resetDraggingAnimationSequence = DOTween.Sequence().Append(_draggingFigure.transform.DOMove(_menuFigure.transform.position, 0.4f))
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

        private void OnDestroyLevel()
        {
            ResetAnimationSequences();
            DestroyHandlers();
            
            _clickHandler.StartGrabbingPositionSignal.RemoveListener(StartElementDragging);
            _clickHandler.ReleaseGrabbingPositionSignal.RemoveListener(EndElementDragging);
            _clickHandler.enabled = false;
        }

        private void DestroyHandlers()
        {
            if (_levelHudHandler != null)
            {
                _levelHudHandler.BackToMenuClickSignal.RemoveListener(OnDestroyLevel);
                Destroy(_levelHudHandler.gameObject);
                _levelHudHandler = null;
            }
            
            if (_levelVisualHandler != null)
            {
                Destroy(_levelVisualHandler.gameObject);
                _levelVisualHandler = null;
            }
        }

        private void ResetAnimationSequences()
        {
            _resetDraggingAnimationSequence?.Kill();
            _completeDraggingAnimationSequence?.Kill();
        }
    }
}
