using ReGaSLZR.Base;
using ReGaSLZR.Bullet;
using ReGaSLZR.Character.Player;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace ReGaSLZR.Character.Enemy
{

    public class EnemyShooter : CharacterShooter
    {

        [Inject]
        private IPlayer.IGetter player;

        private float cooldown = 1f;
        private float minDistance = 5f;

        protected override void RegisterObservables()
        {
            this.UpdateAsObservable()
                .Where(_ => player.HasPlayer())
                .Where(_ => 
                    Vector3.Distance(player.GetPosition(), transform.position) <= minDistance)
                .Subscribe(_ =>
                {
                    SetLastShootTime(cooldown);
                    FireBullet(1, 3, 10);
                })
                .AddTo(disposablesBasic);
        }

    }

}