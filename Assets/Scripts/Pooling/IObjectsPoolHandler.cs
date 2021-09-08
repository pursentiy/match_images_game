using UnityEngine;

namespace Pooling
{
    public interface IObjectsPoolHandler
    {
        GameObject GetPoolPrefab(PoolType poolType);
        void TryRemoveOldComponents(PoolType poolType, GameObject poolObj);
        void ResetPoolObjectParent(PoolObject poolObject, PoolType poolType);
    }
}