using Services;
using Storage;
using Storage.Levels.Params;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private LevelsParamsStorage levelsParamsStorage;
        [SerializeField] private FiguresStorage _figuresStorage;
        
        private GameObject _servicesRoot;
        
        public override void InstallBindings()
        {
            ContainerHolder.OnProjectInstall(Container);
            
            _servicesRoot = new GameObject("SceneServices");
            
            Container.Bind<IGameService>().To<GameService>().FromNewComponentOn(_servicesRoot).AsSingle().NonLazy();
            Container.Bind<LevelsParamsStorage>().FromScriptableObject(levelsParamsStorage).AsSingle().NonLazy();
            Container.Bind<FiguresStorage>().FromScriptableObject(_figuresStorage).AsSingle().NonLazy();
            Container.Bind<IProcessProgressDataService>().To<ProcessProgressDataService>().AsSingle().NonLazy();
        }
    }
}