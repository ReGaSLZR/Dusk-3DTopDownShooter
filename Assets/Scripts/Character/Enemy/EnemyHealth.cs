using NaughtyAttributes;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ReGaSLZR.Character.Enemy
{

    [RequireComponent(typeof(EnemyBrain))]
    public class EnemyHealth : CharacterHealth
    {

        #region Inspector Fields

        [SerializeField]
        [Required]
        private Slider sliderHealth;

        private EnemyBrain brain;

        #endregion

        private void Awake()
        {
            brain = GetComponent<EnemyBrain>();
        }

        public override void SetMaxHealth(uint maxHealth)
        {
            base.SetMaxHealth(maxHealth);
            sliderHealth.maxValue = maxHealth;
        }

        protected override void RegisterObservables()
        {
            SetMaxHealth(brain.Config.Stats.MaxHealth);

            GetHealth()
                .Subscribe(health => sliderHealth.value = health)
                .AddTo(disposablesBasic);

            GetHealth()
                .Where(health => health == 0)
                .Subscribe(_ => brain.OnDeath())
                .AddTo(disposablesBasic);
        }

    }

}