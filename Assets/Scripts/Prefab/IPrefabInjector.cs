using UnityEngine;

namespace ReGaSLZR.Prefab
{

    public interface IPrefabInjector
    {
        void InjectPrefab(GameObject prefab);
        GameObject InstantiateInjectPrefab(GameObject prefab, Transform parent);
    }

}