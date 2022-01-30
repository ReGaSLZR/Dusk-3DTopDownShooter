using UnityEngine;
using Zenject;

namespace ReGaSLZR.Base
{

    public interface IPrefabInjector
    {
        void InjectPrefab(GameObject prefab);
        GameObject InstantiateInjectPrefab(GameObject prefab, Transform parent);
    }

    public class PrefabInjector : MonoInstaller<PrefabInjector>, IPrefabInjector
    {

        public override void InstallBindings()
        {
            Container.BindInstance<IPrefabInjector>(this);
        }

        #region Class Overrides

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