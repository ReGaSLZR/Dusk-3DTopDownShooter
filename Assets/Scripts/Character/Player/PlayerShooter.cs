using UnityEngine;
using ReGaSLZR.Base;
using ReGaSLZR.Player.Controls;
using UniRx.Triggers;
using UniRx;
using Zenject;
using ReGaSLZR.Config;
using ReGaSLZR.Bullet;
using NaughtyAttributes;

namespace ReGaSLZR.Character.Action
{

    public class PlayerShooter : ReactiveMonoBehaviour
    {

        #region Inspector Fields

        [SerializeField]
        [Required]
        private BulletPooler bulletPooler;

        [SerializeField]
        [Required]
        private Transform bulletSpawnPoint;

        #endregion

        [Inject]
        private IPlayerInput playerInput;

        [Inject]
        private PlayerConfig config;

        private float lastShootTime = 0f;

        #region Unity Callbacks

        private void Awake()
        {
            bulletPooler.SetUp(config.BulletPoolCount);
        }

        #endregion

        #region Class Overrides

        protected override void RegisterObservables()
        {
            this.UpdateAsObservable()
                .Select(_ => playerInput.IsFiring().Value)
                .Where(isFiring => isFiring && (lastShootTime < Time.time))
                .Subscribe(_ => FireBullet())
                .AddTo(disposablesBasic);
        }

        #endregion

        #region Class Implementation

        private void FireBullet()
        {
            lastShootTime = (Time.time + config.FireCooldown);

            var bullet = bulletPooler.GetPooledItem();
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = bulletSpawnPoint.rotation;
            bullet.SetDamage(config.BulletDamage);
            bullet.SetPooler(bulletPooler);
            bullet.ApplyLifetime(config.BulletLifetime);
            bullet.ApplyForce(config.BulletTravelSpeed);
        }

        #endregion

    }

}