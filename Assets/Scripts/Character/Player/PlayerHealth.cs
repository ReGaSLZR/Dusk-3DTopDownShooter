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
        private PlayerConfig config;

        protected override void RegisterObservables()
        {   
            GetHealth()
                .Subscribe(health => player.SetHealth(health))
                .AddTo(disposablesBasic);
        }

        private void Start()
        {
            player.SetMaxHealth(config.MaxHealth);
            SetMaxHealth(config.MaxHealth);
        }

    }

}