using Screen.SubElements;
using Services;
using UnityEngine;
using Zenject;

namespace Screen
{
    public class ChooseLevelScreenHandler : ScreenHandler
    {
        [Inject] private IGameService _gameService;
        
        [SerializeField] private LevelEnterPopupHandler _levelEnterPopupPrefab;
        [SerializeField] private RectTransform _levelEnterPopupsParentTransform;

        private void Start()
        {
            InitializeLevelsButton();
        }

        private void InitializeLevelsButton()
        {
            var levelsParams = _gameService.ProgressHandler.GetAllLevelsParams();
            levelsParams.ForEach(levelParams =>
            {
                var enterButton = Instantiate(_levelEnterPopupPrefab, _levelEnterPopupsParentTransform);
                enterButton.Initialize(levelParams.LevelNumber, levelParams.LevelPlayable,
                    () =>
                    {
                        _gameService.ScreenHandler.PopupAllScreenHandlers();
                        _gameService.LevelSessionHandler.StartLevel(levelParams,
                            _gameService.LevelHandler.LevelHudHandlerPrefab,
                            _gameService.LevelHandler.TargetFigureDefaultColor);
                    });
            });
        }
    }
}