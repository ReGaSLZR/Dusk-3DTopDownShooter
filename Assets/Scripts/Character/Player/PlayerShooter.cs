using UnityEngine;
using ReGaSLZR.Player.Controls;
using UniRx.Triggers;
using UniRx;
using Zenject;
using ReGaSLZR.Config;

namespace ReGaSLZR.Character.Action
{

    public class PlayerShooter : BaseShooter
    {

        [Inject]
        private IPlayerInput playerInput;

        [Inject]
        private Config.Player config;

        #region Unity Callbacks

        private void Awake()
        {
            bulletPooler.SetUp(config.Bullet.PoolCount);
        }

        #endregion

        #region Class Overrides

        protected override void RegisterObservables()
        {
            this.UpdateAsObservable()
                .Select(_ => playerInput.IsFiring().Value)
                .Where(isFiring => isFiring && (lastShootTime < Time.time))
                .Subscribe(_ => {
                    SetLastShootTime(config.Bullet.AttackInterval);
                    FireBullet(config.Bullet.Damage,
                        config.Bullet.Lifetime, config.Bullet.Speed);
                })
                .AddTo(disposablesBasic);
        }

        #endregion

    }

}