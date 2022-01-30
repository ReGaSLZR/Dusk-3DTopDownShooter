using NaughtyAttributes;
using ReGaSLZR.Base;
using ReGaSLZR.Character.Player;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ReGaSLZR.GUI
{

    public class HeadsUpDisplay : ReactiveMonoBehaviour
    {

        #region Inspector Fields

        [SerializeField]
        [Required]
        private Slider sliderHealth;

        [SerializeField]
        [Required]
        private TextMeshProUGUI textScore;

        [SerializeField]
        [Required]
        private TextMeshProUGUI textHighScore;

        [SerializeField]
        [Required]
        private TextMeshProUGUI textWave;

        #endregion

        [Inject]
        private IPlayer.IGetter player;

        protected override void RegisterObservables()
        {
            player.GetMaxHealth()
                .Subscribe(max => sliderHealth.maxValue = max)
                .AddTo(disposablesBasic);

            player.GetHealth()
                .Subscribe(health => sliderHealth.value = health)
                .AddTo(disposablesBasic);
        }

    }

}