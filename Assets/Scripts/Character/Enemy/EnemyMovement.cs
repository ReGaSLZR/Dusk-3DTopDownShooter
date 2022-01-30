using UnityEngine;
using UniRx;
using UniRx.Triggers;
using NaughtyAttributes;
using ReGaSLZR.Base;
using ReGaSLZR.Character.Player;
using Zenject;

namespace ReGaSLZR.Character.Enemy
{

    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMovement : ReactiveMonoBehaviour
    {

        [SerializeField]
        private MoveType moveType;

        [SerializeField]
        [Required]
        private Transform pivotRotation;

        [Inject]
        private IPlayer.IGetter player;

        private Rigidbody rigidBody;

        #region Unity Callbacks

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        #endregion

        #region Class Overrides

        protected override void RegisterObservables()
        {
            this.FixedUpdateAsObservable()
                .Where(_ => player.HasPlayer())
                .Subscribe(_ => Move())
                .AddTo(disposablesBasic);
        }

        #endregion

        #region Class Implementation

        private void Move()
        {
            pivotRotation.LookAt(player.GetPlayer().Value.transform);

            switch (moveType)
            {
                case MoveType.Chase:
                    {
                        rigidBody.position += player.GetDirection(rigidBody.position)
                            * Time.fixedDeltaTime * 5f;
                        break;
                    }
                case MoveType.StaysDistant:
                    {

                        break;
                    }
                case MoveType.Stationary:
                    {
                        //Literally does nothing
                        break;
                    }
            }
        }

        #endregion

    }

}