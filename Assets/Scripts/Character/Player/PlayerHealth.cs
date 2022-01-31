using ReGaSLZR.Character.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace ReGaSLZR.Character.Action
{

    [RequireComponent(typeof(PlayerBrain))]
    public class PlayerHealth : BaseHealth
    {

        #region Private Fields

        [Inject]
        private IPlayer.ISetter player;

        [Inject]
        private Config.Player config;

        private PlayerBrain brain;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            brain = GetComponent<PlayerBrain>();
        }

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
                .Subscribe(health => player.SetHealth((uint)health))
                .AddTo(disposablesBasic);

            GetHealth()
                .Where(health => health <= 0)
                .Subscribe(_ => brain.OnDeath())
                .AddTo(disposablesBasic);
        }

        #endregion        

    }

}