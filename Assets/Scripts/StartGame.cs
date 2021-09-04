using System.Collections;
using System.Collections.Generic;
using Installers;
using Level.Services;
using UnityEngine;
using Zenject;

public class StartGame : InjectableMonoBehaviour
{
    [Inject] private LevelsParamsService _levelsParamsService;
    
    void Start()
    {
        var a = 1;
    }
    
    void Update()
    {
        
    }
}
