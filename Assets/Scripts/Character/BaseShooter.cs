using NaughtyAttributes;
using ReGaSLZR.Base;
using ReGaSLZR.Bullet;
using UnityEngine;

namespace ReGaSLZR.Character
{

    public abstract class BaseShooter : ReactiveMonoBehaviour
    {

        [SerializeField]
        [Required]
        protected BulletPooler bulletPooler;

        [SerializeField]
        [Required]
        protected Transform bulletSpawnPoint;

        protected float lastShootTime = 0f;

        #region Class Implementation

        protected virtual void FireBullet(uint damage, float lifetime, float speed)
        {
            var bullet = bulletPooler.GetPooledItem();
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = bulletSpawnPoint.rotation;
            bullet.SetDamage(damage);
            bullet.SetPooler(bulletPooler);
            bullet.ApplyLifetime(lifetime);
            bullet.ApplyForce(speed);
        }

        protected virtual void SetLastShootTime(float cooldown)
        {
            lastShootTime = (Time.time + cooldown);
        }

        #endregion

    }

}