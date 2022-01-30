using UnityEngine;
using Zenject;

namespace ReGaSLZR.Config
{

    [CreateAssetMenu(fileName = "New Enemy Config", menuName = "ReGaSLZR/Config")]
    public class EnemyConfigSO : ScriptableObjectInstaller<EnemyConfigSO>
    {

        #region Fields

        [SerializeField]
        private Enemy config;

        #endregion

        public override void InstallBindings()
        {
            Container.BindInstances(config);
        }

    }

}