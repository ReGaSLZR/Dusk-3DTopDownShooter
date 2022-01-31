using NaughtyAttributes;
using ReGaSLZR.Base;
using ReGaSLZR.Character.Player;
using ReGaSLZR.Data;
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

        #endregion

        [Inject]
        private IPlayer.IGetter player;

        [Inject]
        private IData.IGetter data;

        protected override void RegisterObservables()
        {
            player.GetMaxHealth()
                .Subscribe(max => sliderHealth.maxValue = max)
                .AddTo(disposablesBasic);

            player.GetHealth()
                .Subscribe(health => sliderHealth.value = health)
                .AddTo(disposablesBasic);

            player.GetScore()
                .Subscribe(score => textScore.text = score.ToString())
                .AddTo(disposablesBasic);

            data.GetHighScore()
                .Subscribe(highScore => textHighScore.text = highScore.ToString())
                .AddTo(disposablesBasic);
        }

    }

}