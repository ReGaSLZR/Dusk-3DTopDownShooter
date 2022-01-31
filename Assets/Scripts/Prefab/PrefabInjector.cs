using UnityEngine;
using Zenject;

namespace ReGaSLZR.Prefab
{

    public class PrefabInjector : MonoInstaller<PrefabInjector>, IPrefabInjector
    {

        #region Class Overrides

        public override void InstallBindings()
        {
            Container.BindInstance<IPrefabInjector>(this);
        }

        #endregion

        #region Interface Implementation

        public void InjectPrefab(GameObject prefab)
        {
            Container.InjectGameObject(prefab);
        }

        public GameObject InstantiateInjectPrefab(GameObject prefab, Transform parent)
        {
            GameObject instantiatedObject = Instantiate(prefab, parent.position, parent.rotation);
            InjectPrefab(instantiatedObject);
            return instantiatedObject;
        }

        #endregion

    }

}