using System.Collections;
using System.Collections.Generic;
using Installers;
using Level;
using Level.Game;
using Level.Hud;
using Storage;
using Storage.Levels.Params;
using UnityEngine;
using Zenject;

public class StartGame : InjectableMonoBehaviour
{
    [Inject] private LevelsParamsStorage _levelsParamsStorage;

    [SerializeField] private RectTransform _gameMainCanvasTransform;

    private ILevelVisualHandler _levelVisualHandler;
    private ILevelHudHandler _levelHudHandler;

    protected override void Awake()
    {
        var levelParam = _levelsParamsStorage.GetLevelByNumber(1);
        
        SetupHud(levelParam);
        SetupFigures(levelParam);
    }

    private void SetupFigures(LevelParams levelParam)
    {
        _levelVisualHandler = ContainerHolder.CurrentContainer.InstantiatePrefabForComponent<ILevelVisualHandler>(levelParam.LevelVisualHandler);
        _levelVisualHandler.SetupLevel(levelParam.LevelFiguresParamsList);
    }

    private void SetupHud(LevelParams levelParam)
    {
        _levelHudHandler = ContainerHolder.CurrentContainer.InstantiatePrefabForComponent<ILevelHudHandler>(_levelsParamsStorage.GetLevelHudHandler(), _gameMainCanvasTransform);
        _levelHudHandler.SetupScrollMenu(levelParam.LevelFiguresParamsList);
    }
}
