using NaughtyAttributes;
using ReGaSLZR.Base;
using ReGaSLZR.Config;
using UnityEngine;

namespace ReGaSLZR.Character.Enemy
{

    public class EnemyBrain : ReactiveMonoBehaviour
    {

        [SerializeField]
        [Required]
        private EnemyConfigSO config;
        public Config.Enemy Config => (config == null) ? dummyConfig : config.Config;

        private Config.Enemy dummyConfig = new Config.Enemy();

        public void OnDeath()
        {
            gameObject.SetActive(false); //TODO improve this
        }

        protected override void RegisterObservables()
        {
            //todo
        }

    }

}