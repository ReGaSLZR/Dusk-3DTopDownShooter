using UnityEngine;
using ReGaSLZR.Base;
using ReGaSLZR.Player.Controls;
using UniRx.Triggers;
using UniRx;
using Zenject;
using ReGaSLZR.Config;
using ReGaSLZR.Bullet;

namespace ReGaSLZR.Character.Action
{

    public class PlayerShooter : ReactiveMonoBehaviour
    {

        [SerializeField]
        private BulletController prefabBullet;

        [SerializeField]
        private Transform bulletSpawnPoint;

        [Inject]
        private IPlayerInput playerInput;

        [Inject]
        private PlayerConfig config;

        private float lastShootTime = 0f;

        protected override void RegisterObservables()
        {
            this.UpdateAsObservable()
                .Select(_ => playerInput.IsFiring().Value)
                .Where(isFiring => isFiring && (lastShootTime < Time.time))
                .Subscribe(_ => OnFire())
                .AddTo(disposablesBasic);
        }

        #region Class Implementation

        private void OnFire()
        {
            lastShootTime = (Time.time + config.FireCooldown);
            var bullet = Instantiate(prefabBullet, 
                bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.ApplyLifetime(config.BulletLifetime);
            bullet.ApplyForce(config.BulletForce);
        }

        #endregion

    }

}