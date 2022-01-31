using ReGaSLZR.Character.Player;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace ReGaSLZR.Character.Enemy
{

    [RequireComponent(typeof(EnemyBrain))]
    public class EnemyShooter : BaseShooter
    {

        #region Private Fields

        [Inject]
        private IPlayer.IGetter player;
        
        private EnemyBrain brain;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            brain = GetComponent<EnemyBrain>();
        }

        #endregion

        #region Class Overrides

        protected override void RegisterObservables()
        {
            bulletPooler.SetUp(brain.Config.Bullet.PoolCount);

            if (player == null)
            {
                return;
            }

            this.UpdateAsObservable()
                .Where(_ => player.HasPlayer())
                .Where(_ => 
                    Vector3.Distance(player.GetPosition(), transform.position) <= brain.Config.AttackDistance)
                .Where(_ => Time.time >= lastShootTime)
                .Subscribe(_ =>
                {
                    var bullet = brain.Config.Bullet;
                    SetLastShootTime(bullet.AttackInterval);
                    FireBullet(bullet.Damage, bullet.Lifetime, bullet.Speed);
                })
                .AddTo(disposablesBasic);
        }

        #endregion

    }

}