using NaughtyAttributes;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ReGaSLZR.Character.Enemy
{

    public class EnemyHealth : CharacterHealth
    {

        #region Inspector Fields

        [SerializeField]
        [Required]
        private Slider sliderHealth;

        #endregion

        public override void SetMaxHealth(uint maxHealth)
        {
            base.SetMaxHealth(maxHealth);
            sliderHealth.maxValue = maxHealth;
        }

        protected override void RegisterObservables()
        {
            GetHealth()
                .Subscribe(health => sliderHealth.value = health)
                .AddTo(disposablesBasic);
        }

    }

}