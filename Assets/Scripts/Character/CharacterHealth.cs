using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace ReGaSLZR.Character
{

    public class CharacterHealth : MonoBehaviour
    {

        #region Inspector Fields

        [SerializeField]
        [Required]
        private Slider sliderHealth;

        #endregion

        public void SetMaxHealth(uint maxHealth)
        {
            sliderHealth.maxValue = maxHealth;
        }

        public void Damage(uint damage)
        {
            sliderHealth.value = Mathf.Clamp((sliderHealth.value - damage), 
                0, sliderHealth.maxValue);

            if (sliderHealth.value == 0)
            {
                gameObject.SetActive(false);
            }
        }

    }

}