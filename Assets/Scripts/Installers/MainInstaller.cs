using Level.Params;
using Level.Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private LevelsParamsService _levelsParamsService;
        private GameObject _servicesRoot;
        public override void InstallBindings()
        {
            ContainerHolder.OnProjectInstall(Container);
            
            _servicesRoot = new GameObject("SceneServices");
            
            Container.Bind<LevelsParamsService>().FromScriptableObject(_levelsParamsService).AsSingle();
        }
    }
}