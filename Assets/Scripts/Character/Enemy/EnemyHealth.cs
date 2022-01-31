using UniRx;
using UnityEngine;

namespace ReGaSLZR.Character.Enemy
{

    [RequireComponent(typeof(EnemyBrain))]
    public class EnemyHealth : BaseHealth
    {

        #region Private Fields

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
            SetMaxHealth(brain.Config.Stats.MaxHealth);

            GetHealth()
                .Where(health => health <= 0)
                .Subscribe(_ => brain.OnDeath())
                .AddTo(disposablesBasic);
        }

        #endregion

    }

}