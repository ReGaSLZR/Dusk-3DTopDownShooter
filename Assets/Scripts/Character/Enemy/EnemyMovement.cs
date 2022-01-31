using UnityEngine;
using UniRx;
using UniRx.Triggers;
using NaughtyAttributes;
using ReGaSLZR.Base;
using ReGaSLZR.Character.Player;
using Zenject;

namespace ReGaSLZR.Character.Enemy
{

    [RequireComponent(typeof(EnemyBrain))]
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMovement : ReactiveMonoBehaviour
    {

        [SerializeField]
        [Required]
        private Transform pivotRotation;

        [Inject]
        private IPlayer.IGetter player;

        private Rigidbody rigidBody;
        private EnemyBrain brain;

        #region Unity Callbacks

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            brain = GetComponent<EnemyBrain>();
        }

        #endregion

        #region Class Overrides

        protected override void RegisterObservables()
        {
            if (player == null)
            {
                return;
            }

            this.FixedUpdateAsObservable()
                .Where(_ => player.HasPlayer())
                .Subscribe(_ => Move())
                .AddTo(disposablesBasic);
        }

        #endregion

        #region Class Implementation

        private void Move()
        {
            pivotRotation.LookAt(player.GetPosition());

            switch (brain.Config.MoveType)
            {
                case MoveType.Chase:
                    {
                        MoveRelativeToPlayer(true);
                        break;
                    }
                case MoveType.StaysDistant:
                    {
                        StayDistant();
                        break;
                    }
                case MoveType.Stationary:
                    {
                        //Literally does nothing
                        break;
                    }
            }
        }

        private void MoveRelativeToPlayer(bool shouldGoNear)
        {
            var movement = player.GetDirection(rigidBody.position)
                                * Time.fixedDeltaTime * brain.Config.Mvmt.SpeedMovement;

            if (shouldGoNear)
            {
                rigidBody.position += movement;
            }
            else 
            {
                rigidBody.position -= movement;
            }
            
        }

        private void StayDistant()
        {
            var distance = Vector3.Distance(player.GetPosition(), rigidBody.position);
            MoveRelativeToPlayer(!(distance <= brain.Config.AttackDistance));
        }

        #endregion

    }

}