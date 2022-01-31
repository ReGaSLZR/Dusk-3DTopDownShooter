using ReGaSLZR.Character.Player;
using ReGaSLZR.Config;
using Zenject;

namespace ReGaSLZR.Character.Enemy
{

    public class EnemyBrain : BaseBrain
    {

        [Inject]
        private IPlayer.ISetter player;

        private Config.Enemy dummyConfig = new Config.Enemy();
        private EnemyConfigSO config;
        public Config.Enemy Config => (config == null) ? dummyConfig : config.Config;

        private EnemyPooler pooler;

        public override void OnDeath()
        {
            player.IncrementScore();

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