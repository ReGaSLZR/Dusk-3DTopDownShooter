using UnityEngine;
using Zenject;

namespace ReGaSLZR.Config
{

    [CreateAssetMenu(fileName = "New EnemySpawner Config", 
        menuName = "ReGaSLZR/Config/New EnemySpawner")]
    public class EnemySpawnerSO : ScriptableObjectInstaller<EnemySpawnerSO>
    {

        [SerializeField]
        private EnemySpawner config;

        public override void InstallBindings()
        {
            Container.BindInstances(config);
        }

    }

}
