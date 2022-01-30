using UnityEngine;
using Zenject;

namespace ReGaSLZR.Config
{

    [CreateAssetMenu(fileName = "New EnemyTypes Config", menuName = "ReGaSLZR/Config/New Enemy Types")]
    public class EnemyTypesSO : ScriptableObjectInstaller<EnemyTypesSO>
    {

        [SerializeField]
        private EnemyTypes types = new EnemyTypes();

        public override void InstallBindings()
        {
            Container.BindInstances(types);
        }

    }

}