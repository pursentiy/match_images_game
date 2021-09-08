using Installers;
using UnityEngine;
using Zenject;

namespace Pooling
{
    public class PoolObject : InjectableMonoBehaviour
    {
        [Inject] private ObjectsPoolHandler _objectsPoolHandler;
        
        public PoolType _poolType;

        public void Initialize(PoolType poolType)
        {
            _poolType = poolType;
        }

        public void ResetObject()
        {
            _objectsPoolHandler.TryRemoveOldComponents(_poolType, gameObject);
            _objectsPoolHandler.ResetPoolObjectParent(this, _poolType);
            gameObject.SetActive(false);
        }
    }
}