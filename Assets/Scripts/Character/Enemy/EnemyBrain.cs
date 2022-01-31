using ReGaSLZR.Config;
using UnityEngine;

namespace ReGaSLZR.Character.Enemy
{

    public class EnemyBrain : MonoBehaviour
    {

        private Config.Enemy dummyConfig = new Config.Enemy();
        private EnemyConfigSO config;
        public Config.Enemy Config => (config == null) ? dummyConfig : config.Config;

        private EnemyPooler pooler;

        public void OnDeath()
        {
            if (pooler == null)
            {
                gameObject.SetActive(false);
                return;
            }

            pooler.ReturnPooledItem(this);
        }

        public void SetConfig(EnemyConfigSO config)
        {
            this.config = config;
        }

        public void SetPooler(EnemyPooler pooler)
        {
            this.pooler = pooler;
        }

    }

}