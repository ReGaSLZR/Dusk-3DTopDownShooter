using ReGaSLZR.Character.Player;
using ReGaSLZR.Config;
using UniRx;
using Zenject;

namespace ReGaSLZR.Character.Action
{

    public class PlayerHealth : CharacterHealth
    {

        [Inject]
        private IPlayer.ISetter player;

        [Inject]
        private Config.Player config;

        #region Unity Callbacks

        private void Start()
        {
            player.SetMaxHealth(config.Stats.MaxHealth);
            SetMaxHealth(config.Stats.MaxHealth);
        }

        #endregion

        #region Class Overrides

        protected override void RegisterObservables()
        {   
            GetHealth()
                .Subscribe(health => player.SetHealth(health))
                .AddTo(disposablesBasic);
        }

        #endregion        

    }

}