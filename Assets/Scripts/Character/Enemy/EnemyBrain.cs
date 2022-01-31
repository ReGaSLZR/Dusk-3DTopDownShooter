using ReGaSLZR.Character.Player;
using ReGaSLZR.Config;
using Zenject;

namespace ReGaSLZR.Character.Enemy
{

    public class EnemyBrain : BaseBrain
    {

        #region Private Fields

        [Inject]
        private IPlayer.ISetter player;

        private Config.Enemy dummyConfig = new Config.Enemy();
        private EnemyConfigSO config;

        private EnemyPooler pooler;

        #endregion

        #region Accessors

        public Config.Enemy Config => (config == null) ? dummyConfig : config.Config;

        #endregion

        #region Class Overrides

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

        #endregion

        #region Public API

        public void SetConfig(EnemyConfigSO config)
        {
            this.config = config;
        }

        public void SetPooler(EnemyPooler pooler)
        {
            this.pooler = pooler;
        }

        #endregion

    }

}